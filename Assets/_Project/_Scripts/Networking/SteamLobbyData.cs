namespace Project.Assets._Project._Scripts.Networking
{
    // Keys the host writes into its Steam lobby's data, for joiners and the lobby browser to read
    public static class SteamLobbyData
    {
        public const string HostSteamIdKey = "host_steam_id";
        public const string NameKey = "name";
        public const string MapIndexKey = "map_index";
        // the host resolves the name, since a browser's own map list can have other bundle maps at that index
        public const string MapNameKey = "map_name";
        public const string ModeKey = "mode";
        public const string VersionKey = "version";
        public const string InProgressKey = "in_progress";
        // ConnectionSettings.SteamLobbyGameId, so searches on a shared test app id only find this game
        public const string GameKey = "game";
        public const string HostNameKey = "host_name";
        public const string VisibilityKey = "visibility";
        // the host's two-letter country, shown as the lobby's region
        public const string CountryKey = "country";
        // the host's NetPingLocation, for browsers to estimate their ping to it
        public const string PingLocationKey = "ping_location";

        public const string TrueValue = "1";
        public const string FalseValue = "0";
    }
}
