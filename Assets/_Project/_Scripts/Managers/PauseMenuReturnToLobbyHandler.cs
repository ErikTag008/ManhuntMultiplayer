using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.UI.HUD;
using System;

namespace Project.Assets._Project._Scripts.Managers
{
    // Lets the host call a running round off from the pause menu: the server restarts its loop and everyone loads the lobby.
    // The state machine is network-spawned, so it's looked up when the menu opens and followed while it stays open.
    public class PauseMenuReturnToLobbyHandler : IDisposable
    {
        private readonly PauseMenuState _pauseMenuState;
        private readonly IConnectionService _connectionService;
        private readonly GameSystemsRegistry _gameSystemsRegistry;
        private IGameStateMachine _followedStateMachine;

        public PauseMenuReturnToLobbyHandler(PauseMenuState pauseMenuState, IConnectionService connectionService, GameSystemsRegistry gameSystemsRegistry)
        {
            _pauseMenuState = pauseMenuState;
            _connectionService = connectionService;
            _gameSystemsRegistry = gameSystemsRegistry;
            _pauseMenuState.OnOpenChanged += HandlePauseMenuOpenChanged;
            _pauseMenuState.OnReturnToLobbyRequested += HandleReturnToLobbyRequested;
        }

        private void HandlePauseMenuOpenChanged(bool isOpen)
        {
            StopFollowing();
            if (isOpen && _connectionService.IsHosting) StartFollowing(_gameSystemsRegistry.GameStateMachine);
            Refresh();
        }

        private void HandleStateChanged(GameState _, GameState __) => Refresh();

        private void HandleReturnToLobbyRequested()
        {
            var stateMachine = _gameSystemsRegistry.GameStateMachine;
            if (!_connectionService.IsHosting || stateMachine == null) return;

            _pauseMenuState.ToggleOpen(false);
            if (!stateMachine.TryReturnToLobby()) EUtils.Logger.LogWarning($"[PauseMenuReturnToLobbyHandler] The round can't be called off in {stateMachine.CurrentState}.");
        }

        private void Refresh()
        {
            bool canReturn = _followedStateMachine != null && RoundProgress.CanReturnToLobby(_followedStateMachine.CurrentState);
            _pauseMenuState.ChangeCanReturnToLobby(canReturn);
        }

        private void StartFollowing(IGameStateMachine stateMachine)
        {
            if (stateMachine == null) return;

            _followedStateMachine = stateMachine;
            _followedStateMachine.OnStateChanged += HandleStateChanged;
        }

        private void StopFollowing()
        {
            if (_followedStateMachine == null) return;

            _followedStateMachine.OnStateChanged -= HandleStateChanged;
            _followedStateMachine = null;
        }

        public void Dispose()
        {
            StopFollowing();
            _pauseMenuState.OnOpenChanged -= HandlePauseMenuOpenChanged;
            _pauseMenuState.OnReturnToLobbyRequested -= HandleReturnToLobbyRequested;
        }
    }
}
