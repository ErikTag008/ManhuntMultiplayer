using System;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Player
{
    // Project-scoped list of the player objects spawned on this instance, keyed by owner client id.
    // Unlike PlayerRegistry it is filled on clients too; each PlayerController adds and removes itself.
    public class SpawnedPlayerDirectory
    {
        private readonly Dictionary<ulong, PlayerController> _players = new();

        public event Action<ulong> OnPlayerRemoved;

        public IReadOnlyCollection<ulong> ClientIds => _players.Keys;
        // the concrete collection, so per-frame loops don't box an enumerator
        public Dictionary<ulong, PlayerController>.ValueCollection Players => _players.Values;

        public bool TryGetPlayer(ulong clientId, out PlayerController player) => _players.TryGetValue(clientId, out player);

        public void Add(ulong clientId, PlayerController player) => _players[clientId] = player;

        public void Remove(ulong clientId, PlayerController player)
        {
            if (!_players.TryGetValue(clientId, out var current) || current != player) return;

            _players.Remove(clientId);
            OnPlayerRemoved?.Invoke(clientId);
        }
    }
}
