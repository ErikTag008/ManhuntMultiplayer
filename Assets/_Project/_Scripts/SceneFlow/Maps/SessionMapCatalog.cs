using Project.Assets._Project._Scripts.Networking;
using System;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.SceneFlow.Maps
{
    // The maps this session can play, by LobbyConfig.MapIndex: the GameScenes built-ins at their own indices, then the local bundle maps.
    // Offline and on the server it's this machine's list; a connected client mirrors the server's list (MapListSync), so indices match.
    public class SessionMapCatalog : IMapCatalog
    {
        // GameScenes falls back to DefaultMap for any index outside its list
        private const int FallbackBuiltInIndex = -1;

        private readonly GameScenes _gameScenes;
        private readonly LocalMapLibrary _mapLibrary;
        private readonly List<MapListing> _localListings = new();
        private readonly List<MapListing> _remoteListings = new();
        private bool _isMirroringRemote;
        // Server only
        private MapListing _selectedMap;

        public event Action OnChanged;

        public SessionMapCatalog(GameScenes gameScenes, LocalMapLibrary mapLibrary)
        {
            _gameScenes = gameScenes;
            _mapLibrary = mapLibrary;
            BuildLocalListings(_gameScenes, _mapLibrary.Maps, _localListings);
        }

        public IReadOnlyList<MapListing> Listings => _isMirroringRemote ? _remoteListings : _localListings;
        public bool IsMirroringRemote => _isMirroringRemote;
        public int MapCount => Listings.Count;
        // Server only: the map the current round was started on
        public MapListing SelectedMap => _selectedMap;

        public string GetMapDisplayName(int index) => GetListing(index).DisplayName.ToString();

        // out-of-range indices fall back to DefaultMap, like GameScenes.GetMap
        public MapListing GetListing(int index)
        {
            var listings = Listings;
            if (index >= 0 && index < listings.Count) return listings[index];

            return MapListing.BuiltIn(FallbackBuiltInIndex, _gameScenes.GetMapDisplayName(FallbackBuiltInIndex));
        }

        // Rescans the library folder; never while hosting, since the indices the session uses would shift
        public void RefreshLocalListings()
        {
            _mapLibrary.Rescan();
            BuildLocalListings(_gameScenes, _mapLibrary.Maps, _localListings);
            if (!_isMirroringRemote) OnChanged?.Invoke();
        }

        public void SetRemoteListings(IEnumerable<MapListing> listings)
        {
            _remoteListings.Clear();
            _remoteListings.AddRange(listings);
            _isMirroringRemote = true;
            OnChanged?.Invoke();
        }

        public void ClearRemoteListings()
        {
            if (!_isMirroringRemote) return;

            _remoteListings.Clear();
            _isMirroringRemote = false;
            OnChanged?.Invoke();
        }

        public void SelectMap(MapListing listing) => _selectedMap = listing;

        public static void BuildLocalListings(GameScenes gameScenes, IReadOnlyList<LocalMapEntry> bundleMaps, List<MapListing> results)
        {
            results.Clear();
            for (int index = 0; index < gameScenes.MapCount; index++)
            {
                results.Add(MapListing.BuiltIn(index, gameScenes.GetMapDisplayName(index)));
            }

            foreach (var map in bundleMaps)
            {
                results.Add(MapListing.Bundle(map.Id, map.DisplayName, map.ContentHash));
            }
        }
    }
}
