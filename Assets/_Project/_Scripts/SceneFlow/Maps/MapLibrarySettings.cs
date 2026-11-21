using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Project.Assets._Project._Scripts.SceneFlow.Maps
{
    // Where bundle maps live on this machine and the rules every bundle map must follow
    [CreateAssetMenu(fileName = "MapLibrarySettings", menuName = "ScriptableObjects/MapLibrarySettings", order = 1)]
    public class MapLibrarySettings : ScriptableObject
    {
        private const long BytesPerMegabyte = 1024 * 1024;
        private const long BytesPerKilobyte = 1024;

        // under Application.persistentDataPath; an absolute path is used as it is
        [field: SerializeField] public string FolderName { get; private set; } = "Maps";
        [field: SerializeField] public string BundleExtension { get; private set; } = ".mapbundle";
        [field: SerializeField] public string InfoExtension { get; private set; } = ".mapinfo.json";
        [field: SerializeField] public string PreviewSuffix { get; private set; } = ".preview";
        // image files LoadImage can read
        [field: SerializeField] public List<string> PreviewExtensions { get; private set; } = new() { ".png", ".jpg", ".jpeg" };
        // Steam caps a Workshop item's preview image at 1 MB, and the same file becomes that preview
        [field: SerializeField, Min(1)] public int MaxPreviewSizeInKilobytes { get; private set; } = 1024;
        [field: SerializeField, Min(1)] public int MaxBundleSizeInMegabytes { get; private set; } = 200;
        // the longest side of the map's MapBounds
        [field: SerializeField, Min(1f)] public float MaxMapSizeInMeters { get; private set; } = 400f;
        [field: SerializeField, Min(1)] public int MinRunnerSpawns { get; private set; } = 8;
        [field: SerializeField, Min(1)] public int MinCatcherSpawns { get; private set; } = 4;
        [field: SerializeField, Min(0)] public int MinDropPoints { get; private set; } = 1;
        [field: SerializeField, Min(0)] public int MinStations { get; private set; }
        // how long the server waits for every client to load a bundle map before disconnecting the ones still loading
        [field: SerializeField, Min(1f)] public float ReadyTimeoutInSeconds { get; private set; } = 60f;

        public string FolderPath => Path.Combine(Application.persistentDataPath, FolderName);
        public long MaxBundleSizeInBytes => MaxBundleSizeInMegabytes * BytesPerMegabyte;
        public long MaxPreviewSizeInBytes => MaxPreviewSizeInKilobytes * BytesPerKilobyte;

        public string GetBundleFileName(string mapId) => mapId + BundleExtension;
        public string GetInfoFileName(string mapId) => mapId + InfoExtension;
        // extension includes the dot, as Path.GetExtension returns it
        public string GetPreviewFileName(string mapId, string extension) => mapId + PreviewSuffix + extension.ToLowerInvariant();

        public bool IsPreviewExtension(string extension)
        {
            foreach (var previewExtension in PreviewExtensions)
            {
                if (string.Equals(previewExtension, extension, System.StringComparison.OrdinalIgnoreCase)) return true;
            }

            return false;
        }
    }
}
