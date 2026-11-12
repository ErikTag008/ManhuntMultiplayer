using NUnit.Framework;
using Project.Assets._Project._Scripts.Managers;
using System;

namespace Project.Assets._Project.Tests.EditMode
{
    public class GameSystemsRegistryTests
    {
        private class FakeGameStateMachine : IGameStateMachine
        {
            public GameState CurrentState => GameState.Lobby;
            public RoundResult LastRoundResult => RoundResult.None;
            public event Action<GameState, GameState> OnStateChanged { add { } remove { } }
            public void StartGameLoop() { }
            public void StopGameLoop() { }
            public void RequestGameStart() { }
        }

        [Test]
        public void Register_ExposesInstance()
        {
            var registry = new GameSystemsRegistry();
            var gameStateMachine = new FakeGameStateMachine();

            registry.Register(gameStateMachine);

            Assert.AreSame(gameStateMachine, registry.GameStateMachine);
        }

        [Test]
        public void Unregister_SameInstance_ClearsSlot()
        {
            var registry = new GameSystemsRegistry();
            var gameStateMachine = new FakeGameStateMachine();
            registry.Register(gameStateMachine);

            registry.Unregister(gameStateMachine);

            Assert.IsNull(registry.GameStateMachine);
        }

        [Test]
        public void Unregister_OlderInstance_KeepsNewerOne()
        {
            var registry = new GameSystemsRegistry();
            var older = new FakeGameStateMachine();
            var newer = new FakeGameStateMachine();
            registry.Register(older);
            registry.Register(newer);

            registry.Unregister(older);

            Assert.AreSame(newer, registry.GameStateMachine);
        }

        [Test]
        public void NewRegistry_HasEmptySlots()
        {
            var registry = new GameSystemsRegistry();

            Assert.IsNull(registry.PlayerRegistry);
            Assert.IsNull(registry.NetworkCoordinator);
            Assert.IsNull(registry.GameStateMachine);
            Assert.IsNull(registry.SpawnDistributor);
        }
    }
}
