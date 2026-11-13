using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.UI.HUD;
using System;

namespace Project.Assets._Project._Scripts.Managers
{
    // Leaves the session when the player confirms Leave in the pause menu; SessionEndHandler then loads the main menu
    public class PauseMenuLeaveHandler : IDisposable
    {
        private readonly PauseMenuState _pauseMenuState;
        private readonly IConnectionService _connectionService;

        public PauseMenuLeaveHandler(PauseMenuState pauseMenuState, IConnectionService connectionService)
        {
            _pauseMenuState = pauseMenuState;
            _connectionService = connectionService;
            _pauseMenuState.OnLeaveRequested += HandleLeaveRequested;
        }

        private void HandleLeaveRequested()
        {
            _pauseMenuState.ToggleOpen(false);
            _connectionService.Leave();
        }

        public void Dispose() => _pauseMenuState.OnLeaveRequested -= HandleLeaveRequested;
    }
}
