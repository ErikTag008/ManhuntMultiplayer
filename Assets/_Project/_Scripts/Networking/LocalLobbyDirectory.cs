using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Networking
{
    // Lobby adverts as JSON files in a machine-wide temp folder, one per host, so instances on this PC find each other.
    // Each host rewrites its file on a heartbeat; files older than the stale age belong to crashed hosts and are skipped.
    public class LocalLobbyDirectory : ILobbyDirectory, IDisposable
    {
        private const string AdvertSearchPattern = "*.json";
        private const string AdvertExtension = ".json";
        private const string PendingWriteExtension = ".tmp";

        private readonly ConnectionSettings _settings;
        private readonly string _folderPath;
        private readonly string _advertPath;
        private readonly string _pendingWritePath;
        private readonly string _ownId = Guid.NewGuid().ToString("N");

        private bool _isPublished;

        public LocalLobbyDirectory(ConnectionSettings settings)
        {
            _settings = settings;
            _folderPath = Path.Combine(Path.GetTempPath(), Application.productName, settings.LobbyFolderName);
            _advertPath = Path.Combine(_folderPath, _ownId + AdvertExtension);
            _pendingWritePath = Path.Combine(_folderPath, _ownId + PendingWriteExtension);
        }

        public void Publish(LobbyListing listing)
        {
            listing.Id = _ownId;
            listing.LastUpdatedUtcTicks = DateTime.UtcNow.Ticks;
            try
            {
                Directory.CreateDirectory(_folderPath);
                // written aside and swapped in, so a browser never reads a half-written advert
                File.WriteAllText(_pendingWritePath, JsonUtility.ToJson(listing));
                if (File.Exists(_advertPath)) File.Replace(_pendingWritePath, _advertPath, null);
                else File.Move(_pendingWritePath, _advertPath);
                _isPublished = true;
            }
            catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException)
            {
                EUtils.Logger.LogWarning($"[LocalLobbyDirectory] Could not publish the lobby advert: {exception.Message}");
            }
        }

        public void Unpublish()
        {
            if (!_isPublished) return;

            _isPublished = false;
            TryDelete(_advertPath);
            TryDelete(_pendingWritePath);
        }

        public async UniTask FetchLobbies(List<LobbyListing> results, CancellationToken token)
        {
            // file access can stall (antivirus, slow disks), so it runs off the main thread; parsing and results stay on it
            var adverts = await UniTask.RunOnThreadPool(ReadAdverts, cancellationToken: token);
            token.ThrowIfCancellationRequested();

            results.Clear();
            long staleAgeInTicks = TimeSpan.FromSeconds(_settings.AdvertStaleAgeInSeconds).Ticks;
            long nowTicks = DateTime.UtcNow.Ticks;
            foreach (var (path, json) in adverts)
            {
                if (!TryParse(path, json, out var listing)) continue;

                if (nowTicks - listing.LastUpdatedUtcTicks > staleAgeInTicks)
                {
                    TryDelete(path);
                    continue;
                }

                // private lobbies are joined by address only
                if (listing.Visibility == LobbyVisibility.Private) continue;

                results.Add(listing);
            }
        }

        private List<(string path, string json)> ReadAdverts()
        {
            var adverts = new List<(string path, string json)>();
            string[] paths;
            try
            {
                if (!Directory.Exists(_folderPath)) return adverts;
                paths = Directory.GetFiles(_folderPath, AdvertSearchPattern);
            }
            catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException)
            {
                EUtils.Logger.LogWarning($"[LocalLobbyDirectory] Could not list lobby adverts: {exception.Message}");
                return adverts;
            }

            foreach (var path in paths)
            {
                try
                {
                    adverts.Add((path, File.ReadAllText(path)));
                }
                // deleted or being swapped by its host right now; the next refresh sees it again
                catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException)
                {
                }
            }

            return adverts;
        }

        private static bool TryParse(string path, string json, out LobbyListing listing)
        {
            listing = null;
            try
            {
                listing = JsonUtility.FromJson<LobbyListing>(json);
            }
            catch (ArgumentException exception)
            {
                EUtils.Logger.LogWarning($"[LocalLobbyDirectory] Skipped unreadable advert {Path.GetFileName(path)}: {exception.Message}");
            }

            return listing != null && !string.IsNullOrEmpty(listing.Id);
        }

        private static void TryDelete(string path)
        {
            try
            {
                if (File.Exists(path)) File.Delete(path);
            }
            catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException)
            {
                EUtils.Logger.LogWarning($"[LocalLobbyDirectory] Could not delete {Path.GetFileName(path)}: {exception.Message}");
            }
        }

        public void Dispose() => Unpublish();
    }
}
