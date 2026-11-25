using System;

namespace Project.Assets._Project._Scripts.UI
{
    public interface IUIManager
    {
        public const int NoResultsCountdown = -1;

        event Action OnHostStart;
        event Action OnClientStart;
        event Action<string> OnJoinedPlayerAmountChanged;
        event Action<string> OnLobbyStatusTextChanged;
        event Action<string> OnCountdownTextChanged;
        event Action<string> OnNextCatchersTextChanged;
        event Action<string> OnPlayerTeamTextChanged;
        event Action<bool> OnStartGameButtonAvailabilityChanged;
        event Action<bool> OnStartGameButtonVisibilityChanged;
        event Action OnRequestLobbyUIInitialization;
        event Action OnRequestGameUIInitialization;
        event Action OnRequestGameStart;
        event Action<string, string> OnResultsShown;
        event Action<string> OnRoundHighlightsShown;
        event Action<string> OnRoundPointsShown;
        // whole seconds until the results screen ends; NoResultsCountdown hides it
        event Action<int> OnResultsSecondsLeftChanged;

        void RaiseHostStart();
        void RaiseClientStart();
        void StartGame();
        void ChangeJoinedPlayerAmount(string text);
        void ChangeLobbyStatusText(string text);
        void ChangeCountdownText(string text);
        void ChangeNextCatchersText(string text);
        void ChangePlayerTeamText(string text);
        void ChangeStartGameButtonAvailability(bool isActive);
        void ChangeStartGameButtonVisibility(bool isVisible);
        void RequestLobbyUIInitialization();
        void RequestGameUIInitialization();
        void ShowResults(string title, string subtitle);
        // one line per highlight; empty hides them
        void ShowRoundHighlights(string highlights);
        // what the local player earned this round; empty hides it
        void ShowRoundPoints(string points);
        void ChangeResultsSecondsLeft(int seconds);
    }
}
