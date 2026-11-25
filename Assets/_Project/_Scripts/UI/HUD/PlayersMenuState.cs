using System;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.UI.HUD
{
    // The pause menu's player list: who else is in the session, and the host's kick requests. A session handler fills
    // the list and carries out the kicks; only the host gets CanKick.
    public class PlayersMenuState
    {
        private readonly List<PlayersMenuEntry> _players = new();
        private bool _canKick;
        private bool _canBlockRejoin;

        public event Action OnPlayersChanged;
        public event Action<ulong> OnKickRequested;

        public IReadOnlyList<PlayersMenuEntry> Players => _players;
        public bool CanKick => _canKick;
        // a kicked player can't come back to this hosted session (false: the kick only disconnects them)
        public bool CanBlockRejoin => _canBlockRejoin;

        public void ChangePlayers(bool canKick, bool canBlockRejoin, IReadOnlyList<PlayersMenuEntry> players)
        {
            _canKick = canKick;
            _canBlockRejoin = canBlockRejoin;
            _players.Clear();
            for (int i = 0; i < players.Count; i++) _players.Add(players[i]);
            OnPlayersChanged?.Invoke();
        }

        public void RequestKick(ulong clientId)
        {
            if (_canKick) OnKickRequested?.Invoke(clientId);
        }
    }
}
