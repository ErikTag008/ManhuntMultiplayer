using System;
using Unity.Collections;
using Unity.Netcode;

namespace Project.Assets._Project._Scripts.Networking
{
    // One map a session can play: a built-in scene by its GameScenes index, or a bundle map from the local library by id and content hash
    public struct MapListing : INetworkSerializable, IEquatable<MapListing>
    {
        public const int NotBuiltIn = -1;

        public bool IsBundle;
        public int BuiltInIndex;
        public FixedString64Bytes Id;
        public FixedString64Bytes DisplayName;
        public FixedString128Bytes ContentHash;

        public static MapListing BuiltIn(int builtInIndex, string displayName) => new()
        {
            IsBundle = false,
            BuiltInIndex = builtInIndex,
            DisplayName = ToFixedString<FixedString64Bytes>(displayName)
        };

        public static MapListing Bundle(string id, string displayName, string contentHash) => new()
        {
            IsBundle = true,
            BuiltInIndex = NotBuiltIn,
            Id = ToFixedString<FixedString64Bytes>(id),
            DisplayName = ToFixedString<FixedString64Bytes>(displayName),
            ContentHash = ToFixedString<FixedString128Bytes>(contentHash)
        };

        public readonly bool Equals(MapListing other) =>
            IsBundle == other.IsBundle &&
            BuiltInIndex == other.BuiltInIndex &&
            Id.Equals(other.Id) &&
            DisplayName.Equals(other.DisplayName) &&
            ContentHash.Equals(other.ContentHash);

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref IsBundle);
            serializer.SerializeValue(ref BuiltInIndex);
            serializer.SerializeValue(ref Id);
            serializer.SerializeValue(ref DisplayName);
            serializer.SerializeValue(ref ContentHash);
        }

        // Cuts text that doesn't fit instead of throwing like the FixedString constructor does in the Editor
        private static TFixedString ToFixedString<TFixedString>(string text) where TFixedString : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            var fixedString = new TFixedString();
            fixedString.CopyFromTruncated(text ?? string.Empty);
            return fixedString;
        }
    }
}
