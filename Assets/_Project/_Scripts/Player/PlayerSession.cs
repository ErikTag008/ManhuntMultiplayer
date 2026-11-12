using System;
using Unity.Collections;
using Unity.Netcode;

namespace Project.Assets._Project._Scripts.Player
{
    // One connected player's session data; the server-owned list in PlayerRegistry is its single source
    public struct PlayerSession : INetworkSerializable, IEquatable<PlayerSession>
    {
        public const int NoAbility = -1;

        public ulong ClientId;
        // 0 until Steam is integrated
        public ulong SteamId;
        public FixedString64Bytes DisplayName;
        public Team Team;
        public LifeState LifeState;
        // set by the lobby ability pick and ready-up (P1)
        public int AbilityId;
        public bool IsReady;

        public readonly bool Equals(PlayerSession other) =>
            ClientId == other.ClientId &&
            SteamId == other.SteamId &&
            DisplayName.Equals(other.DisplayName) &&
            Team == other.Team &&
            LifeState == other.LifeState &&
            AbilityId == other.AbilityId &&
            IsReady == other.IsReady;

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref ClientId);
            serializer.SerializeValue(ref SteamId);
            serializer.SerializeValue(ref DisplayName);
            serializer.SerializeValue(ref Team);
            serializer.SerializeValue(ref LifeState);
            serializer.SerializeValue(ref AbilityId);
            serializer.SerializeValue(ref IsReady);
        }
    }
}
