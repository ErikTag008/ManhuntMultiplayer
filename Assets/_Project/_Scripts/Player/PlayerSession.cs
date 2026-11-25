using System;
using Unity.Collections;
using Unity.Netcode;

namespace Project.Assets._Project._Scripts.Player
{
    // One connected player's session data; the server-owned list in PlayerRegistry is its single source
    public struct PlayerSession : INetworkSerializable, IEquatable<PlayerSession>
    {
        public const int NoAbility = -1;
        public const int NoMapVote = -1;

        public ulong ClientId;
        // 0 until Steam is integrated
        public ulong SteamId;
        public FixedString64Bytes DisplayName;
        public Team Team;
        public LifeState LifeState;
        // set by the lobby ability pick and ready-up (P1)
        public int AbilityId;
        public bool IsReady;
        // the lobby map vote, a GameScenes map index; cleared each time the lobby opens again
        public int MapVote;
        // catcher rotation: the lowest order is picked first; given out by the server on join and after each catcher turn
        public int CatcherQueueOrder;
        // round stats for the results highlights; the server resets them when teams are assigned
        public int Catches;
        public int Rescues;
        public int StationsCompleted;
        public float LongestChaseInSeconds;
        // knocks taken this round; each one shortens the next bleed-out (RunnerStats)
        public int Knocks;

        // joined after teams were picked: watches the round without a team, so it never counts for a win or points
        public readonly bool IsSittingOut => Team == Team.None && LifeState == LifeState.Eliminated;

        public readonly bool Equals(PlayerSession other) =>
            ClientId == other.ClientId &&
            SteamId == other.SteamId &&
            DisplayName.Equals(other.DisplayName) &&
            Team == other.Team &&
            LifeState == other.LifeState &&
            AbilityId == other.AbilityId &&
            IsReady == other.IsReady &&
            MapVote == other.MapVote &&
            CatcherQueueOrder == other.CatcherQueueOrder &&
            Catches == other.Catches &&
            Rescues == other.Rescues &&
            StationsCompleted == other.StationsCompleted &&
            LongestChaseInSeconds == other.LongestChaseInSeconds &&
            Knocks == other.Knocks;

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref ClientId);
            serializer.SerializeValue(ref SteamId);
            serializer.SerializeValue(ref DisplayName);
            serializer.SerializeValue(ref Team);
            serializer.SerializeValue(ref LifeState);
            serializer.SerializeValue(ref AbilityId);
            serializer.SerializeValue(ref IsReady);
            serializer.SerializeValue(ref MapVote);
            serializer.SerializeValue(ref CatcherQueueOrder);
            serializer.SerializeValue(ref Catches);
            serializer.SerializeValue(ref Rescues);
            serializer.SerializeValue(ref StationsCompleted);
            serializer.SerializeValue(ref LongestChaseInSeconds);
            serializer.SerializeValue(ref Knocks);
        }
    }
}
