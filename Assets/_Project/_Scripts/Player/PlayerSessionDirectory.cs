using System;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Player
{
    // Project-scoped, read-only mirror of PlayerRegistry's session list, so player components can read sessions
    // whatever order GameSystems and the players spawn in. Only PlayerRegistry writes to it.
    public class PlayerSessionDirectory
    {
        private readonly Dictionary<ulong, PlayerSession> _sessions = new();

        public event Action<PlayerSession> OnSessionChanged;

        public bool TryGetSession(ulong clientId, out PlayerSession session) => _sessions.TryGetValue(clientId, out session);

        public void Set(PlayerSession session)
        {
            if (_sessions.TryGetValue(session.ClientId, out var current) && current.Equals(session)) return;

            _sessions[session.ClientId] = session;
            OnSessionChanged?.Invoke(session);
        }

        public void Remove(ulong clientId) => _sessions.Remove(clientId);

        public void Clear() => _sessions.Clear();
    }
}
