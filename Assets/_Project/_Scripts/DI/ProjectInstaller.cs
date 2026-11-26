using Alchemy.Inspector;
using Project.Assets._Project._Scripts.CameraUtils;
using Project.Assets._Project._Scripts.Cosmetics;
using Project.Assets._Project._Scripts.Managers;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.Player;
using Project.Assets._Project._Scripts.Player.Abilities;
using Project.Assets._Project._Scripts.Player.Drops;
using Project.Assets._Project._Scripts.Player.Emotes;
using Project.Assets._Project._Scripts.Player.Stations;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.SceneFlow.Maps;
using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI;
using Project.Assets._Project._Scripts.UI.HUD;
using Project.Assets._Project._Scripts.Voice;
using Reflex.Core;
using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.DI
{
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField, AssetsOnly] private PlayerStats _playerStats;
        [SerializeField, AssetsOnly] private CatcherStats _catcherStats;
        [SerializeField, AssetsOnly] private RunnerStats _runnerStats;
        [SerializeField, AssetsOnly] private GameLobbySettings _gameLobbySettings;
        [SerializeField, AssetsOnly] private GameScenes _gameScenes;
        [SerializeField, AssetsOnly] private MapLibrarySettings _mapLibrarySettings;
        [SerializeField, AssetsOnly] private ConnectionSettings _connectionSettings;
        [SerializeField, AssetsOnly] private LobbyConfigData _lobbyConfigData;
        [SerializeField, AssetsOnly] private AbilityCatalog _abilityCatalog;
        [SerializeField, AssetsOnly] private EmoteCatalog _emoteCatalog;
        [SerializeField, AssetsOnly] private DropCatalog _dropCatalog;
        [SerializeField, AssetsOnly] private StationSettings _stationSettings;
        [SerializeField, AssetsOnly] private GhostSettings _ghostSettings;
        [SerializeField, AssetsOnly] private SettingsData _settingsData;
        [SerializeField, AssetsOnly] private CosmeticCatalog _cosmeticCatalog;
        [SerializeField, AssetsOnly] private PointRewards _pointRewards;
        public void InstallBindings(ContainerBuilder builder)
        {

            // Services that are plain C# classes (POCOs) - RegisterType is correct here
            builder.RegisterType(typeof(SceneLifecycleManager), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(GameSystemsRegistry), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(ActiveCameraProvider), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(SceneContextProvider), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(PlayerSessionDirectory), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(SpawnedPlayerDirectory), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(HidePhase), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(HuntPhase), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(StationDirectory), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(GhostPingDirectory), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(GameHUDState), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(LobbyMenuState), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(PauseMenuState), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(PlayersMenuState), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(IncomingInviteState), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(EmoteWheelState), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(SettingsMenuState), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            // Eager so saved settings and key bindings are loaded before the first player or camera reads them
            builder.RegisterType(typeof(GameSettingsService), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(KeybindService), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(ControlSchemeState), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(ControlSchemeTracker), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(MenuButtonInput), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            // Eager so the saved loadout is loaded before the local player spawns and sends it
            builder.RegisterType(typeof(CosmeticProfileService), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(PersistentObjectRegistry), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(TeamAssignmentService), new Type[] { typeof(ITeamAssignmentService) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            builder.RegisterType(typeof(WinConditionEvaluator), new Type[] { typeof(IWinConditionEvaluator) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            builder.RegisterType(typeof(UIManager), new Type[] { typeof(IUIManager) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            // Eager so Steam is up (and its join requests are caught) before the main menu starts; does nothing outside Steam mode
            builder.RegisterType(typeof(SteamPlatform), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            bool isSteamMode = _connectionSettings.ResolvedMode == ConnectionMode.Steam;
            var connectionServiceType = isSteamMode ? typeof(SteamConnectionService) : typeof(LocalConnectionService);
            builder.RegisterType(connectionServiceType, new Type[] { typeof(IConnectionService) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            builder.RegisterType(typeof(FriendAvatarCache), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            var lobbyDirectoryType = isSteamMode ? typeof(SteamLobbyDirectory) : typeof(LocalLobbyDirectory);
            builder.RegisterType(lobbyDirectoryType, new Type[] { typeof(ILobbyDirectory) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            var voiceChatType = isSteamMode ? typeof(SteamVoiceChat) : typeof(DisabledVoiceChat);
            builder.RegisterType(voiceChatType, new Type[] { typeof(IVoiceChat) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            builder.RegisterType(typeof(VoiceMuteList), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(ActiveLobbyConfig), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            // Eager so it listens for disconnects from the first session on
            builder.RegisterType(typeof(SessionEndHandler), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(PauseMenuLeaveHandler), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(PauseMenuReturnToLobbyHandler), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(PlayerKickHandler), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            // Eager so invites that arrive in the main menu are already caught
            builder.RegisterType(typeof(LobbyInviteHandler), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(LocalMapLibrary), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            // built-in maps plus local bundle maps; a connected client mirrors the server's list
            builder.RegisterType(typeof(SessionMapCatalog), new Type[] { typeof(SessionMapCatalog), typeof(IMapCatalog) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            // server only: which maps every connected client has, so a pick never drops a client
            builder.RegisterType(typeof(MapAvailability), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            // in-map stations take this instead of the GameSystems factories below, which are still null while a joiner's map loads
            builder.RegisterType(typeof(StationRewards), new Type[] { typeof(IStationRewards) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);

            // Network-spawned systems register themselves in GameSystemsRegistry; transient so each resolve sees the live instance
            builder.RegisterFactory(p => p.Resolve<GameSystemsRegistry>().PlayerRegistry, new Type[] { typeof(IPlayerRegistry) }, Reflex.Enums.Lifetime.Transient, Reflex.Enums.Resolution.Lazy);
            builder.RegisterFactory(p => p.Resolve<GameSystemsRegistry>().NetworkCoordinator, new Type[] { typeof(INetworkCoordinator) }, Reflex.Enums.Lifetime.Transient, Reflex.Enums.Resolution.Lazy);
            builder.RegisterFactory(p => p.Resolve<GameSystemsRegistry>().GameStateMachine, new Type[] { typeof(IGameStateMachine), typeof(IRoundTimer) }, Reflex.Enums.Lifetime.Transient, Reflex.Enums.Resolution.Lazy);
            builder.RegisterFactory(p => _playerStats, new Type[] { typeof(PlayerStats), typeof(IMovementStats), typeof(ICameraStats) },Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterFactory(p => _catcherStats, new Type[] { typeof(CatcherStats)},Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterFactory(p => _runnerStats, new Type[] { typeof(RunnerStats)},Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterValue(_gameLobbySettings);
            builder.RegisterValue(_gameScenes);
            builder.RegisterValue(_mapLibrarySettings);
            builder.RegisterValue(_connectionSettings);
            builder.RegisterValue(_lobbyConfigData);
            builder.RegisterValue(_abilityCatalog);
            builder.RegisterValue(_emoteCatalog);
            builder.RegisterValue(_dropCatalog);
            builder.RegisterValue(_stationSettings);
            builder.RegisterValue(_ghostSettings);
            builder.RegisterValue(_settingsData);
            builder.RegisterValue(_cosmeticCatalog);
            builder.RegisterValue(_pointRewards);
        }
    }
}
