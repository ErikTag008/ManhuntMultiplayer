using System;
using Unity.Netcode;

namespace Project.Assets._Project._Scripts.Player
{
    public struct PlayerInfo : INetworkSerializable, IEquatable<PlayerInfo>
    {
        public ulong ClientId;
        public Team Team;

        public bool Equals(PlayerInfo other)
        {
            return ClientId == other.ClientId && Team == other.Team;
        }

        public void NetworkSerialize<T>(BufferSerializer<T> serializer)
            where T : IReaderWriter
        {
            serializer.SerializeValue(ref ClientId);
            serializer.SerializeValue(ref Team);
        }
    }
}
