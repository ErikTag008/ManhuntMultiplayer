using System;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Player
{
    // Project-scoped, read-only mirror of PlayerRegistry's session list, so player components can read sessions
    // whatever order GameSystems and the players spawn in. Only PlayerRegistry writes to it.
    public class PlayerSessionDirectory
    {
        private readonly Dictionary<ulong, PlayerSession> _sessions = new();
        private readonly List<ulong> _clearedIds = new();

        public event Action<PlayerSession> OnSessionChanged;
        public event Action<ulong> OnSessionRemoved;

        public IReadOnlyCollection<PlayerSession> Sessions => _sessions.Values;

        public bool TryGetSession(ulong clientId, out PlayerSession session) => _sessions.TryGetValue(clientId, out session);

        public void Set(PlayerSession session)
        {
            if (_sessions.TryGetValue(session.ClientId, out var current) && current.Equals(session)) return;

            _sessions[session.ClientId] = session;
            OnSessionChanged?.Invoke(session);
        }

        public void Remove(ulong clientId)
        {
            if (_sessions.Remove(clientId)) OnSessionRemoved?.Invoke(clientId);
        }

        public void Clear()
        {
            _clearedIds.Clear();
            _clearedIds.AddRange(_sessions.Keys);
            _sessions.Clear();
            foreach (ulong clientId in _clearedIds) OnSessionRemoved?.Invoke(clientId);
        }
    }
}
