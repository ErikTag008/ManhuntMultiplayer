using System;

namespace Project.Assets._Project._Scripts.Managers
{
    public class UIManager : Singleton<UIManager>
    {

        public event Action OnHostStart;
        public event Action OnClientStart;
        public event Action<string> OnJoinedPlayerAmountChanged;
        public event Action<string> OnLobbyStatusTextChanged;
        public event Action<string> OnCountdownTextChanged;
        public event Action<string> OnPlayerTeamTextChanged; 
        public event Action<bool> OnStartGameButtonAvailabilityChanged;
        public event Action OnRequestLobbyUIInitialization;
        public event Action OnRequestGameUIInitialization;
        public event Action OnRequestGameStart;

        protected override void Awake()
        {
            base.Awake();
        }

        public void RaiseHostStart() => OnHostStart?.Invoke();
        public void RaiseClientStart() => OnClientStart?.Invoke();
        public void StartGame() => OnRequestGameStart?.Invoke();
        public void ChangeJoinedPlayerAmount(string text) => OnJoinedPlayerAmountChanged?.Invoke(text);
        public void ChangeLobbyStatusText(string text) => OnLobbyStatusTextChanged?.Invoke(text);
        public void ChangeCountdownText(string text) => OnCountdownTextChanged?.Invoke(text);
        public void ChangePlayerTeamText(string text) => OnPlayerTeamTextChanged?.Invoke(text);
        public void ChangeStartGameButtonAvailability(bool isActive) => OnStartGameButtonAvailabilityChanged?.Invoke(isActive);
        public void RequestLobbyUIInitialization() => OnRequestLobbyUIInitialization?.Invoke(); 
        public void RequestGameUIInitialization() => OnRequestGameUIInitialization?.Invoke();
    }
}
