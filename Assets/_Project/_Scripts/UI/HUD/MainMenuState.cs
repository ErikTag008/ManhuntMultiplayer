using Project.Assets._Project._Scripts.Networking;
using System;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // The main menu's open screen, busy flag and status line, plus the player's host/join requests.
    // The views write the screen and read the rest; MainMenuStarter acts on the requests and reports back.
    public class MainMenuState
    {
        private MainMenuScreen _currentScreen = MainMenuScreen.Main;
        private bool _isBusy;
        private string _statusText = string.Empty;

        // previous, current
        public event Action<MainMenuScreen, MainMenuScreen> OnScreenChanged;
        public event Action<bool> OnBusyChanged;
        public event Action<string> OnStatusChanged;
        public event Action<LobbyConfig> OnHostRequested;
        public event Action<string> OnJoinRequested;

        public MainMenuScreen CurrentScreen => _currentScreen;
        public bool IsBusy => _isBusy;
        public string StatusText => _statusText;

        // A status belongs to the screen it came from, so switching screens clears it
        public void ShowScreen(MainMenuScreen screen)
        {
            if (_isBusy || _currentScreen == screen) return;

            var previous = _currentScreen;
            _currentScreen = screen;
            SetStatus(null);
            OnScreenChanged?.Invoke(previous, screen);
        }

        public void ToggleBusy(bool isBusy)
        {
            if (_isBusy == isBusy) return;

            _isBusy = isBusy;
            OnBusyChanged?.Invoke(isBusy);
        }

        public void SetStatus(string text)
        {
            text ??= string.Empty;
            if (_statusText == text) return;

            _statusText = text;
            OnStatusChanged?.Invoke(text);
        }

        public void RequestHost(LobbyConfig config)
        {
            if (_isBusy) return;
            OnHostRequested?.Invoke(config);
        }

        public void RequestJoin(string target)
        {
            if (_isBusy) return;
            OnJoinRequested?.Invoke(target);
        }
    }

    public enum MainMenuScreen
    {
        Main,
        HostLobby,
        JoinLobby
    }
}
