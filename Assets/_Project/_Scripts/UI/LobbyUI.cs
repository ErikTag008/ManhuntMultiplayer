using Project.Assets._Project._Scripts.Managers;
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
        [SerializeField] private Button _gameStartButton;
        [Inject] private readonly IUIManager _uiManager;

        private void Start()
        {
            _uiManager.OnJoinedPlayerAmountChanged += HandleJoinedPlayerAmountChange;
            _uiManager.OnLobbyStatusTextChanged += HandleLobbyStatusChange;
            _uiManager.OnCountdownTextChanged += HandleCountdownChange;
            _uiManager.OnStartGameButtonAvailabilityChanged += HandleGameStartButtonAvailabilityChange;
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
            if(_gameStartButton.interactable)
                _gameStartButton.onClick.Invoke();
        }

        private void HandleGameStartButtonAvailabilityChange(bool isActive)
        {
            _gameStartButton.interactable = isActive;
        }

        private void HandleJoinedPlayerAmountChange(string text) => HandleUITextChange(_joinedPlayerAmountText, text);

        private void HandleLobbyStatusChange(string text) => HandleUITextChange(_lobbyStatusText, text);

        private void HandleCountdownChange(string text) => HandleUITextChange(_countdownText, text);

        private void OnDestroy()
        {
            var uiManager = _uiManager;
            uiManager.OnJoinedPlayerAmountChanged -= HandleJoinedPlayerAmountChange;
            uiManager.OnLobbyStatusTextChanged -= HandleLobbyStatusChange;
            uiManager.OnCountdownTextChanged -= HandleCountdownChange;
            uiManager.OnStartGameButtonAvailabilityChanged -= HandleGameStartButtonAvailabilityChange;
            _gameStartButton.onClick.RemoveListener(uiManager.StartGame);

        }
    }
}

