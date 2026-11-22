using Project.Assets._Project._Scripts.Networking;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Project.Assets._Project._Scripts.SceneFlow.Maps
{
    // The maps this session can play, by LobbyConfig.MapIndex: the GameScenes built-ins at their own indices, then the local bundle maps.
    // Offline and on the server it's this machine's list; a connected client mirrors the server's list (MapListSync), so indices match.
    public class SessionMapCatalog : IMapCatalog
    {
        // GameScenes falls back to DefaultMap for any index outside its list
        private const int FallbackBuiltInIndex = -1;
        // LoadImage resizes the texture to the image
        private const int UnloadedTextureSize = 1;

        private readonly GameScenes _gameScenes;
        private readonly LocalMapLibrary _mapLibrary;
        private readonly List<MapListing> _localListings = new();
        private readonly List<MapListing> _remoteListings = new();
        // bundle map previews by file path, loaded on first use; null marks a file that failed to load
        private readonly Dictionary<string, Texture2D> _bundlePreviews = new();
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

        // null when the map has no preview, or it's a bundle map this machine doesn't have the same file of
        public Texture2D GetMapPreview(int index)
        {
            var listing = GetListing(index);
            if (!listing.IsBundle) return _gameScenes.GetMapPreview(listing.BuiltInIndex);
            if (!_mapLibrary.TryFind(listing.Id.ToString(), listing.ContentHash.ToString(), out var entry) || entry.PreviewPath == null) return null;

            return GetBundlePreview(entry.PreviewPath);
        }

        // built-in maps ship with the game; a bundle map needs the same file in this machine's library
        public bool HasLocalCopy(int index)
        {
            var listing = GetListing(index);
            return !listing.IsBundle || _mapLibrary.TryFind(listing.Id.ToString(), listing.ContentHash.ToString(), out _);
        }

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
            // a preview file may have changed with its map
            ClearBundlePreviews();
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

        private Texture2D GetBundlePreview(string previewPath)
        {
            if (_bundlePreviews.TryGetValue(previewPath, out var preview)) return preview;

            preview = LoadPreview(previewPath);
            _bundlePreviews[previewPath] = preview;
            return preview;
        }

        private static Texture2D LoadPreview(string previewPath)
        {
            byte[] bytes;
            try
            {
                bytes = File.ReadAllBytes(previewPath);
            }
            catch (Exception e) when (e is IOException || e is UnauthorizedAccessException)
            {
                EUtils.Logger.LogWarning($"[SessionMapCatalog] Can't read the map preview {previewPath}: {e.Message}");
                return null;
            }

            // clamped, so a cropped edge never filters in pixels from the opposite side
            var preview = new Texture2D(UnloadedTextureSize, UnloadedTextureSize)
            {
                name = Path.GetFileName(previewPath),
                wrapMode = TextureWrapMode.Clamp
            };
            // the CPU copy isn't needed once it's on the GPU
            if (preview.LoadImage(bytes, true)) return preview;

            EUtils.Logger.LogWarning($"[SessionMapCatalog] The map preview {previewPath} isn't a readable image.");
            UnityEngine.Object.Destroy(preview);
            return null;
        }

        private void ClearBundlePreviews()
        {
            foreach (var preview in _bundlePreviews.Values)
            {
                if (preview != null) UnityEngine.Object.Destroy(preview);
            }

            _bundlePreviews.Clear();
        }

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
