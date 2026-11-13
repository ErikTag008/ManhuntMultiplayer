using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;

namespace Project.Assets._Project._Scripts.Networking
{
    // Direct UnityTransport connection (localhost / LAN); used for development and Multiplayer Play Mode
    public class LocalConnectionService : IConnectionService
    {
        private const string LeftReason = "Left the session";
        private const string StoppedReason = "Connection closed";

        private readonly ConnectionSettings _settings;
        private readonly Action<NetworkManager.ConnectionApprovalRequest, NetworkManager.ConnectionApprovalResponse> _approvalCallback;

        public event Action<string> OnDisconnected;

        private NetworkManager _sessionNetworkManager;
        private NetworkManager _approvingNetworkManager;
        private int _hostedMaxPlayers;
        private bool _isLeaving;
        private string _lastFailureReason;

        public LocalConnectionService(ConnectionSettings settings)
        {
            _settings = settings;
            _approvalCallback = ApproveConnection;
        }

        public bool IsConnected => _sessionNetworkManager != null && _sessionNetworkManager.IsListening;
        public string LastFailureReason => _lastFailureReason;

        // Visibility only matters to the lobby directory; a local host is reachable by address either way
        public async UniTask<bool> Host(LobbyConfig config, CancellationToken token)
        {
            _lastFailureReason = null;
            var networkManager = await GetIdleNetworkManager(token);
            if (networkManager == null) return Fail(_settings.HostFailedReason);

            ConfigureTransport(networkManager, _settings.Address);
            StartApproving(networkManager, config.MaxPlayers);
            if (!networkManager.StartHost())
            {
                StopApproving();
                EUtils.Logger.LogError("[LocalConnectionService] StartHost failed.");
                return Fail(_settings.HostFailedReason);
            }

            BeginSession(networkManager);
            return true;
        }

        public async UniTask<bool> Join(string target, CancellationToken token)
        {
            _lastFailureReason = null;
            var networkManager = await GetIdleNetworkManager(token);
            if (networkManager == null) return Fail(_settings.JoinFailedReason);

            var address = string.IsNullOrWhiteSpace(target) ? _settings.Address : target.Trim();
            ConfigureTransport(networkManager, address);

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
                    EUtils.Logger.LogError("[LocalConnectionService] StartClient failed.");
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
                EUtils.Logger.LogWarning($"[LocalConnectionService] Could not join {address}:{_settings.Port}. {reason}");
                return Fail(reason);
            }
            finally
            {
                timeoutCTS.Cancel();
                networkManager.OnClientConnectedCallback -= HandleConnected;
                networkManager.OnClientStopped -= HandleStopped;
            }
        }

        public void Leave()
        {
            if (!IsConnected) return;

            _isLeaving = true;
            _sessionNetworkManager.Shutdown();
        }

        private bool Fail(string reason)
        {
            _lastFailureReason = reason;
            return false;
        }

        // Shutdown() only completes on Netcode's next network update, so a Host/Join right after a failed join or Leave() waits for it
        private static async UniTask<NetworkManager> GetIdleNetworkManager(CancellationToken token)
        {
            var networkManager = NetworkManager.Singleton;
            if (networkManager == null)
            {
                EUtils.Logger.LogError("[LocalConnectionService] No NetworkManager in the scene.");
                return null;
            }

            if (networkManager.ShutdownInProgress)
            {
                await UniTask.WaitWhile(() => networkManager != null && networkManager.ShutdownInProgress, cancellationToken: token);
                if (networkManager == null) return null;
            }

            if (networkManager.IsListening)
            {
                EUtils.Logger.LogWarning("[LocalConnectionService] Already in a session.");
                return null;
            }

            return networkManager;
        }

        private void ConfigureTransport(NetworkManager networkManager, string address)
        {
            if (networkManager.NetworkConfig.NetworkTransport is UnityTransport transport)
            {
                transport.SetConnectionData(address, _settings.Port, _settings.ServerListenAddress);
            }
        }

        // Needs NetworkConfig.ConnectionApproval on; Netcode warns at StartHost when it's off
        private void StartApproving(NetworkManager networkManager, int maxPlayers)
        {
            StopApproving();
            _approvingNetworkManager = networkManager;
            _hostedMaxPlayers = maxPlayers;
            _approvingNetworkManager.ConnectionApprovalCallback = _approvalCallback;
        }

        private void StopApproving()
        {
            if (_approvingNetworkManager != null && _approvingNetworkManager.ConnectionApprovalCallback == _approvalCallback)
            {
                _approvingNetworkManager.ConnectionApprovalCallback = null;
            }
            _approvingNetworkManager = null;
        }

        // Netcode also runs this for the host's own client during StartHost (and always approves it), so the host is let through first
        private void ApproveConnection(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
        {
            bool isHostClient = request.ClientNetworkId == NetworkManager.ServerClientId;
            bool isFull = !isHostClient && _approvingNetworkManager.ConnectedClientsIds.Count >= _hostedMaxPlayers;

            response.Approved = !isFull;
            response.Reason = isFull ? _settings.LobbyFullReason : string.Empty;
            response.CreatePlayerObject = false;
            response.Pending = false;
        }

        private void BeginSession(NetworkManager networkManager)
        {
            _sessionNetworkManager = networkManager;
            _isLeaving = false;
            _sessionNetworkManager.OnClientStopped += HandleSessionStopped;
            EUtils.Logger.Log($"[LocalConnectionService] Session started as {(networkManager.IsHost ? "host" : "client")} (client id {networkManager.LocalClientId}).");
        }

        private void HandleSessionStopped(bool wasHost)
        {
            var reason = _isLeaving ? LeftReason : GetDisconnectReason(_sessionNetworkManager);

            _sessionNetworkManager.OnClientStopped -= HandleSessionStopped;
            _sessionNetworkManager = null;
            _isLeaving = false;
            StopApproving();

            EUtils.Logger.Log($"[LocalConnectionService] Session ended: {reason}");
            OnDisconnected?.Invoke(reason);
        }

        private static string GetDisconnectReason(NetworkManager networkManager)
        {
            var reason = networkManager.DisconnectReason;
            return string.IsNullOrEmpty(reason) ? StoppedReason : reason;
        }
    }
}
