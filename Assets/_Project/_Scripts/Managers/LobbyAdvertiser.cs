using Cysharp.Threading.Tasks;
using KBCore.Refs;
using Project.Assets._Project._Scripts.Networking;
using Reflex.Attributes;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    // Server only: keeps this session's advert in the lobby directory up to date while it runs; private lobbies are never listed
    public class LobbyAdvertiser : NetworkBehaviour
    {
        [Inject] private readonly ILobbyDirectory _lobbyDirectory;
        [Inject] private readonly ActiveLobbyConfig _activeLobbyConfig;
        [Inject] private readonly IMapCatalog _mapCatalog;
        [Inject] private readonly ConnectionSettings _connectionSettings;
        [SerializeField, Self] private GameStateMachine _gameStateMachine;

        private readonly LobbyListing _listing = new();
        private CancellationTokenSource _advertCTS;
        private bool _isAdvertising;

        private void OnValidate() => this.ValidateRefs();

        // GameManager injects GameSystems in its own OnNetworkSpawn, so the injected services are only certain to be set here
        protected override void OnNetworkPostSpawn()
        {
            if (!IsServer) return;

            StartAdvertising();
        }

        private void StartAdvertising()
        {
            StopAdvertising();
            _isAdvertising = true;
            _advertCTS = new();
            AdvertLoop(_advertCTS.Token).Forget();
        }

        private void StopAdvertising()
        {
            _advertCTS?.Cancel();
            _advertCTS?.Dispose();
            _advertCTS = null;
            if (!_isAdvertising) return;

            _isAdvertising = false;
            _lobbyDirectory.Unpublish();
        }

        // real time: browsers judge staleness by the wall clock, whatever the time scale is
        private async UniTaskVoid AdvertLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                RefreshAdvert();
                await UniTask.WaitForSeconds(_connectionSettings.AdvertHeartbeatInSeconds, ignoreTimeScale: true, cancellationToken: token);
            }
        }

        // checked every heartbeat, so a lobby turned private later is taken down too
        private void RefreshAdvert()
        {
            var config = _activeLobbyConfig.Config;
            if (config.Visibility == LobbyVisibility.Private)
            {
                _lobbyDirectory.Unpublish();
                return;
            }

            _listing.Name = config.Name.ToString();
            _listing.HostName = SystemInfo.deviceName;
            _listing.MapName = _mapCatalog.GetMapDisplayName(config.MapIndex);
            _listing.PlayerCount = NetworkManager.ConnectedClientsIds.Count;
            _listing.MaxPlayers = config.MaxPlayers;
            _listing.IsInProgress = IsInProgress(_gameStateMachine.CurrentState);
            _listing.Visibility = config.Visibility;
            _listing.Region = _connectionSettings.LocalRegionLabel;
            _listing.PingInMilliseconds = LobbyListing.UnknownPing;
            _listing.Address = _connectionSettings.Address;
            _listing.Port = _connectionSettings.Port;
            _lobbyDirectory.Publish(_listing);
        }

        private static bool IsInProgress(GameState state) => state switch
        {
            GameState.Lobby or GameState.WaitingForPlayers or GameState.Countdown => false,
            _ => true
        };

        public override void OnNetworkDespawn() => StopAdvertising();

        public override void OnDestroy()
        {
            StopAdvertising();
            base.OnDestroy();
        }
    }
}
