using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // Pause menu: resume, settings, the host's player list and round call-off, and leave behind a confirm. Hidden while settings or the player list cover it.
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
        // host only, while a round runs: sends everyone back to the lobby behind a confirm
        [SerializeField] private Button _returnToLobbyButton;
        [SerializeField] private Button _leaveButton;
        [SerializeField] private ConfirmDialog _confirmDialog;
        [SerializeField] private string _leaveMessage = "Leave the match and go back to the main menu?";
        [SerializeField] private string _hostLeaveMessage = "You are the host.\nLeaving ends the match for everyone.";
        [SerializeField] private string _returnToLobbyMessage = "End this round for everyone and go back to the lobby?\nNobody wins it.";

        private bool _isAskingToReturnToLobby;

        private void Start()
        {
            _state.OnOpenChanged += HandleOpenChanged;
            _state.OnBackRequested += HandleBackRequested;
            _menuButtons.OnBackPressed += HandleMenuBackPressed;
            _settingsMenuState.OnOpenChanged += HandleSettingsOpenChanged;
            _confirmDialog.OnClosed += HandleConfirmClosed;
            _playersMenuState.OnPlayersChanged += RefreshPlayersButton;
            _playersMenu.OnClosed += HandlePlayersMenuClosed;
            _state.OnCanReturnToLobbyChanged += HandleCanReturnToLobbyChanged;
            _returnToLobbyButton.onClick.AddListener(AskToReturnToLobby);
            HandleCanReturnToLobbyChanged(_state.CanReturnToLobby);
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
            _isAskingToReturnToLobby = false;
            // the settings menu asks its own questions in this dialog, and refocuses itself
            if (_state.IsOpen && !_playersMenu.IsOpen && !_settingsMenuState.IsOpen) _leaveButton.Select();
        }

        // the round can end while the menu is open: the button and its question go, and a gamepad keeps a focused button
        private void HandleCanReturnToLobbyChanged(bool canReturnToLobby)
        {
            var eventSystem = EventSystem.current;
            bool wasSelected = eventSystem != null && eventSystem.currentSelectedGameObject == _returnToLobbyButton.gameObject;
            _returnToLobbyButton.gameObject.SetActive(canReturnToLobby);
            if (canReturnToLobby) return;

            if (_isAskingToReturnToLobby) _confirmDialog.Close();
            if (wasSelected && _panel.IsShown) _resumeButton.Select();
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

        private void AskToReturnToLobby()
        {
            _confirmDialog.Open(_returnToLobbyMessage, _state.RequestReturnToLobby);
            _isAskingToReturnToLobby = true;
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
            _state.OnCanReturnToLobbyChanged -= HandleCanReturnToLobbyChanged;
            _returnToLobbyButton.onClick.RemoveListener(AskToReturnToLobby);
            _resumeButton.onClick.RemoveListener(Resume);
            _settingsButton.onClick.RemoveListener(OpenSettings);
            _playersButton.onClick.RemoveListener(OpenPlayers);
            _leaveButton.onClick.RemoveListener(AskToLeave);
        }
    }
}
