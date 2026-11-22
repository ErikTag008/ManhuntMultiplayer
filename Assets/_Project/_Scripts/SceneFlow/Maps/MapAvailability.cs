using System;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.SceneFlow.Maps
{
    // Server only: which of the session's maps each connected client is missing. Built-in maps ship with the game; a bundle map
    // only counts as playable once every client has reported having the same copy, so picking it never drops a client.
    public class MapAvailability
    {
        private readonly SessionMapCatalog _mapCatalog;
        private readonly Dictionary<ulong, HashSet<int>> _missingMapsByClient = new();

        public event Action OnChanged;

        public MapAvailability(SessionMapCatalog mapCatalog)
        {
            _mapCatalog = mapCatalog;
        }

        public void SetMissingMaps(ulong clientId, IReadOnlyList<int> mapIndices)
        {
            if (!_missingMapsByClient.TryGetValue(clientId, out var missingMaps))
            {
                missingMaps = new();
                _missingMapsByClient[clientId] = missingMaps;
            }

            missingMaps.Clear();
            foreach (int mapIndex in mapIndices) missingMaps.Add(mapIndex);
            OnChanged?.Invoke();
        }

        public void RemoveClient(ulong clientId)
        {
            if (_missingMapsByClient.Remove(clientId)) OnChanged?.Invoke();
        }

        // a client that hasn't reported yet counts as missing every bundle map
        public bool IsPlayableByAll(int mapIndex, IReadOnlyList<ulong> clientIds)
        {
            if (!_mapCatalog.GetListing(mapIndex).IsBundle) return true;

            foreach (ulong clientId in clientIds)
            {
                if (!_missingMapsByClient.TryGetValue(clientId, out var missingMaps) || missingMaps.Contains(mapIndex)) return false;
            }

            return true;
        }
    }
}
