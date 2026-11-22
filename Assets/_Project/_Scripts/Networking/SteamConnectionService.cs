using Cysharp.Threading.Tasks;
using Steamworks;
using Steamworks.Data;
using System.Globalization;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Networking
{
    // Hosting creates a Steam lobby and a relay socket; joining enters the lobby and connects to its host's SteamId.
    // Friends join through the overlay invite or "Join Game", which SteamPlatform reports.
    public class SteamConnectionService : ConnectionServiceBase
    {
        private readonly SteamPlatform _steamPlatform;

        public SteamConnectionService(ConnectionSettings settings, SteamPlatform steamPlatform) : base(settings)
        {
            _steamPlatform = steamPlatform;
        }

        public override bool CanInviteFriends => _steamPlatform.IsReady && _steamPlatform.CurrentLobby.HasValue && IsConnected;
        public override string JoinCode => CanInviteFriends ? SteamLobbyId.FormatCode(_steamPlatform.CurrentLobby.Value.Id.Value) : null;

        public override async UniTask<bool> Host(LobbyConfig config, CancellationToken token)
        {
            ClearFailure();
            if (!_steamPlatform.IsReady) return Fail(_steamPlatform.FailureReason ?? _settings.SteamNotRunningReason);

            var networkManager = await GetIdleNetworkManager(token);
            if (networkManager == null) return Fail(_settings.HostFailedReason);

            var createdLobby = await SteamMatchmaking.CreateLobbyAsync(config.MaxPlayers);
            if (!createdLobby.HasValue)
            {
                EUtils.Logger.LogError("[SteamConnectionService] Could not create the Steam lobby.");
                return Fail(_settings.HostFailedReason);
            }

            _steamPlatform.SetCurrentLobby(createdLobby);
            if (token.IsCancellationRequested || networkManager == null)
            {
                LeaveLobby();
                token.ThrowIfCancellationRequested();
                return Fail(_settings.HostFailedReason);
            }

            var lobby = createdLobby.Value;
            lobby.SetData(SteamLobbyData.HostSteamIdKey, SteamLobbyId.Format(_steamPlatform.LocalSteamId));
            lobby.SetData(SteamLobbyData.VersionKey, Application.version);
            lobby.SetData(SteamLobbyData.InProgressKey, SteamLobbyData.FalseValue);
            lobby.SetData(SteamLobbyData.GameKey, _settings.SteamLobbyGameId);
            lobby.SetData(SteamLobbyData.HostNameKey, _steamPlatform.LocalName);
            lobby.SetData(SteamLobbyData.CountryKey, SteamUtils.IpCountry ?? string.Empty);
            ApplyLobbyData(lobby, config);
            // nobody may enter until the relay socket is listening
            lobby.SetJoinable(false);

            UseSteamTransport(networkManager);
            StartApproving(networkManager, config.MaxPlayers);
            bool isHosting = false;
            try
            {
                isHosting = networkManager.StartHost();
            }
            finally
            {
                if (!isHosting)
                {
                    StopApproving();
                    LeaveLobby();
                    EUtils.Logger.LogError("[SteamConnectionService] StartHost failed.");
                }
            }
            if (!isHosting) return Fail(_settings.HostFailedReason);

            ApplyLobbyVisibility(lobby, config.Visibility);
            lobby.SetJoinable(true);
            BeginSession(networkManager);
            return true;
        }

        public override async UniTask<bool> Join(string target, CancellationToken token)
        {
            ClearFailure();
            if (!_steamPlatform.IsReady) return Fail(_steamPlatform.FailureReason ?? _settings.SteamNotRunningReason);
            if (!SteamLobbyId.TryParse(target, out var lobbyId)) return Fail(string.Format(_settings.InvalidLobbyIdReasonFormat, target));

            var networkManager = await GetIdleNetworkManager(token);
            if (networkManager == null) return Fail(_settings.JoinFailedReason);

            var lobby = new Lobby(lobbyId);
            var enterResult = await lobby.Join();
            if (enterResult != RoomEnter.Success)
            {
                EUtils.Logger.LogWarning($"[SteamConnectionService] Could not enter lobby {lobbyId}: {enterResult}");
                return Fail(GetRoomEnterReason(enterResult));
            }

            _steamPlatform.SetCurrentLobby(lobby);
            bool isJoined = false;
            try
            {
                token.ThrowIfCancellationRequested();
                ulong hostSteamId = GetHostSteamId(lobby);
                if (networkManager == null || hostSteamId == 0) return Fail(_settings.JoinFailedReason);

                UseSteamTransport(networkManager).SetHostSteamId(hostSteamId);
                isJoined = await ConnectClient(networkManager, SteamLobbyId.Format(lobbyId), token);
                return isJoined;
            }
            finally
            {
                if (!isJoined) LeaveLobby();
            }
        }

        public override void UpdateHostedLobby(LobbyConfig config)
        {
            base.UpdateHostedLobby(config);
            var lobby = _steamPlatform.CurrentLobby;
            if (!IsHosting || !lobby.HasValue || !_steamPlatform.IsReady) return;

            ApplyLobbyData(lobby.Value, config);
            ApplyLobbyVisibility(lobby.Value, config.Visibility);
        }

        public override bool TryOpenInviteDialog()
        {
            if (!CanInviteFriends || !SteamUtils.IsOverlayEnabled) return false;

            SteamFriends.OpenGameInviteOverlay(_steamPlatform.CurrentLobby.Value.Id);
            return true;
        }

        // Clients leave the lobby too once the host is gone, so a later invite doesn't find them still inside
        protected override void HandleSessionEnded() => LeaveLobby();

        private static void ApplyLobbyData(Lobby lobby, LobbyConfig config)
        {
            lobby.MaxMembers = config.MaxPlayers;
            lobby.SetData(SteamLobbyData.NameKey, config.Name.ToString());
            lobby.SetData(SteamLobbyData.MapIndexKey, config.MapIndex.ToString(CultureInfo.InvariantCulture));
            lobby.SetData(SteamLobbyData.ModeKey, config.Mode.ToString());
            lobby.SetData(SteamLobbyData.VisibilityKey, config.Visibility.ToString());
        }

        // private lobbies are never returned by searches; only invites get in
        private static void ApplyLobbyVisibility(Lobby lobby, LobbyVisibility visibility)
        {
            switch (visibility)
            {
                case LobbyVisibility.Public:
                    lobby.SetPublic();
                    break;
                case LobbyVisibility.FriendsOnly:
                    lobby.SetFriendsOnly();
                    break;
                default:
                    lobby.SetPrivate();
                    break;
            }
        }

        // The NetworkManager's own transport stays as it is in the scene; the Steam one is added next to it at runtime
        private SteamRelayTransport UseSteamTransport(NetworkManager networkManager)
        {
            if (!networkManager.TryGetComponent(out SteamRelayTransport transport)) transport = networkManager.gameObject.AddComponent<SteamRelayTransport>();

            networkManager.NetworkConfig.NetworkTransport = transport;
            networkManager.NetworkConfig.ConnectionData = PlayerNamePayload.Encode(_steamPlatform.LocalName);
            return transport;
        }

        // the host writes its id into the lobby; the owner can change hands when the host leaves first
        private static ulong GetHostSteamId(Lobby lobby) =>
            SteamLobbyId.TryParse(lobby.GetData(SteamLobbyData.HostSteamIdKey), out var hostSteamId) ? hostSteamId : lobby.Owner.Id.Value;

        private string GetRoomEnterReason(RoomEnter result) => result switch
        {
            RoomEnter.DoesntExist => _settings.LobbyNotFoundReason,
            RoomEnter.Full => _settings.LobbyFullReason,
            RoomEnter.NotAllowed or RoomEnter.Banned => _settings.JoinDeniedReason,
            _ => _settings.JoinFailedReason
        };

        private void LeaveLobby()
        {
            var lobby = _steamPlatform.CurrentLobby;
            if (!lobby.HasValue) return;

            if (_steamPlatform.IsReady) lobby.Value.Leave();
            _steamPlatform.SetCurrentLobby(null);
        }
    }
}
