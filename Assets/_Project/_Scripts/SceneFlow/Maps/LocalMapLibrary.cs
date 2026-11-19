using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace Project.Assets._Project._Scripts.SceneFlow.Maps
{
    // The bundle maps in this machine's library folder, found through their JSON sidecars. Broken, incomplete or
    // wrong-version maps are skipped with a warning. Hashes are cached per file until its size or write time changes.
    public class LocalMapLibrary
    {
        private const string HexByteFormat = "x2";
        private const int HexCharsPerByte = 2;

        private readonly MapLibrarySettings _settings;
        private readonly List<LocalMapEntry> _maps = new();
        private readonly Dictionary<string, CachedHash> _hashCache = new();

        public IReadOnlyList<LocalMapEntry> Maps => _maps;

        public LocalMapLibrary(MapLibrarySettings settings)
        {
            _settings = settings;
            Rescan();
        }

        public void Rescan()
        {
            _maps.Clear();
            string folderPath = _settings.FolderPath;
            if (!Directory.Exists(folderPath)) return;

            string[] infoPaths;
            try
            {
                infoPaths = Directory.GetFiles(folderPath, $"*{_settings.InfoExtension}");
            }
            catch (Exception e) when (e is IOException || e is UnauthorizedAccessException)
            {
                EUtils.Logger.LogWarning($"[LocalMapLibrary] Can't read the map folder {folderPath}: {e.Message}");
                return;
            }

            foreach (var infoPath in infoPaths)
            {
                if (!TryLoadEntry(folderPath, infoPath, out var entry, out string reason))
                {
                    EUtils.Logger.LogWarning($"[LocalMapLibrary] Skipped {Path.GetFileName(infoPath)}: {reason}");
                    continue;
                }

                if (Contains(entry.Id))
                {
                    EUtils.Logger.LogWarning($"[LocalMapLibrary] Skipped {Path.GetFileName(infoPath)}: another map already uses the id {entry.Id}.");
                    continue;
                }

                _maps.Add(entry);
            }

            // the file system gives no order, and every machine should list the same maps the same way
            _maps.Sort((a, b) => string.CompareOrdinal(a.Id, b.Id));
        }

        public bool Contains(string mapId)
        {
            foreach (var map in _maps)
            {
                if (map.Id == mapId) return true;
            }

            return false;
        }

        // only the exact same bundle file counts
        public bool TryFind(string mapId, string contentHash, out LocalMapEntry entry)
        {
            foreach (var map in _maps)
            {
                if (map.Id != mapId || !string.Equals(map.ContentHash, contentHash, StringComparison.OrdinalIgnoreCase)) continue;

                entry = map;
                return true;
            }

            entry = null;
            return false;
        }

        // What a sidecar says, or why it can't be used
        public static bool TryParseInfo(string json, out MapBundleInfo info, out string reason)
        {
            info = null;
            if (string.IsNullOrWhiteSpace(json))
            {
                reason = "the file is empty.";
                return false;
            }

            try
            {
                info = JsonUtility.FromJson<MapBundleInfo>(json);
            }
            catch (ArgumentException e)
            {
                reason = $"the JSON is broken ({e.Message}).";
                return false;
            }

            reason = GetInfoProblem(info);
            return reason == null;
        }

        public static string ComputeContentHash(string filePath)
        {
            using var stream = File.OpenRead(filePath);
            using var sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(stream);
            var builder = new StringBuilder(hash.Length * HexCharsPerByte);
            foreach (byte value in hash) builder.Append(value.ToString(HexByteFormat));
            return builder.ToString();
        }

        // null when the info is usable
        private static string GetInfoProblem(MapBundleInfo info)
        {
            if (info == null) return "the file has no map info.";
            if (info.SdkVersion != MapSdk.Version) return $"it was made with map SDK {info.SdkVersion}; this game uses {MapSdk.Version}.";
            if (!MapValidator.IsValidId(info.Id)) return $"the id \"{info.Id}\" isn't valid.";
            if (string.IsNullOrWhiteSpace(info.DisplayName)) return "it has no display name.";
            // a bundle must sit next to its sidecar, so a sidecar can't point anywhere else on the machine
            if (string.IsNullOrWhiteSpace(info.BundleFileName) || Path.GetFileName(info.BundleFileName) != info.BundleFileName)
            {
                return $"the bundle file name \"{info.BundleFileName}\" isn't a plain file name.";
            }

            return null;
        }

        private bool TryLoadEntry(string folderPath, string infoPath, out LocalMapEntry entry, out string reason)
        {
            entry = null;
            string json;
            try
            {
                json = File.ReadAllText(infoPath);
            }
            catch (Exception e) when (e is IOException || e is UnauthorizedAccessException)
            {
                reason = $"it can't be read ({e.Message}).";
                return false;
            }

            if (!TryParseInfo(json, out var info, out reason)) return false;

            string bundlePath = Path.Combine(folderPath, info.BundleFileName);
            var bundleFile = new FileInfo(bundlePath);
            if (!bundleFile.Exists)
            {
                reason = $"its bundle {info.BundleFileName} is missing.";
                return false;
            }

            try
            {
                string contentHash = GetContentHash(bundleFile);
                entry = new LocalMapEntry(info.Id, info.DisplayName, bundlePath, contentHash, bundleFile.Length);
                return true;
            }
            catch (Exception e) when (e is IOException || e is UnauthorizedAccessException)
            {
                reason = $"its bundle can't be read ({e.Message}).";
                return false;
            }
        }

        private string GetContentHash(FileInfo bundleFile)
        {
            string path = bundleFile.FullName;
            if (_hashCache.TryGetValue(path, out var cached) && cached.SizeInBytes == bundleFile.Length && cached.LastWriteTimeUtc == bundleFile.LastWriteTimeUtc)
            {
                return cached.ContentHash;
            }

            string contentHash = ComputeContentHash(path);
            _hashCache[path] = new CachedHash(bundleFile.Length, bundleFile.LastWriteTimeUtc, contentHash);
            return contentHash;
        }

        private readonly struct CachedHash
        {
            public readonly long SizeInBytes;
            public readonly DateTime LastWriteTimeUtc;
            public readonly string ContentHash;

            public CachedHash(long sizeInBytes, DateTime lastWriteTimeUtc, string contentHash)
            {
                SizeInBytes = sizeInBytes;
                LastWriteTimeUtc = lastWriteTimeUtc;
                ContentHash = contentHash;
            }
        }
    }
}
