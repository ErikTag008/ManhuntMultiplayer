namespace Project.Assets._Project._Scripts.SceneFlow.Maps
{
    // A bundle map found in the local library folder
    public class LocalMapEntry
    {
        public string Id { get; }
        public string DisplayName { get; }
        public string BundlePath { get; }
        // SHA-256 of the bundle file as lowercase hex; two machines only play together on the exact same file
        public string ContentHash { get; }
        public long SizeInBytes { get; }
        // null when the map has no usable preview image
        public string PreviewPath { get; }

        public LocalMapEntry(string id, string displayName, string bundlePath, string contentHash, long sizeInBytes, string previewPath)
        {
            Id = id;
            DisplayName = displayName;
            BundlePath = bundlePath;
            ContentHash = contentHash;
            SizeInBytes = sizeInBytes;
            PreviewPath = previewPath;
        }
    }
}
