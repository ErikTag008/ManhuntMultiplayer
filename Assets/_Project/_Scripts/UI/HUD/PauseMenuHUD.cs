using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Pause menu: resume, settings, the host's player list, and leave behind a confirm. Hidden while settings or the player list cover it.
    public class PauseMenuHUD : MonoBehaviour
    {
        [Inject] private readonly PauseMenuState _state;
        [Inject] private readonly SettingsMenuState _settingsMenuState;
        [Inject] private readonly MenuButtonInput _menuButtons;
        [Inject] private readonly PlayersMenuState _playersMenuState;
        [SerializeField] private FadePanel _panel;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _settingsButton;
        // host only: opens the player list with the kick buttons
        [SerializeField] private Button _playersButton;
        [SerializeField] private PlayersMenuHUD _playersMenu;
        [SerializeField] private Button _leaveButton;
        [SerializeField] private ConfirmDialog _confirmDialog;
        [SerializeField] private string _leaveMessage = "Leave the match and go back to the main menu?";
        [SerializeField] private string _hostLeaveMessage = "You are the host.\nLeaving ends the match for everyone.";

        private void Start()
        {
            _state.OnOpenChanged += HandleOpenChanged;
            _state.OnBackRequested += HandleBackRequested;
            _menuButtons.OnBackPressed += HandleMenuBackPressed;
            _settingsMenuState.OnOpenChanged += HandleSettingsOpenChanged;
            _confirmDialog.OnClosed += HandleConfirmClosed;
            _playersMenuState.OnPlayersChanged += RefreshPlayersButton;
            _playersMenu.OnClosed += HandlePlayersMenuClosed;
            _resumeButton.onClick.AddListener(Resume);
            _settingsButton.onClick.AddListener(OpenSettings);
            _playersButton.onClick.AddListener(OpenPlayers);
            RefreshPlayersButton();
            _leaveButton.onClick.AddListener(AskToLeave);
            HandleOpenChanged(_state.IsOpen);
        }

        private void HandleOpenChanged(bool isOpen)
        {
            if (!isOpen)
            {
                _confirmDialog.Close();
                _playersMenu.Close();
                _settingsMenuState.ToggleOpen(false);
            }

            RefreshPanel();
        }

        private void HandleBackRequested()
        {
            if (_playersMenu.IsOpen) _playersMenu.Back();
            else if (_confirmDialog.IsOpen) _confirmDialog.Close();
            else if (_settingsMenuState.IsOpen) _settingsMenuState.RequestBack();
            else _state.ToggleOpen(false);
        }

        private void HandleSettingsOpenChanged(bool _) => RefreshPanel();

        // the gamepad's B steps back like the pause key does, while this menu is open
        private void HandleMenuBackPressed()
        {
            if (_state.IsOpen) HandleBackRequested();
        }

        private void HandleConfirmClosed()
        {
            // the settings menu asks its own questions in this dialog, and refocuses itself
            if (_state.IsOpen && !_playersMenu.IsOpen && !_settingsMenuState.IsOpen) _leaveButton.Select();
        }

        private void HandlePlayersMenuClosed()
        {
            RefreshPanel();
            if (_panel.IsShown) _playersButton.Select();
        }

        // only the host can kick, so everyone else never sees the button
        private void RefreshPlayersButton()
        {
            _playersButton.gameObject.SetActive(_playersMenuState.CanKick);
        }

        // a gamepad has no cursor, so every shown menu focuses a button
        private void RefreshPanel()
        {
            bool isShown = _state.IsOpen && !_settingsMenuState.IsOpen && !_playersMenu.IsOpen;
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

        private void OpenPlayers()
        {
            _playersMenu.Open();
            RefreshPanel();
        }

        private void AskToLeave() => _confirmDialog.Open(_state.DoesLeavingEndSession ? _hostLeaveMessage : _leaveMessage, _state.RequestLeave);

        private void OnDestroy()
        {
            _state.OnOpenChanged -= HandleOpenChanged;
            _state.OnBackRequested -= HandleBackRequested;
            _menuButtons.OnBackPressed -= HandleMenuBackPressed;
            _settingsMenuState.OnOpenChanged -= HandleSettingsOpenChanged;
            _confirmDialog.OnClosed -= HandleConfirmClosed;
            _playersMenuState.OnPlayersChanged -= RefreshPlayersButton;
            _playersMenu.OnClosed -= HandlePlayersMenuClosed;
            _resumeButton.onClick.RemoveListener(Resume);
            _settingsButton.onClick.RemoveListener(OpenSettings);
            _playersButton.onClick.RemoveListener(OpenPlayers);
            _leaveButton.onClick.RemoveListener(AskToLeave);
        }
    }
}
