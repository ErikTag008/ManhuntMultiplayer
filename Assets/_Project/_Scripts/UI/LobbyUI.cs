using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI
{
    public class LobbyUI : MonoBehaviour, ILobbyUI
    {
        [SerializeField] private TMP_Text _joinedPlayerAmountText;
        [SerializeField] private TMP_Text _lobbyStatusText;
        [SerializeField] private TMP_Text _countdownText;
        [SerializeField] private TMP_Text _nextCatchersText;
        [SerializeField] private Button _gameStartButton;
        [Inject] private readonly IUIManager _uiManager;

        private void Start()
        {
            _uiManager.OnJoinedPlayerAmountChanged += HandleJoinedPlayerAmountChange;
            _uiManager.OnLobbyStatusTextChanged += HandleLobbyStatusChange;
            _uiManager.OnCountdownTextChanged += HandleCountdownChange;
            _uiManager.OnNextCatchersTextChanged += HandleNextCatchersChange;
            _uiManager.OnStartGameButtonAvailabilityChanged += HandleGameStartButtonAvailabilityChange;
            _uiManager.OnStartGameButtonVisibilityChanged += HandleGameStartButtonVisibilityChange;
            // hidden until the host says it's theirs, so joining players never see it flash
            HandleGameStartButtonVisibilityChange(false);
            _uiManager.RequestLobbyUIInitialization();
            _gameStartButton.onClick.AddListener(_uiManager.StartGame);
        }

        private void HandleUITextChange(TMP_Text uiText, string text)
        {
            if (uiText.text == text) return;
            uiText.text = text;
        }

        public void InvokeGameStartButtonPress()
        {
            if(_gameStartButton.gameObject.activeSelf && _gameStartButton.interactable)
                _gameStartButton.onClick.Invoke();
        }

        private void HandleGameStartButtonAvailabilityChange(bool isActive)
        {
            _gameStartButton.interactable = isActive;
        }

        private void HandleGameStartButtonVisibilityChange(bool isVisible)
        {
            if (_gameStartButton.gameObject.activeSelf != isVisible) _gameStartButton.gameObject.SetActive(isVisible);
        }

        private void HandleJoinedPlayerAmountChange(string text) => HandleUITextChange(_joinedPlayerAmountText, text);

        private void HandleLobbyStatusChange(string text) => HandleUITextChange(_lobbyStatusText, text);

        private void HandleCountdownChange(string text) => HandleUITextChange(_countdownText, text);

        private void HandleNextCatchersChange(string text) => HandleUITextChange(_nextCatchersText, text);

        private void OnDestroy()
        {
            var uiManager = _uiManager;
            uiManager.OnJoinedPlayerAmountChanged -= HandleJoinedPlayerAmountChange;
            uiManager.OnLobbyStatusTextChanged -= HandleLobbyStatusChange;
            uiManager.OnCountdownTextChanged -= HandleCountdownChange;
            uiManager.OnNextCatchersTextChanged -= HandleNextCatchersChange;
            uiManager.OnStartGameButtonAvailabilityChanged -= HandleGameStartButtonAvailabilityChange;
            uiManager.OnStartGameButtonVisibilityChanged -= HandleGameStartButtonVisibilityChange;
            _gameStartButton.onClick.RemoveListener(uiManager.StartGame);

        }
    }
}

