using System;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // The pause menu's state and its leave and return-to-lobby requests. The local player opens and closes it; a session handler leaves.
    // Nothing actually pauses: the match keeps running for everyone else.
    public class PauseMenuState
    {
        private bool _isOpen;
        private bool _doesLeavingEndSession;
        private bool _canReturnToLobby;

        public event Action<bool> OnOpenChanged;
        public event Action OnLeaveRequested;
        public event Action<bool> OnCanReturnToLobbyChanged;
        public event Action OnReturnToLobbyRequested;
        // the pause key while open: the menu closes its topmost layer (dialog, settings, then itself)
        public event Action OnBackRequested;

        public bool IsOpen => _isOpen;
        // the host leaving shuts the session down for every player, so the confirm text warns about it
        public bool DoesLeavingEndSession => _doesLeavingEndSession;
        // only the host, and only while a round runs, can send everyone back to the lobby
        public bool CanReturnToLobby => _canReturnToLobby;

        public void ToggleOpen(bool isOpen)
        {
            if (_isOpen == isOpen) return;

            _isOpen = isOpen;
            OnOpenChanged?.Invoke(isOpen);
        }

        public void ChangeDoesLeavingEndSession(bool doesLeavingEndSession) => _doesLeavingEndSession = doesLeavingEndSession;

        public void RequestLeave() => OnLeaveRequested?.Invoke();

        public void ChangeCanReturnToLobby(bool canReturnToLobby)
        {
            if (_canReturnToLobby == canReturnToLobby) return;

            _canReturnToLobby = canReturnToLobby;
            OnCanReturnToLobbyChanged?.Invoke(canReturnToLobby);
        }

        public void RequestReturnToLobby()
        {
            if (_canReturnToLobby) OnReturnToLobbyRequested?.Invoke();
        }

        public void RequestBack() => OnBackRequested?.Invoke();
    }
}
