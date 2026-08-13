using System;

namespace Project.Assets._Project._Scripts.Managers
{
    public interface IUIManager
    {
        event Action OnHostStart;
        event Action OnClientStart;
        event Action<string> OnJoinedPlayerAmountChanged;
        event Action<string> OnLobbyStatusTextChanged;
        event Action<string> OnCountdownTextChanged;
        event Action<string> OnPlayerTeamTextChanged;
        event Action<bool> OnStartGameButtonAvailabilityChanged;
        event Action OnRequestLobbyUIInitialization;
        event Action OnRequestGameUIInitialization;
        event Action OnRequestGameStart;

        void RaiseHostStart();
        void RaiseClientStart();
        void StartGame();
        void ChangeJoinedPlayerAmount(string text);
        void ChangeLobbyStatusText(string text);
        void ChangeCountdownText(string text);
        void ChangePlayerTeamText(string text);
        void ChangeStartGameButtonAvailability(bool isActive);
        void RequestLobbyUIInitialization();
        void RequestGameUIInitialization();
    }
}
