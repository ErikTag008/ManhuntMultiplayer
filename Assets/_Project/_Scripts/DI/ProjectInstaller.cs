using Alchemy.Inspector;
using Project.Assets._Project._Scripts.Managers;
using Project.Assets._Project._Scripts.Player;
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
        public void InstallBindings(ContainerBuilder builder)
        {

            // Services that are plain C# classes (POCOs) - RegisterType is correct here
            builder.RegisterType(typeof(SceneLifecycleManager), Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterType(typeof(TeamAssignmentService), new Type[] { typeof(ITeamAssignmentService) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            builder.RegisterType(typeof(UIManager), new Type[] { typeof(IUIManager) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);

            // Services that are MonoBehaviours/NetworkBehaviours - Use Factory to find the instance in the scene
            builder.RegisterFactory(p => FindAnyObjectByType<PlayerRegistry>(), new Type[] { typeof(IPlayerRegistry) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            builder.RegisterFactory(p => FindAnyObjectByType<NetworkCoordinator>(), new Type[] { typeof(INetworkCoordinator) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            builder.RegisterFactory(p => FindAnyObjectByType<GameStateMachine>(), new Type[] { typeof(IGameStateMachine) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            builder.RegisterFactory(p => _playerStats, new Type[] { typeof(PlayerStats), typeof(IMovementStats), typeof(ICameraStats) },Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterFactory(p => _catcherStats, new Type[] { typeof(CatcherStats)},Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager);
            builder.RegisterFactory(p => _runnerStats, new Type[] { typeof(RunnerStats)},Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Eager); 
            builder.RegisterValue(_gameLobbySettings);
            builder.RegisterValue(_gameScenes);
        }
    }
}
