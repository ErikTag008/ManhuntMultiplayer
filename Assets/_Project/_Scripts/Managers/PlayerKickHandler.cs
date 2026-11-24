using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.Player;
using Project.Assets._Project._Scripts.UI.HUD;
using System;
using System.Collections.Generic;
using Unity.Netcode;

namespace Project.Assets._Project._Scripts.Managers
{
    // Fills the pause menu's player list from the synced sessions and kicks the players the host picks there
    public class PlayerKickHandler : IDisposable
    {
        private readonly PlayersMenuState _playersMenuState;
        private readonly PauseMenuState _pauseMenuState;
        private readonly PlayerSessionDirectory _sessionDirectory;
        private readonly IConnectionService _connectionService;
        private readonly List<PlayersMenuEntry> _entries = new();

        public PlayerKickHandler(PlayersMenuState playersMenuState, PauseMenuState pauseMenuState, PlayerSessionDirectory sessionDirectory,
            IConnectionService connectionService)
        {
            _playersMenuState = playersMenuState;
            _pauseMenuState = pauseMenuState;
            _sessionDirectory = sessionDirectory;
            _connectionService = connectionService;
            _sessionDirectory.OnSessionChanged += HandleSessionChanged;
            _sessionDirectory.OnSessionRemoved += HandleSessionRemoved;
            _pauseMenuState.OnOpenChanged += HandlePauseMenuOpenChanged;
            _playersMenuState.OnKickRequested += HandleKickRequested;
        }

        private void HandleSessionChanged(PlayerSession _) => RefreshPlayers();

        private void HandleSessionRemoved(ulong _) => RefreshPlayers();

        // hosting can start or stop between session changes, so the list is rebuilt whenever the menu opens too
        private void HandlePauseMenuOpenChanged(bool isOpen)
        {
            if (isOpen) RefreshPlayers();
        }

        private void HandleKickRequested(ulong clientId) => _connectionService.TryKick(clientId);

        // the host's own player isn't listed: it can't kick itself
        private void RefreshPlayers()
        {
            _entries.Clear();
            bool canKick = _connectionService.IsHosting;
            foreach (var session in _sessionDirectory.Sessions)
            {
                if (session.ClientId == NetworkManager.ServerClientId) continue;
                _entries.Add(new PlayersMenuEntry(session.ClientId, session.DisplayName.ToString()));
            }
            _entries.Sort(CompareByClientId);

            _playersMenuState.ChangePlayers(canKick, _entries);
        }

        private static int CompareByClientId(PlayersMenuEntry a, PlayersMenuEntry b) => a.ClientId.CompareTo(b.ClientId);

        public void Dispose()
        {
            _sessionDirectory.OnSessionChanged -= HandleSessionChanged;
            _sessionDirectory.OnSessionRemoved -= HandleSessionRemoved;
            _pauseMenuState.OnOpenChanged -= HandlePauseMenuOpenChanged;
            _playersMenuState.OnKickRequested -= HandleKickRequested;
        }
    }
}
