using KBCore.Refs;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Player.Abilities;
using Project.Assets._Project._Scripts.UI.HUD;
using Reflex.Attributes;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Owner: in the lobby, opens the menu, fills it with the abilities and this player's pick, and sends picks and ready toggles.
    // Server: accepts them only while the player has no team yet, which is only the case in the lobby.
    [RequireComponent(typeof(PlayerTeam), typeof(InputReader))]
    public class PlayerLobbyChoices : NetworkBehaviour
    {
        [Inject] private readonly LobbyMenuState _lobbyMenuState;
        [Inject] private readonly AbilityCatalog _catalog;
        [Inject] private readonly PlayerSessionDirectory _sessionDirectory;
        [Inject] private readonly IPlayerRegistry _playerRegistry;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private InputReader _inputReader;

        private readonly List<LobbyOption> _optionBuffer = new();
        private bool _isInLobby;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            if (!IsOwner) return;

            _lobbyMenuState.OnAbilityPickRequested += HandleAbilityPickRequested;
            _lobbyMenuState.OnReadyToggleRequested += HandleReadyToggleRequested;
            _sessionDirectory.OnSessionChanged += HandleSessionChanged;
            _inputReader.OnToggleMenu += HandleToggleMenu;
        }

        // Owner only
        public void EnterLobby()
        {
            if (!IsOwner) return;

            _isInLobby = true;
            _optionBuffer.Clear();
            foreach (var ability in _catalog.Abilities)
            {
                if (ability != null) _optionBuffer.Add(new LobbyOption(ability.Id, ability.DisplayName));
            }

            _lobbyMenuState.SetAbilityOptions(_optionBuffer);
            RefreshChoice();
            _lobbyMenuState.ToggleOpen(true);
        }

        // Owner only
        public void ExitLobby()
        {
            if (!IsOwner) return;

            _isInLobby = false;
            _lobbyMenuState.ToggleOpen(false);
        }

        private void HandleToggleMenu()
        {
            if (_isInLobby) _lobbyMenuState.ToggleOpen(!_lobbyMenuState.IsOpen);
        }

        private void HandleAbilityPickRequested(int abilityId) => PickAbilityServerRpc(abilityId);

        private void HandleReadyToggleRequested()
        {
            bool isReady = _sessionDirectory.TryGetSession(OwnerClientId, out var session) && session.IsReady;
            SetReadyServerRpc(!isReady);
        }

        private void HandleSessionChanged(PlayerSession session)
        {
            if (session.ClientId == OwnerClientId) RefreshChoice();
        }

        // no pick yet shows the default the player will get
        private void RefreshChoice()
        {
            bool hasSession = _sessionDirectory.TryGetSession(OwnerClientId, out var session);
            var ability = _catalog.Resolve(hasSession ? session.AbilityId : PlayerSession.NoAbility);
            _lobbyMenuState.SetChoice(ability != null ? ability.Id : PlayerSession.NoAbility, hasSession && session.IsReady);
        }

        [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Owner)]
        private void PickAbilityServerRpc(int abilityId)
        {
            if (_playerRegistry == null || _team.Team != Team.None || !_catalog.TryGet(abilityId, out _)) return;
            _playerRegistry.SetAbility(OwnerClientId, abilityId);
        }

        [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Owner)]
        private void SetReadyServerRpc(bool isReady)
        {
            if (_playerRegistry == null || _team.Team != Team.None) return;
            _playerRegistry.SetReady(OwnerClientId, isReady);
        }

        public override void OnNetworkDespawn()
        {
            if (!IsOwner) return;

            _lobbyMenuState.OnAbilityPickRequested -= HandleAbilityPickRequested;
            _lobbyMenuState.OnReadyToggleRequested -= HandleReadyToggleRequested;
            _sessionDirectory.OnSessionChanged -= HandleSessionChanged;
            _inputReader.OnToggleMenu -= HandleToggleMenu;
            ExitLobby();
        }
    }
}
