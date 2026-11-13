using Project.Assets._Project._Scripts.Networking;
using Reflex.Attributes;
using Unity.Netcode;

namespace Project.Assets._Project._Scripts.Managers
{
    // Shares the host's LobbyConfig: the server copies ActiveLobbyConfig in, clients copy it back out into their own ActiveLobbyConfig
    public class LobbyConfigSync : NetworkBehaviour
    {
        [Inject] private readonly ActiveLobbyConfig _activeLobbyConfig;

        private readonly NetworkVariable<LobbyConfig> _config = new();

        public LobbyConfig Config => _config.Value;

        // GameManager injects GameSystems in its own OnNetworkSpawn, so the injected config is only certain to be set here
        protected override void OnNetworkPostSpawn()
        {
            if (IsServer)
            {
                _config.Value = _activeLobbyConfig.Config;
                // the lobby can change the config later (P2-28)
                _activeLobbyConfig.OnChanged += HandleActiveConfigChanged;
                return;
            }

            _config.OnValueChanged += HandleConfigValueChanged;
            _activeLobbyConfig.Set(_config.Value);
        }

        private void HandleActiveConfigChanged(LobbyConfig config) => _config.Value = config;

        private void HandleConfigValueChanged(LobbyConfig previous, LobbyConfig current) => _activeLobbyConfig.Set(current);

        public override void OnNetworkDespawn()
        {
            if (_activeLobbyConfig != null) _activeLobbyConfig.OnChanged -= HandleActiveConfigChanged;
            _config.OnValueChanged -= HandleConfigValueChanged;
        }
    }
}
