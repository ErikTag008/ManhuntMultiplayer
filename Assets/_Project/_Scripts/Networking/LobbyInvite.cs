namespace Project.Assets._Project._Scripts.Networking
{
    // A friend's invite to their lobby, received while the game runs
    public readonly struct LobbyInvite
    {
        public readonly ulong LobbyId;
        public readonly ulong FriendId;
        public readonly string FriendName;

        public LobbyInvite(ulong lobbyId, ulong friendId, string friendName)
        {
            LobbyId = lobbyId;
            FriendId = friendId;
            FriendName = friendName ?? string.Empty;
        }
    }
}
