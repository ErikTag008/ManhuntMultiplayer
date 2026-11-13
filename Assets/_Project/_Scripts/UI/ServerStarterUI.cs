using Project.Assets._Project._Scripts.Settings;
using Project.Assets._Project._Scripts.UI.HUD;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI
{
    [RequireComponent(typeof(Canvas))]
    public class ServerStarterUI : MonoBehaviour
    {
        [field: SerializeField] public Button StartHostButton { get; private set; }
        [field: SerializeField] public Button StartClientButton { get; private set; }
        [field: SerializeField] public Button SettingsButton { get; private set; }
        [Inject] private readonly IUIManager _uiManager;
        [Inject] private readonly SettingsMenuState _settingsMenuState;
        [Inject] private readonly GameSettingsService _settings;
        [Inject] private readonly KeybindService _keybinds;
        [SerializeField] private TMP_Text _disconnectReasonText;
        // Netcode's reasons already read as sentences ("Disconnected due to host shutting down."), so no prefix by default
        [SerializeField] private string _disconnectReasonFormat = "{0}";
        // There is no player here, so the pause key (Esc / Start) closes settings opened from this menu; rebinding still turns it off
        [SerializeField] private string _backActionName = "Pause";
        private Canvas _serverStarterCanvas;
        private InputAction _backAction;
        private bool _isListeningForBack;
        private bool _hasEnabledBackAction;
        private void Awake()
        {
            _serverStarterCanvas = GetComponent<Canvas>();            
        }
        private void Start()
        {

            StartHostButton.onClick.AddListener(_uiManager.RaiseHostStart);
            StartClientButton.onClick.AddListener(_uiManager.RaiseClientStart);
            SettingsButton.onClick.AddListener(OpenSettings);
            _settingsMenuState.OnOpenChanged += HandleSettingsOpenChanged;
            _backAction = _settings.Data.InputActions.FindAction(_backActionName);
        }


        private void OnDestroy()
        {
            StartHostButton.onClick.RemoveListener(_uiManager.RaiseHostStart);
            StartClientButton.onClick.RemoveListener(_uiManager.RaiseClientStart);
            SettingsButton.onClick.RemoveListener(OpenSettings);
            _settingsMenuState.OnOpenChanged -= HandleSettingsOpenChanged;
            ToggleBackListening(false);
        }

        private void OpenSettings()
        {
            _settingsMenuState.ToggleOpen(true);
            ToggleBackListening(true);
        }

        private void HandleSettingsOpenChanged(bool isOpen)
        {
            if (!isOpen) ToggleBackListening(false);
        }

        private void HandleBackPerformed(InputAction.CallbackContext _) => _settingsMenuState.ToggleOpen(false);

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

        public void ToggleServerStarterUI(bool enabled)
        {
            _serverStarterCanvas.enabled = enabled;
        }

        // An empty reason hides the label
        public void ShowDisconnectReason(string reason)
        {
            var hasReason = !string.IsNullOrEmpty(reason);
            _disconnectReasonText.gameObject.SetActive(hasReason);
            _disconnectReasonText.text = hasReason ? string.Format(_disconnectReasonFormat, reason) : string.Empty;
        }
    }
}
