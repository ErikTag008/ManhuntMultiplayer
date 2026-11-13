using System;

namespace Project.Assets._Project._Scripts.Settings
{
    // Whether the local player is on a gamepad or on keyboard and mouse; key hints show that device's bindings.
    // The local player's input sets it when its control scheme switches.
    public class ControlSchemeState
    {
        private bool _isGamepad;

        public event Action<bool> OnChanged;

        public bool IsGamepad => _isGamepad;

        public void ChangeIsGamepad(bool isGamepad)
        {
            if (_isGamepad == isGamepad) return;

            _isGamepad = isGamepad;
            OnChanged?.Invoke(isGamepad);
        }
    }
}
