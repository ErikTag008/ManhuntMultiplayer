using System;
using Unity.Collections;
using Unity.Netcode;

namespace Project.Assets._Project._Scripts.Networking
{
    // The host's choices for one session; ActiveLobbyConfig holds the current one on every instance
    public struct LobbyConfig : INetworkSerializable, IEquatable<LobbyConfig>
    {
        public FixedString64Bytes Name;
        public LobbyVisibility Visibility;
        public int MaxPlayers;
        public int MapIndex;
        public float HideDurationInSeconds;
        public float RoundDurationInSeconds;

        // Cuts names that don't fit instead of throwing like the FixedString constructor does in the Editor
        public static FixedString64Bytes ToName(string name)
        {
            var fixedName = new FixedString64Bytes();
            fixedName.CopyFromTruncated(name ?? string.Empty);
            return fixedName;
        }

        public readonly bool Equals(LobbyConfig other) =>
            Name.Equals(other.Name) &&
            Visibility == other.Visibility &&
            MaxPlayers == other.MaxPlayers &&
            MapIndex == other.MapIndex &&
            HideDurationInSeconds.Equals(other.HideDurationInSeconds) &&
            RoundDurationInSeconds.Equals(other.RoundDurationInSeconds);

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref Name);
            serializer.SerializeValue(ref Visibility);
            serializer.SerializeValue(ref MaxPlayers);
            serializer.SerializeValue(ref MapIndex);
            serializer.SerializeValue(ref HideDurationInSeconds);
            serializer.SerializeValue(ref RoundDurationInSeconds);
        }
    }
}
