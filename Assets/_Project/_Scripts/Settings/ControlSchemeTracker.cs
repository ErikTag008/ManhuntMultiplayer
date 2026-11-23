using System;
using UnityEngine.InputSystem;

namespace Project.Assets._Project._Scripts.Settings
{
    // Follows the device behind every performed action, menus included, so key hints switch between keyboard and gamepad
    // even where there is no local player yet (main menu) or while its gameplay actions are off.
    public class ControlSchemeTracker : IDisposable
    {
        private readonly ControlSchemeState _controlScheme;

        public ControlSchemeTracker(ControlSchemeState controlScheme)
        {
            _controlScheme = controlScheme;
            InputSystem.onActionChange += HandleActionChange;
        }

        private void HandleActionChange(object target, InputActionChange change)
        {
            if (change != InputActionChange.ActionPerformed || target is not InputAction action) return;

            var control = action.activeControl;
            if (control == null) return;

            _controlScheme.ChangeIsGamepad(control.device is Gamepad || control.device is Joystick);
        }

        public void Dispose() => InputSystem.onActionChange -= HandleActionChange;
    }
}
