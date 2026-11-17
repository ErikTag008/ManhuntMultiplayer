namespace Project.Assets._Project._Scripts.Voice
{
    // Another player whose voice this instance can hear
    public readonly struct VoicePeer
    {
        public readonly ulong ClientId;
        public readonly string DisplayName;

        public VoicePeer(ulong clientId, string displayName)
        {
            ClientId = clientId;
            DisplayName = displayName;
        }
    }
}
