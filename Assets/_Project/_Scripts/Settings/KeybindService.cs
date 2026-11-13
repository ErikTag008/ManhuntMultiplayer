using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Project.Assets._Project._Scripts.Settings
{
    // Rebinds the project's input actions and keeps the overrides in the settings.
    // A single local PlayerInput uses this asset directly; a copied asset gets the overrides through ApplyTo.
    public class KeybindService : IDisposable
    {
        private readonly GameSettingsService _settings;
        private readonly SettingsData _data;
        private readonly List<InputAction> _actionsToReenable = new();

        private InputActionRebindingExtensions.RebindingOperation _rebindOperation;

        public bool IsRebinding => _rebindOperation != null;

        public KeybindService(GameSettingsService settings)
        {
            _settings = settings;
            _data = settings.Data;
            ApplyTo(_data.InputActions);
        }

        public void ApplyTo(InputActionAsset actions)
        {
            if (actions == null) return;

            actions.RemoveAllBindingOverrides();
            var json = _settings.Values.BindingOverridesJson;
            if (!string.IsNullOrEmpty(json)) actions.LoadBindingOverridesFromJson(json);
        }

        public string GetDisplayText(KeybindEntry entry, bool isGamepad) =>
            TryGetBinding(entry, isGamepad, out var action, out int bindingIndex) ? action.GetBindingDisplayString(bindingIndex) : string.Empty;

        // A plain action's first binding for the device, for key hints outside the settings menu; empty when it has none
        public string GetDisplayText(InputActionReference actionReference, bool isGamepad)
        {
            var action = FindAction(actionReference);
            return action != null && TryFindBindingIndex(action, null, isGamepad, out int bindingIndex) ? action.GetBindingDisplayString(bindingIndex) : string.Empty;
        }

        public bool HasBinding(KeybindEntry entry, bool isGamepad) => TryGetBinding(entry, isGamepad, out _, out _);

        // Every action is off while listening, so the pressed key can't also pause, jump or attack.
        // A key another action already uses is not applied: onConflict gets (key, action name) and listening goes on.
        // False when the entry has no such binding; onFinished then never runs.
        public bool StartRebind(KeybindEntry entry, bool isGamepad, Action onFinished, Action<string, string> onConflict)
        {
            CancelRebind();
            if (!TryGetBinding(entry, isGamepad, out var action, out int bindingIndex)) return false;

            DisableAllActions();
            Listen(entry, action, bindingIndex, isGamepad, onFinished, onConflict);
            return true;
        }

        public void CancelRebind() => _rebindOperation?.Cancel();

        public void ResetAll()
        {
            CancelRebind();
            _data.InputActions.RemoveAllBindingOverrides();
            SaveOverrides();
        }

        private void Listen(KeybindEntry entry, InputAction action, int bindingIndex, bool isGamepad, Action onFinished, Action<string, string> onConflict)
        {
            string conflictControl = null;
            string conflictActionName = null;
            _rebindOperation = action.PerformInteractiveRebinding(bindingIndex)
                .WithCancelingThrough(_data.RebindCancelPath)
                .WithTimeout(_data.RebindTimeoutInSeconds)
                .OnMatchWaitForAnother(0f)
                .OnApplyBinding((_, path) =>
                {
                    if (TryFindConflict(entry, action, bindingIndex, path, isGamepad, out conflictControl, out conflictActionName)) return;

                    action.ApplyBindingOverride(bindingIndex, path);
                })
                .OnComplete(_ =>
                {
                    if (conflictActionName == null)
                    {
                        FinishRebind(true, onFinished);
                        return;
                    }

                    // actions stay off; the same binding listens again
                    DisposeOperation();
                    Listen(entry, action, bindingIndex, isGamepad, onFinished, onConflict);
                    onConflict?.Invoke(conflictControl, conflictActionName);
                })
                .OnCancel(_ => FinishRebind(false, onFinished));

            foreach (var path in isGamepad ? _data.GamepadRebindPaths : _data.KeyboardMouseRebindPaths) _rebindOperation.WithControlsHavingToMatchPath(path);
            foreach (var path in _data.ExcludedRebindPaths) _rebindOperation.WithControlsExcluding(path);

            _rebindOperation.Start();
        }

        // Any other binding of the same device group in the action's map, rebindable or not (e.g. Pause on Start), unless both rows share a group
        private bool TryFindConflict(KeybindEntry entry, InputAction action, int bindingIndex, string path, bool isGamepad, out string control, out string actionName)
        {
            control = null;
            actionName = null;
            var mask = InputBinding.MaskByGroup(isGamepad ? _data.GamepadGroup : _data.KeyboardMouseGroup);
            foreach (var other in action.actionMap.actions)
            {
                var bindings = other.bindings;
                for (int i = 0; i < bindings.Count; i++)
                {
                    if (other == action && i == bindingIndex) continue;

                    var binding = bindings[i];
                    if (binding.isComposite || !mask.Matches(binding)) continue;
                    if (!string.Equals(binding.effectivePath, path, StringComparison.OrdinalIgnoreCase)) continue;

                    var otherEntry = FindEntry(other, i, isGamepad);
                    if (entry.CanShareKeyWith(otherEntry)) continue;

                    control = other.GetBindingDisplayString(i);
                    actionName = otherEntry != null ? otherEntry.DisplayName : other.name;
                    return true;
                }
            }

            return false;
        }

        // The settings row for a binding; null when the binding isn't rebindable
        private KeybindEntry FindEntry(InputAction action, int bindingIndex, bool isGamepad)
        {
            foreach (var entry in _data.Keybinds)
            {
                if (TryGetBinding(entry, isGamepad, out var entryAction, out int entryIndex) && entryAction == action && entryIndex == bindingIndex) return entry;
            }

            return null;
        }

        private void DisposeOperation()
        {
            _rebindOperation?.Dispose();
            _rebindOperation = null;
        }

        private void FinishRebind(bool isCompleted, Action onFinished)
        {
            DisposeOperation();
            ReenableActions();
            if (isCompleted) SaveOverrides();
            onFinished?.Invoke();
        }

        private void SaveOverrides()
        {
            var json = _data.InputActions.SaveBindingOverridesAsJson();
            _settings.Change(SettingsCategory.Controls, values => values.BindingOverridesJson = json);
        }

        private bool TryGetBinding(KeybindEntry entry, bool isGamepad, out InputAction action, out int bindingIndex)
        {
            action = FindAction(entry.Action);
            bindingIndex = -1;
            if (action == null || (isGamepad && !entry.HasGamepadBinding)) return false;

            return TryFindBindingIndex(action, entry.CompositePart, isGamepad, out bindingIndex);
        }

        // The rebound asset's copy of the action, so the text shows the player's overrides
        private InputAction FindAction(InputActionReference actionReference) =>
            actionReference != null && actionReference.action != null ? _data.InputActions.FindAction(actionReference.action.id) : null;

        private bool TryFindBindingIndex(InputAction action, string compositePart, bool isGamepad, out int bindingIndex)
        {
            bindingIndex = -1;
            var group = isGamepad ? _data.GamepadGroup : _data.KeyboardMouseGroup;
            bool hasPart = !string.IsNullOrEmpty(compositePart);
            var bindings = action.bindings;
            for (int i = 0; i < bindings.Count; i++)
            {
                var binding = bindings[i];
                if (binding.isComposite) continue;
                if (hasPart != binding.isPartOfComposite) continue;
                if (hasPart && !string.Equals(binding.name, compositePart, StringComparison.OrdinalIgnoreCase)) continue;
                if (!InputBinding.MaskByGroup(group).Matches(binding)) continue;

                bindingIndex = i;
                return true;
            }

            return false;
        }

        private void DisableAllActions()
        {
            _actionsToReenable.Clear();
            foreach (var action in _data.InputActions)
            {
                if (!action.enabled) continue;

                _actionsToReenable.Add(action);
                action.Disable();
            }
        }

        private void ReenableActions()
        {
            foreach (var action in _actionsToReenable) action.Enable();
            _actionsToReenable.Clear();
        }

        public void Dispose()
        {
            _rebindOperation?.Cancel();
            _rebindOperation?.Dispose();
        }
    }
}
