using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using Unity.Netcode;

namespace Project.Assets._Project._Scripts.Networking
{
    // What every connection path shares: connection approval with lobby slots, the client connect wait and session tracking.
    // Subclasses pick the transport and how Host/Join reach the other side.
    public abstract class ConnectionServiceBase : IConnectionService
    {
        private const string LeftReason = "Left the session";
        private const string StoppedReason = "Connection closed";

        protected readonly ConnectionSettings _settings;
        private readonly Action<NetworkManager.ConnectionApprovalRequest, NetworkManager.ConnectionApprovalResponse> _approvalCallback;
        // approved clients that haven't finished connecting yet still take a slot
        private readonly HashSet<ulong> _pendingClientIds = new();
        // names clients sent in their connection data, kept while they're connected
        private readonly Dictionary<ulong, string> _playerNames = new();

        public event Action<string> OnDisconnected;

        private NetworkManager _sessionNetworkManager;
        private NetworkManager _approvingNetworkManager;
        private int _hostedMaxPlayers;
        private bool _isLeaving;
        private string _lastFailureReason;

        protected ConnectionServiceBase(ConnectionSettings settings)
        {
            _settings = settings;
            _approvalCallback = ApproveConnection;
        }

        public bool IsConnected => _sessionNetworkManager != null && _sessionNetworkManager.IsListening;
        public string LastFailureReason => _lastFailureReason;
        public int TakenSlotCount => _approvingNetworkManager != null ? CountTakenSlots() : 0;
        public virtual bool CanInviteFriends => false;
        public virtual string JoinCode => null;
        protected bool IsHosting => _approvingNetworkManager != null;
        private string LogPrefix => $"[{GetType().Name}]";

        public abstract UniTask<bool> Host(LobbyConfig config, CancellationToken token);

        public abstract UniTask<bool> Join(string target, CancellationToken token);

        public virtual void UpdateHostedLobby(LobbyConfig config)
        {
            if (!IsHosting) return;
            _hostedMaxPlayers = config.MaxPlayers;
        }

        public void Leave()
        {
            if (!IsConnected) return;

            _isLeaving = true;
            _sessionNetworkManager.Shutdown();
        }

        public bool TryGetPlayerName(ulong clientId, out string name) => _playerNames.TryGetValue(clientId, out name);

        public virtual void OpenInviteDialog() { }

        protected void ClearFailure() => _lastFailureReason = null;

        protected bool Fail(string reason)
        {
            _lastFailureReason = reason;
            return false;
        }

        // Shutdown() only completes on Netcode's next network update, so a Host/Join right after a failed join or Leave() waits for it
        protected async UniTask<NetworkManager> GetIdleNetworkManager(CancellationToken token)
        {
            var networkManager = NetworkManager.Singleton;
            if (networkManager == null)
            {
                EUtils.Logger.LogError($"{LogPrefix} No NetworkManager in the scene.");
                return null;
            }

            if (networkManager.ShutdownInProgress)
            {
                await UniTask.WaitWhile(() => networkManager != null && networkManager.ShutdownInProgress, cancellationToken: token);
                if (networkManager == null) return null;
            }

            if (networkManager.IsListening)
            {
                EUtils.Logger.LogWarning($"{LogPrefix} Already in a session.");
                return null;
            }

            return networkManager;
        }

        // Needs NetworkConfig.ConnectionApproval on; Netcode warns at StartHost when it's off
        protected void StartApproving(NetworkManager networkManager, int maxPlayers)
        {
            StopApproving();
            _approvingNetworkManager = networkManager;
            _hostedMaxPlayers = maxPlayers;
            _approvingNetworkManager.ConnectionApprovalCallback = _approvalCallback;
            _approvingNetworkManager.OnClientConnectedCallback += HandleClientSettled;
            _approvingNetworkManager.OnClientDisconnectCallback += HandleClientDisconnected;
        }

        protected void StopApproving()
        {
            if (_approvingNetworkManager != null)
            {
                if (_approvingNetworkManager.ConnectionApprovalCallback == _approvalCallback) _approvingNetworkManager.ConnectionApprovalCallback = null;
                _approvingNetworkManager.OnClientConnectedCallback -= HandleClientSettled;
                _approvingNetworkManager.OnClientDisconnectCallback -= HandleClientDisconnected;
            }
            _approvingNetworkManager = null;
            _pendingClientIds.Clear();
            _playerNames.Clear();
        }

        // Starts the client on the already configured transport and waits until it connects, is rejected or times out.
        // target only goes into the log.
        protected async UniTask<bool> ConnectClient(NetworkManager networkManager, string target, CancellationToken token)
        {
            var connectResult = new UniTaskCompletionSource<bool>();
            void HandleConnected(ulong clientId)
            {
                if (clientId == networkManager.LocalClientId) connectResult.TrySetResult(true);
            }
            void HandleStopped(bool wasHost) => connectResult.TrySetResult(false);

            networkManager.OnClientConnectedCallback += HandleConnected;
            networkManager.OnClientStopped += HandleStopped;
            using var timeoutCTS = CancellationTokenSource.CreateLinkedTokenSource(token);
            try
            {
                if (!networkManager.StartClient())
                {
                    EUtils.Logger.LogError($"{LogPrefix} StartClient failed.");
                    return Fail(_settings.JoinFailedReason);
                }

                var timeout = UniTask.WaitForSeconds(_settings.ConnectTimeoutInSeconds, ignoreTimeScale: true, cancellationToken: timeoutCTS.Token)
                    .SuppressCancellationThrow();
                var (winnerIndex, isConnected, _) = await UniTask.WhenAny(connectResult.Task, timeout);

                if (winnerIndex == 0 && isConnected)
                {
                    BeginSession(networkManager);
                    return true;
                }

                if (networkManager.IsListening) networkManager.Shutdown();
                token.ThrowIfCancellationRequested();

                // a rejected approval (e.g. a full lobby) arrives as the disconnect reason
                var reason = winnerIndex == 0
                    ? GetDisconnectReason(networkManager)
                    : string.Format(_settings.JoinTimedOutReasonFormat, _settings.ConnectTimeoutInSeconds);
                EUtils.Logger.LogWarning($"{LogPrefix} Could not join {target}. {reason}");
                return Fail(reason);
            }
            finally
            {
                timeoutCTS.Cancel();
                networkManager.OnClientConnectedCallback -= HandleConnected;
                networkManager.OnClientStopped -= HandleStopped;
            }
        }

        protected void BeginSession(NetworkManager networkManager)
        {
            _sessionNetworkManager = networkManager;
            _isLeaving = false;
            _sessionNetworkManager.OnClientStopped += HandleSessionStopped;
            EUtils.Logger.Log($"{LogPrefix} Session started as {(networkManager.IsHost ? "host" : "client")} (client id {networkManager.LocalClientId}).");
        }

        // Runs once the session's NetworkManager has stopped, before OnDisconnected is raised
        protected virtual void HandleSessionEnded() { }

        private void HandleClientSettled(ulong clientId) => _pendingClientIds.Remove(clientId);

        private void HandleClientDisconnected(ulong clientId)
        {
            _pendingClientIds.Remove(clientId);
            _playerNames.Remove(clientId);
        }

        private int CountTakenSlots()
        {
            var connectedClientIds = _approvingNetworkManager.ConnectedClientsIds;
            int pendingCount = _pendingClientIds.Count;
            foreach (var clientId in connectedClientIds)
            {
                if (_pendingClientIds.Contains(clientId)) pendingCount--;
            }

            return connectedClientIds.Count + pendingCount;
        }

        // Netcode also runs this for the host's own client during StartHost (and always approves it), so the host is let through first
        private void ApproveConnection(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
        {
            bool isHostClient = request.ClientNetworkId == NetworkManager.ServerClientId;
            bool isFull = !isHostClient && CountTakenSlots() >= _hostedMaxPlayers;
            if (!isHostClient && !isFull) _pendingClientIds.Add(request.ClientNetworkId);
            if (!isFull && PlayerNamePayload.TryDecode(request.Payload, out var name)) _playerNames[request.ClientNetworkId] = name;

            response.Approved = !isFull;
            response.Reason = isFull ? _settings.LobbyFullReason : string.Empty;
            response.CreatePlayerObject = false;
            response.Pending = false;
        }

        private void HandleSessionStopped(bool wasHost)
        {
            var reason = _isLeaving ? LeftReason : GetDisconnectReason(_sessionNetworkManager);

            _sessionNetworkManager.OnClientStopped -= HandleSessionStopped;
            _sessionNetworkManager = null;
            _isLeaving = false;
            StopApproving();
            HandleSessionEnded();

            EUtils.Logger.Log($"{LogPrefix} Session ended: {reason}");
            OnDisconnected?.Invoke(reason);
        }

        private static string GetDisconnectReason(NetworkManager networkManager)
        {
            var reason = networkManager.DisconnectReason;
            return string.IsNullOrEmpty(reason) ? StoppedReason : reason;
        }
    }
}
