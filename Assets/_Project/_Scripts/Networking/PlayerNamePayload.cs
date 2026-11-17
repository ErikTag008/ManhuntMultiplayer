using System.Text;

namespace Project.Assets._Project._Scripts.Networking
{
    // A player's display name sent in NetworkConfig.ConnectionData, cut to fit PlayerSession.DisplayName
    public static class PlayerNamePayload
    {
        public static byte[] Encode(string name) => Encoding.UTF8.GetBytes(LobbyConfig.ToName(name).ToString());

        // The payload comes from the client, so it's cut again here; false when there's no usable name
        public static bool TryDecode(byte[] payload, out string name)
        {
            name = null;
            if (payload == null || payload.Length == 0) return false;

            name = LobbyConfig.ToName(Encoding.UTF8.GetString(payload)).ToString().Trim();
            return name.Length > 0;
        }
    }
}
