using Cysharp.Threading.Tasks;
using System.Threading;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;

namespace Project.Assets._Project._Scripts.Networking
{
    // Direct UnityTransport connection (localhost / LAN); used for development and Multiplayer Play Mode
    public class LocalConnectionService : ConnectionServiceBase
    {
        public LocalConnectionService(ConnectionSettings settings) : base(settings) { }

        // Visibility only matters to the lobby directory; a local host is reachable by address either way
        public override async UniTask<bool> Host(LobbyConfig config, CancellationToken token)
        {
            ClearFailure();
            var networkManager = await GetIdleNetworkManager(token);
            if (networkManager == null) return Fail(_settings.HostFailedReason);

            ConfigureTransport(networkManager, _settings.Address, _settings.Port);
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

        public override async UniTask<bool> Join(string target, CancellationToken token)
        {
            ClearFailure();
            var networkManager = await GetIdleNetworkManager(token);
            if (networkManager == null) return Fail(_settings.JoinFailedReason);

            if (!ConnectionTarget.TryParse(target, _settings.Address, _settings.Port, out var address, out var port))
            {
                return Fail(string.Format(_settings.InvalidAddressReasonFormat, target));
            }
            ConfigureTransport(networkManager, address, port);

            return await ConnectClient(networkManager, $"{address}:{port}", token);
        }

        private void ConfigureTransport(NetworkManager networkManager, string address, ushort port)
        {
            if (networkManager.NetworkConfig.NetworkTransport is UnityTransport transport)
            {
                transport.SetConnectionData(address, port, _settings.ServerListenAddress);
            }
        }
    }
}
