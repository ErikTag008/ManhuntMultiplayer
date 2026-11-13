using System;

namespace Project.Assets._Project._Scripts.Networking
{
    // One lobby as the browser shows it; also the JSON advert a local host writes (JsonUtility, so public fields)
    [Serializable]
    public class LobbyListing
    {
        public const int UnknownPing = -1;

        public string Id;
        public string Name;
        public string HostName;
        public string MapName;
        public int PlayerCount;
        public int MaxPlayers;
        public bool IsInProgress;
        public LobbyVisibility Visibility;
        public string Region;
        public int PingInMilliseconds = UnknownPing;
        public string Address;
        public ushort Port;
        public long LastUpdatedUtcTicks;

        public bool IsFull => PlayerCount >= MaxPlayers;
        public bool HasPing => PingInMilliseconds >= 0;
    }
}
