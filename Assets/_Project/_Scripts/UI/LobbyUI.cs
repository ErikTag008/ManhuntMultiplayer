using Project.Assets._Project._Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI
{
    public class LobbyUI : Singleton<LobbyUI>
    {
        [SerializeField] private TMP_Text _joinedPlayerAmountText;
        [SerializeField] private TMP_Text _lobbyStatusText;
        [SerializeField] private TMP_Text _countdownText;
        [SerializeField] private Button _gameStartButton;

        private void Start()
        {
            var uiManager = UIManager.Instance;
            uiManager.OnJoinedPlayerAmountChanged += HandleJoinedPlayerAmountChange;
            uiManager.OnLobbyStatusTextChanged += HandleLobbyStatusChange;
            uiManager.OnCountdownTextChanged += HandleCountdownChange;
            uiManager.OnStartGameButtonAvailabilityChanged += HandleGameStartButtonAvailabilityChange;
            uiManager.RequestLobbyUIInitialization();
            _gameStartButton.onClick.AddListener(uiManager.StartGame);
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

        private void HandleJoinedPlayerAmountChange(string text)
        {
            _joinedPlayerAmountText.text = text;
        }

        private void HandleLobbyStatusChange(string text)
        {
            _lobbyStatusText.text = text;
        }

        private void HandleCountdownChange(string text)
        {
            _countdownText.text = text;
        }

        private void OnDestroy()
        {
            var uiManager = UIManager.Instance;
            uiManager.OnJoinedPlayerAmountChanged -= HandleJoinedPlayerAmountChange;
            uiManager.OnLobbyStatusTextChanged -= HandleLobbyStatusChange;
            uiManager.OnCountdownTextChanged -= HandleCountdownChange;
            uiManager.OnStartGameButtonAvailabilityChanged -= HandleGameStartButtonAvailabilityChange;
            _gameStartButton.onClick.RemoveListener(uiManager.StartGame);

        }
    }
}

