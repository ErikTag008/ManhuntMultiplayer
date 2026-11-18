using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.UI
{
    public class UIManager : IUIManager
    {

        public event Action OnHostStart;
        public event Action OnClientStart;
        public event Action<string> OnJoinedPlayerAmountChanged;
        public event Action<string> OnLobbyStatusTextChanged;
        public event Action<string> OnCountdownTextChanged;
        public event Action<string> OnNextCatchersTextChanged;
        public event Action<string> OnPlayerTeamTextChanged; 
        public event Action<bool> OnStartGameButtonAvailabilityChanged;
        public event Action<bool> OnStartGameButtonVisibilityChanged;
        public event Action OnRequestLobbyUIInitialization;
        public event Action OnRequestGameUIInitialization;
        public event Action OnRequestGameStart;
        public event Action<string, string> OnResultsShown;
        public event Action<string> OnRoundHighlightsShown;
        public event Action<string> OnRoundPointsShown;

        public void RaiseHostStart() => OnHostStart?.Invoke();
        public void RaiseClientStart() => OnClientStart?.Invoke();
        public void StartGame() => OnRequestGameStart?.Invoke();
        public void ChangeJoinedPlayerAmount(string text) => OnJoinedPlayerAmountChanged?.Invoke(text);
        public void ChangeLobbyStatusText(string text) => OnLobbyStatusTextChanged?.Invoke(text);
        public void ChangeCountdownText(string text) => OnCountdownTextChanged?.Invoke(text);
        public void ChangeNextCatchersText(string text) => OnNextCatchersTextChanged?.Invoke(text);
        public void ChangePlayerTeamText(string text) => OnPlayerTeamTextChanged?.Invoke(text);
        public void ChangeStartGameButtonAvailability(bool isActive) => OnStartGameButtonAvailabilityChanged?.Invoke(isActive);
        public void ChangeStartGameButtonVisibility(bool isVisible) => OnStartGameButtonVisibilityChanged?.Invoke(isVisible);
        public void RequestLobbyUIInitialization() => OnRequestLobbyUIInitialization?.Invoke(); 
        public void RequestGameUIInitialization() => OnRequestGameUIInitialization?.Invoke();
        public void ShowResults(string title, string subtitle) => OnResultsShown?.Invoke(title, subtitle);

        public void ShowRoundHighlights(string highlights) => OnRoundHighlightsShown?.Invoke(highlights);

        public void ShowRoundPoints(string points) => OnRoundPointsShown?.Invoke(points);
    }
}
