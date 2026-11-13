using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Controls tab: one row per rebindable action with a keyboard/mouse and a gamepad column.
    // While listening, a prompt blocks clicks and nothing is selected, so the bound key or click can't also press a button.
    public class ControlsSettingsPage : MonoBehaviour
    {
        [Inject] private readonly GameSettingsService _settings;
        [Inject] private readonly KeybindService _keybinds;
        [SerializeField] private Transform _container;
        [SerializeField] private KeybindRow _keybindRowPrefab;
        [SerializeField] private FadePanel _promptPanel;
        [SerializeField] private TMP_Text _promptText;
        [SerializeField] private string _keyboardPromptFormat = "Press a key for <b>{0}</b>\n<size=60%>Esc to cancel</size>";
        [SerializeField] private string _gamepadPromptFormat = "Press a button for <b>{0}</b>\n<size=60%>Wait to cancel</size>";
        // {0} the key, {1} the action that already uses it; shown above the prompt while listening goes on
        [SerializeField] private string _conflictFormat = "<b>{0}</b> is already used by <b>{1}</b>\n";

        private readonly List<KeybindRow> _rows = new();
        private CancellationTokenSource _focusCTS = new();
        private bool _isBuilt;

        private void OnEnable()
        {
            if (!_isBuilt) Build();
            _settings.OnChanged += HandleSettingsChanged;
            Refresh();
        }

        private void Build()
        {
            _isBuilt = true;
            foreach (var entry in _settings.Data.Keybinds)
            {
                var row = Instantiate(_keybindRowPrefab, _container);
                row.Setup(entry.DisplayName);
                row.OnKeyboardClicked += () => StartRebind(entry, row, false);
                row.OnGamepadClicked += () => StartRebind(entry, row, true);
                _rows.Add(row);
            }
        }

        private void StartRebind(KeybindEntry entry, KeybindRow row, bool isGamepad)
        {
            // started first: replacing a running rebind cancels it, and its finish hides the prompt
            if (!_keybinds.StartRebind(entry, isGamepad, () => FinishRebind(row, isGamepad), (control, actionName) => ShowConflict(entry, isGamepad, control, actionName))) return;

            _promptText.text = GetPrompt(entry, isGamepad);
            _promptPanel.Show();
            if (EventSystem.current != null) EventSystem.current.SetSelectedGameObject(null);
        }

        private void ShowConflict(KeybindEntry entry, bool isGamepad, string control, string actionName) =>
            _promptText.text = string.Format(_conflictFormat, control, actionName) + GetPrompt(entry, isGamepad);

        private string GetPrompt(KeybindEntry entry, bool isGamepad) => string.Format(isGamepad ? _gamepadPromptFormat : _keyboardPromptFormat, entry.DisplayName);

        private void FinishRebind(KeybindRow row, bool isGamepad)
        {
            _promptPanel.Hide();
            Refresh();
            RestartCTS(ref _focusCTS);
            FocusNextFrame(row, isGamepad, _focusCTS.Token).Forget();
        }

        // the key that finished the rebind is still in this frame's UI events
        private async UniTaskVoid FocusNextFrame(KeybindRow row, bool isGamepad, CancellationToken token)
        {
            await UniTask.Yield(token);
            if (row != null && isActiveAndEnabled) row.Focus(isGamepad);
        }

        private void HandleSettingsChanged(SettingsCategory category)
        {
            if (category == SettingsCategory.Controls) Refresh();
        }

        private void Refresh()
        {
            var entries = _settings.Data.Keybinds;
            for (int i = 0; i < _rows.Count; i++)
            {
                _rows[i].SetBindingTexts(_keybinds.GetDisplayText(entries[i], false), _keybinds.GetDisplayText(entries[i], true));
            }
        }

        private static void RestartCTS(ref CancellationTokenSource cts)
        {
            cts?.Cancel();
            cts?.Dispose();
            cts = new();
        }

        private void OnDisable()
        {
            _settings.OnChanged -= HandleSettingsChanged;
            _keybinds.CancelRebind();
            _promptPanel.Hide();
        }

        private void OnDestroy()
        {
            _focusCTS?.Cancel();
            _focusCTS?.Dispose();
        }
    }
}
