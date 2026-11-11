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

        public event Action<string> OnDisconnected;

        private NetworkManager _sessionNetworkManager;
        private bool _isLeaving;

        public LocalConnectionService(ConnectionSettings settings)
        {
            _settings = settings;
        }

        public bool IsConnected => _sessionNetworkManager != null && _sessionNetworkManager.IsListening;

        // Visibility only applies to lobby-based services (Steam); a local host is reachable by address
        public UniTask<bool> Host(LobbyVisibility visibility, CancellationToken token)
        {
            if (!TryGetIdleNetworkManager(out var networkManager)) return UniTask.FromResult(false);

            ConfigureTransport(networkManager, _settings.Address);
            if (!networkManager.StartHost())
            {
                EUtils.Logger.LogError("[LocalConnectionService] StartHost failed.");
                return UniTask.FromResult(false);
            }

            BeginSession(networkManager);
            return UniTask.FromResult(true);
        }

        public async UniTask<bool> Join(string target, CancellationToken token)
        {
            if (!TryGetIdleNetworkManager(out var networkManager)) return false;

            var address = string.IsNullOrWhiteSpace(target) ? _settings.Address : target;
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
                    return false;
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

                var reason = winnerIndex == 0 ? GetDisconnectReason(networkManager) : $"Timed out after {_settings.ConnectTimeoutInSeconds}s";
                EUtils.Logger.LogWarning($"[LocalConnectionService] Could not join {address}:{_settings.Port}. {reason}");
                return false;
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

        private static bool TryGetIdleNetworkManager(out NetworkManager networkManager)
        {
            networkManager = NetworkManager.Singleton;
            if (networkManager == null)
            {
                EUtils.Logger.LogError("[LocalConnectionService] No NetworkManager in the scene.");
                return false;
            }

            if (networkManager.IsListening)
            {
                EUtils.Logger.LogWarning("[LocalConnectionService] Already in a session.");
                return false;
            }

            return true;
        }

        private void ConfigureTransport(NetworkManager networkManager, string address)
        {
            if (networkManager.NetworkConfig.NetworkTransport is UnityTransport transport)
            {
                transport.SetConnectionData(address, _settings.Port, _settings.ServerListenAddress);
            }
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
