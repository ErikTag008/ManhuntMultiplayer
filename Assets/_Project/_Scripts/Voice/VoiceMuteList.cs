using System;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Voice
{
    // Project-scoped list of the remote players this instance can hear and which of them it muted.
    // Each remote player's voice adds and removes itself; mutes are kept only while that player stays, never saved.
    public class VoiceMuteList
    {
        private readonly List<VoicePeer> _peers = new();
        private readonly HashSet<ulong> _mutedIds = new();

        public event Action OnPeersChanged;

        public IReadOnlyList<VoicePeer> Peers => _peers;

        public bool IsMuted(ulong clientId) => _mutedIds.Contains(clientId);

        // adds the peer, or renames it when its name arrives later
        public void Register(ulong clientId, string displayName)
        {
            int index = FindIndex(clientId);
            if (index >= 0)
            {
                if (_peers[index].DisplayName == displayName) return;
                _peers[index] = new(clientId, displayName);
            }
            else _peers.Add(new(clientId, displayName));

            OnPeersChanged?.Invoke();
        }

        public void Unregister(ulong clientId)
        {
            int index = FindIndex(clientId);
            if (index < 0) return;

            _peers.RemoveAt(index);
            _mutedIds.Remove(clientId);
            OnPeersChanged?.Invoke();
        }

        public void SetMuted(ulong clientId, bool isMuted)
        {
            if (isMuted) _mutedIds.Add(clientId);
            else _mutedIds.Remove(clientId);
        }

        private int FindIndex(ulong clientId) => _peers.FindIndex(peer => peer.ClientId == clientId);
    }
}
