using System;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Whether the settings menu is open; the main menu and the pause menu both open it
    public class SettingsMenuState
    {
        private bool _isOpen;

        public event Action<bool> OnOpenChanged;

        public bool IsOpen => _isOpen;

        public void ToggleOpen(bool isOpen)
        {
            if (_isOpen == isOpen) return;

            _isOpen = isOpen;
            OnOpenChanged?.Invoke(isOpen);
        }
    }
}
