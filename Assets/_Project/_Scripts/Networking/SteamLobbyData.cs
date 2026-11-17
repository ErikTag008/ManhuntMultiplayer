namespace Project.Assets._Project._Scripts.Networking
{
    // Keys the host writes into its Steam lobby's data, for joiners and the lobby browser to read
    public static class SteamLobbyData
    {
        public const string HostSteamIdKey = "host_steam_id";
        public const string NameKey = "name";
        public const string MapIndexKey = "map_index";
        public const string ModeKey = "mode";
        public const string VersionKey = "version";
        public const string InProgressKey = "in_progress";

        public const string TrueValue = "1";
        public const string FalseValue = "0";
    }
}
