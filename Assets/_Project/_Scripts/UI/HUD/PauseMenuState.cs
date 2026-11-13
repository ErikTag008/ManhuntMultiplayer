using System;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // The pause menu's state and its leave request. The local player opens and closes it; a session handler leaves.
    // Nothing actually pauses: the match keeps running for everyone else.
    public class PauseMenuState
    {
        private bool _isOpen;
        private bool _doesLeavingEndSession;

        public event Action<bool> OnOpenChanged;
        public event Action OnLeaveRequested;
        // the pause key while open: the menu closes its topmost layer (dialog, settings, then itself)
        public event Action OnBackRequested;

        public bool IsOpen => _isOpen;
        // the host leaving shuts the session down for every player, so the confirm text warns about it
        public bool DoesLeavingEndSession => _doesLeavingEndSession;

        public void ToggleOpen(bool isOpen)
        {
            if (_isOpen == isOpen) return;

            _isOpen = isOpen;
            OnOpenChanged?.Invoke(isOpen);
        }

        public void ChangeDoesLeavingEndSession(bool doesLeavingEndSession) => _doesLeavingEndSession = doesLeavingEndSession;

        public void RequestLeave() => OnLeaveRequested?.Invoke();

        public void RequestBack() => OnBackRequested?.Invoke();
    }
}
