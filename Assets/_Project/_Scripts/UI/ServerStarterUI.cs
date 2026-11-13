using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI.HUD;
using Project.Assets._Project._Scripts.UI.Shared;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI
{
    // Main menu screen (Host Lobby, Join Lobby, Settings, Quit) and the back key for the screens and settings opened from it.
    // The Host/Join screens live on this canvas too; the whole menu goes non-interactable while a host or join runs.
    [RequireComponent(typeof(Canvas))]
    public class ServerStarterUI : MonoBehaviour
    {
        // StartHost opens the Host Lobby screen and StartClient the Join Lobby screen
        [field: SerializeField] public Button StartHostButton { get; private set; }
        [field: SerializeField] public Button StartClientButton { get; private set; }
        [field: SerializeField] public Button SettingsButton { get; private set; }
        [Inject] private readonly SettingsMenuState _settingsMenuState;
        [Inject] private readonly MainMenuState _mainMenuState;
        [Inject] private readonly GameSettingsService _settings;
        [Inject] private readonly KeybindService _keybinds;
        [SerializeField] private Button _quitButton;
        [SerializeField] private FadePanel _mainPanel;
        // on the canvas root, so busy switches off every screen at once
        [SerializeField] private CanvasGroup _menuCanvasGroup;
        [SerializeField] private TMP_Text _statusText;
        [SerializeField] private TMP_Text _disconnectReasonText;
        // Netcode's reasons already read as sentences ("Disconnected due to host shutting down."), so no prefix by default
        [SerializeField] private string _disconnectReasonFormat = "{0}";
        // There is no player here, so the pause key (Esc / Start) goes back from a screen or settings; rebinding still turns it off
        [SerializeField] private string _backActionName = "Pause";

        private InputAction _backAction;
        private bool _isListeningForBack;
        private bool _hasEnabledBackAction;
        private bool _isSettingsOpenedHere;

        private void Start()
        {
            StartHostButton.onClick.AddListener(ShowHostLobby);
            StartClientButton.onClick.AddListener(ShowJoinLobby);
            SettingsButton.onClick.AddListener(OpenSettings);
            _quitButton.onClick.AddListener(Quit);
            _settingsMenuState.OnOpenChanged += HandleSettingsOpenChanged;
            _mainMenuState.OnScreenChanged += HandleScreenChanged;
            _mainMenuState.OnBusyChanged += HandleBusyChanged;
            _mainMenuState.OnStatusChanged += HandleStatusChanged;
            _backAction = _settings.Data.InputActions.FindAction(_backActionName);

            HandleStatusChanged(_mainMenuState.StatusText);
            HandleBusyChanged(_mainMenuState.IsBusy);
            HandleScreenChanged(_mainMenuState.CurrentScreen, _mainMenuState.CurrentScreen);
        }

        private void ShowHostLobby() => _mainMenuState.ShowScreen(MainMenuScreen.HostLobby);

        private void ShowJoinLobby() => _mainMenuState.ShowScreen(MainMenuScreen.JoinLobby);

        private void Quit() => Application.Quit();

        private void OpenSettings()
        {
            _isSettingsOpenedHere = true;
            // automatic navigation crosses canvases, so these buttons must not be reachable from the settings menu
            RefreshMainButtons();
            _settingsMenuState.ToggleOpen(true);
            RefreshBackListening();
        }

        private void HandleSettingsOpenChanged(bool isOpen)
        {
            if (isOpen || !_isSettingsOpenedHere) return;

            _isSettingsOpenedHere = false;
            RefreshBackListening();
            RefreshMainButtons();
            if (IsMainUsable()) SettingsButton.Select();
        }

        private void HandleScreenChanged(MainMenuScreen previous, MainMenuScreen current)
        {
            bool isMain = current == MainMenuScreen.Main;
            if (isMain) _mainPanel.Show();
            else _mainPanel.Hide();

            RefreshMainButtons();
            RefreshBackListening();
            if (!IsMainUsable()) return;

            // a gamepad has no cursor, so focus goes back to the button that opened the screen
            var focus = previous switch
            {
                MainMenuScreen.JoinLobby => StartClientButton,
                _ => StartHostButton
            };
            focus.Select();
        }

        private void HandleBusyChanged(bool isBusy) => _menuCanvasGroup.interactable = !isBusy;

        private void HandleStatusChanged(string text)
        {
            var hasText = !string.IsNullOrEmpty(text);
            _statusText.gameObject.SetActive(hasText);
            _statusText.text = text;
        }

        private void HandleBackPerformed(InputAction.CallbackContext _)
        {
            if (_mainMenuState.IsBusy) return;

            if (_isSettingsOpenedHere) _settingsMenuState.ToggleOpen(false);
            else _mainMenuState.ShowScreen(MainMenuScreen.Main);
        }

        private bool IsMainUsable() => _mainMenuState.CurrentScreen == MainMenuScreen.Main && !_isSettingsOpenedHere;

        private void RefreshBackListening() =>
            ToggleBackListening(_isSettingsOpenedHere || _mainMenuState.CurrentScreen != MainMenuScreen.Main);

        // Only enables the action when nothing else has, so a player's input is never turned off from here
        private void ToggleBackListening(bool isListening)
        {
            if (_backAction == null || _isListeningForBack == isListening) return;

            _isListeningForBack = isListening;
            if (isListening)
            {
                _backAction.performed += HandleBackPerformed;
                _hasEnabledBackAction = !_backAction.enabled;
                if (_hasEnabledBackAction) _backAction.Enable();
            }
            else
            {
                // a running rebind re-enables the action when it ends, so it ends first
                _keybinds.CancelRebind();
                _backAction.performed -= HandleBackPerformed;
                if (_hasEnabledBackAction) _backAction.Disable();
                _hasEnabledBackAction = false;
            }
        }

        // hidden or covered buttons are switched off, because automatic navigation would still reach them
        private void RefreshMainButtons()
        {
            bool isInteractable = IsMainUsable();
            StartHostButton.interactable = isInteractable;
            StartClientButton.interactable = isInteractable;
            SettingsButton.interactable = isInteractable;
            _quitButton.interactable = isInteractable;
        }

        // An empty reason hides the label
        public void ShowDisconnectReason(string reason)
        {
            var hasReason = !string.IsNullOrEmpty(reason);
            _disconnectReasonText.gameObject.SetActive(hasReason);
            _disconnectReasonText.text = hasReason ? string.Format(_disconnectReasonFormat, reason) : string.Empty;
        }

        private void OnDestroy()
        {
            StartHostButton.onClick.RemoveListener(ShowHostLobby);
            StartClientButton.onClick.RemoveListener(ShowJoinLobby);
            SettingsButton.onClick.RemoveListener(OpenSettings);
            _quitButton.onClick.RemoveListener(Quit);
            _settingsMenuState.OnOpenChanged -= HandleSettingsOpenChanged;
            _mainMenuState.OnScreenChanged -= HandleScreenChanged;
            _mainMenuState.OnBusyChanged -= HandleBusyChanged;
            _mainMenuState.OnStatusChanged -= HandleStatusChanged;
            ToggleBackListening(false);
        }
    }
}
