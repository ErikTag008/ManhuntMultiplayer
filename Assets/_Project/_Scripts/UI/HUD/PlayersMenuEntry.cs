namespace Project.Assets._Project._Scripts.UI.HUD
{
    // One other player in the pause menu's player list
    public readonly struct PlayersMenuEntry
    {
        public readonly ulong ClientId;
        public readonly string Name;

        public PlayersMenuEntry(ulong clientId, string name)
        {
            ClientId = clientId;
            Name = name;
        }
    }
}
