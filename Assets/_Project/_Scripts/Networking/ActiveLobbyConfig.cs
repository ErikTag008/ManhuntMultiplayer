using System;

namespace Project.Assets._Project._Scripts.Networking
{
    // The config of the current (or last) session on this instance. The host sets it before hosting;
    // clients receive it through LobbyConfigSync. Starts at the defaults so nothing ever reads an empty config.
    public class ActiveLobbyConfig
    {
        private LobbyConfig _config;

        public event Action<LobbyConfig> OnChanged;

        public LobbyConfig Config => _config;

        public ActiveLobbyConfig(LobbyConfigData lobbyConfigData)
        {
            _config = lobbyConfigData.CreateDefault();
        }

        public void Set(LobbyConfig config)
        {
            if (_config.Equals(config)) return;

            _config = config;
            OnChanged?.Invoke(config);
        }
    }
}
