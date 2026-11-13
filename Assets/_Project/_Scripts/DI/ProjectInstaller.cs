using Alchemy.Inspector;
using Project.Assets._Project._Scripts.CameraUtils;
using Project.Assets._Project._Scripts.Managers;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.Player;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.UI;
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
        [SerializeField, AssetsOnly] private ConnectionSettings _connectionSettings;
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
            builder.RegisterType(typeof(PersistentObjectRegistry), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(TeamAssignmentService), new Type[] { typeof(ITeamAssignmentService) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            builder.RegisterType(typeof(WinConditionEvaluator), new Type[] { typeof(IWinConditionEvaluator) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            builder.RegisterType(typeof(UIManager), new Type[] { typeof(IUIManager) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(LocalConnectionService), new Type[] { typeof(IConnectionService) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            // Eager so it listens for disconnects from the first session on
            builder.RegisterType(typeof(SessionEndHandler), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);

            // Network-spawned systems register themselves in GameSystemsRegistry; transient so each resolve sees the live instance
            builder.RegisterFactory(p => p.Resolve<GameSystemsRegistry>().PlayerRegistry, new Type[] { typeof(IPlayerRegistry) }, Reflex.Enums.Lifetime.Transient, Reflex.Enums.Resolution.Lazy);
            builder.RegisterFactory(p => p.Resolve<GameSystemsRegistry>().NetworkCoordinator, new Type[] { typeof(INetworkCoordinator) }, Reflex.Enums.Lifetime.Transient, Reflex.Enums.Resolution.Lazy);
            builder.RegisterFactory(p => p.Resolve<GameSystemsRegistry>().GameStateMachine, new Type[] { typeof(IGameStateMachine) }, Reflex.Enums.Lifetime.Transient, Reflex.Enums.Resolution.Lazy);
            builder.RegisterFactory(p => _playerStats, new Type[] { typeof(PlayerStats), typeof(IMovementStats), typeof(ICameraStats) },Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterFactory(p => _catcherStats, new Type[] { typeof(CatcherStats)},Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterFactory(p => _runnerStats, new Type[] { typeof(RunnerStats)},Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterValue(_gameLobbySettings);
            builder.RegisterValue(_gameScenes);
            builder.RegisterValue(_connectionSettings);
        }
    }
}
