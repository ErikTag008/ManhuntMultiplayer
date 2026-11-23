using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Project.Assets._Project._Scripts.Settings
{
    // Gamepad menu buttons that aren't rebindable: back (B) and previous/next tab (LB/RB). Menus listen and act only while they are open.
    // Each fires on release, and only when the press didn't start during a rebind, so the button that finishes a rebind can't also close or switch the menu.
    public class MenuButtonInput : IDisposable
    {
        private const int PreviousStep = -1;
        private const int NextStep = 1;

        private readonly KeybindService _keybinds;
        private readonly InputAction _backAction;
        private readonly InputAction _previousTabAction;
        private readonly InputAction _nextTabAction;
        private readonly HashSet<InputAction> _armedActions = new();
        private readonly List<Action> _backClaims = new();

        public event Action OnBackPressed;
        // -1 previous, +1 next
        public event Action<int> OnTabStepped;

        public MenuButtonInput(SettingsData data, KeybindService keybinds)
        {
            _keybinds = keybinds;
            _backAction = CreateAction(data.MenuBackBinding);
            _previousTabAction = CreateAction(data.PreviousTabBinding);
            _nextTabAction = CreateAction(data.NextTabBinding);
        }

        // a popup over the menus takes B for itself while it is up: the latest claim gets the press and the menus behind never see it
        public void ClaimBack(Action handler)
        {
            if (!_backClaims.Contains(handler)) _backClaims.Add(handler);
        }

        public void ReleaseBack(Action handler) => _backClaims.Remove(handler);

        private InputAction CreateAction(string binding)
        {
            var action = new InputAction(type: InputActionType.Button, binding: binding);
            action.performed += HandlePressed;
            action.canceled += HandleReleased;
            action.Enable();
            return action;
        }

        private void HandlePressed(InputAction.CallbackContext context)
        {
            if (_keybinds.IsRebinding) _armedActions.Remove(context.action);
            else _armedActions.Add(context.action);
        }

        private void HandleReleased(InputAction.CallbackContext context)
        {
            if (!_armedActions.Remove(context.action) || _keybinds.IsRebinding) return;

            if (context.action == _backAction) PressBack();
            else OnTabStepped?.Invoke(context.action == _previousTabAction ? PreviousStep : NextStep);
        }

        private void PressBack()
        {
            if (_backClaims.Count > 0) _backClaims[^1].Invoke();
            else OnBackPressed?.Invoke();
        }

        public void Dispose()
        {
            DisposeAction(_backAction);
            DisposeAction(_previousTabAction);
            DisposeAction(_nextTabAction);
        }

        private void DisposeAction(InputAction action)
        {
            action.performed -= HandlePressed;
            action.canceled -= HandleReleased;
            action.Dispose();
        }
    }
}
