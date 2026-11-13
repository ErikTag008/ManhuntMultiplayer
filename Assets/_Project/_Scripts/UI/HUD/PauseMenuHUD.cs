using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Pause menu: resume, settings, and leave behind a confirm. Hidden while the settings menu covers it.
    public class PauseMenuHUD : MonoBehaviour
    {
        [Inject] private readonly PauseMenuState _state;
        [Inject] private readonly SettingsMenuState _settingsMenuState;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _leaveButton;
        [SerializeField] private ConfirmDialog _confirmDialog;
        [SerializeField] private string _leaveMessage = "Leave the match and go back to the main menu?";
        [SerializeField] private string _hostLeaveMessage = "You are the host.\nLeaving ends the match for everyone.";

        private void Start()
        {
            _state.OnOpenChanged += HandleOpenChanged;
            _state.OnBackRequested += HandleBackRequested;
            _settingsMenuState.OnOpenChanged += HandleSettingsOpenChanged;
            _confirmDialog.OnClosed += HandleConfirmClosed;
            _resumeButton.onClick.AddListener(Resume);
            _settingsButton.onClick.AddListener(OpenSettings);
            _leaveButton.onClick.AddListener(AskToLeave);
            HandleOpenChanged(_state.IsOpen);
        }

        private void HandleOpenChanged(bool isOpen)
        {
            if (!isOpen)
            {
                _confirmDialog.Close();
                _settingsMenuState.ToggleOpen(false);
            }

            RefreshPanel();
        }

        private void HandleBackRequested()
        {
            if (_confirmDialog.IsOpen) _confirmDialog.Close();
            else if (_settingsMenuState.IsOpen) _settingsMenuState.ToggleOpen(false);
            else _state.ToggleOpen(false);
        }

        private void HandleSettingsOpenChanged(bool _) => RefreshPanel();

        private void HandleConfirmClosed()
        {
            if (_state.IsOpen) _leaveButton.Select();
        }

        // a gamepad has no cursor, so every shown menu focuses a button
        private void RefreshPanel()
        {
            bool isShown = _state.IsOpen && !_settingsMenuState.IsOpen;
            if (isShown == _panel.IsShown) return;

            if (isShown)
            {
                _panel.Show();
                _resumeButton.Select();
            }
            else
            {
                _panel.Hide();
            }
        }

        private void Resume() => _state.ToggleOpen(false);

        private void OpenSettings() => _settingsMenuState.ToggleOpen(true);

        private void AskToLeave() => _confirmDialog.Open(_state.DoesLeavingEndSession ? _hostLeaveMessage : _leaveMessage, _state.RequestLeave);

        private void OnDestroy()
        {
            _state.OnOpenChanged -= HandleOpenChanged;
            _state.OnBackRequested -= HandleBackRequested;
            _settingsMenuState.OnOpenChanged -= HandleSettingsOpenChanged;
            _confirmDialog.OnClosed -= HandleConfirmClosed;
            _resumeButton.onClick.RemoveListener(Resume);
            _settingsButton.onClick.RemoveListener(OpenSettings);
            _leaveButton.onClick.RemoveListener(AskToLeave);
        }
    }
}
