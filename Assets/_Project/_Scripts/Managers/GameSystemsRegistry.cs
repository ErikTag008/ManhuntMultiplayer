using Project.Assets._Project._Scripts.Player;

namespace Project.Assets._Project._Scripts.Managers
{
    public class GameSystemsRegistry
    {
        public IPlayerRegistry PlayerRegistry { get; private set; }
        public INetworkCoordinator NetworkCoordinator { get; private set; }
        public IGameStateMachine GameStateMachine { get; private set; }
        public ISpawnDistributor SpawnDistributor { get; private set; }
        // null for maps that are ready as soon as their scene is
        public IMapLoadGate MapLoadGate { get; private set; }

        public void Register(IPlayerRegistry playerRegistry) => PlayerRegistry = playerRegistry;
        public void Register(INetworkCoordinator networkCoordinator) => NetworkCoordinator = networkCoordinator;
        public void Register(IGameStateMachine gameStateMachine) => GameStateMachine = gameStateMachine;
        public void Register(ISpawnDistributor spawnDistributor) => SpawnDistributor = spawnDistributor;
        public void Register(IMapLoadGate mapLoadGate) => MapLoadGate = mapLoadGate;

        public void Unregister(IPlayerRegistry playerRegistry)
        {
            if (PlayerRegistry == playerRegistry) PlayerRegistry = null;
        }

        public void Unregister(INetworkCoordinator networkCoordinator)
        {
            if (NetworkCoordinator == networkCoordinator) NetworkCoordinator = null;
        }

        public void Unregister(IGameStateMachine gameStateMachine)
        {
            if (GameStateMachine == gameStateMachine) GameStateMachine = null;
        }

        public void Unregister(ISpawnDistributor spawnDistributor)
        {
            if (SpawnDistributor == spawnDistributor) SpawnDistributor = null;
        }

        public void Unregister(IMapLoadGate mapLoadGate)
        {
            if (MapLoadGate == mapLoadGate) MapLoadGate = null;
        }
    }
}
