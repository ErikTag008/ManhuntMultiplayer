using KBCore.Refs;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Player.Abilities;
using Project.Assets._Project._Scripts.SceneFlow.Maps;
using Project.Assets._Project._Scripts.UI.HUD;
using Reflex.Attributes;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Owner: in the lobby, opens the menu, fills it with the abilities, the maps and their votes and this player's picks, and sends
    // picks, map votes and ready toggles. Server: accepts them only while the player has no team yet, which is only the case in the lobby.
    [RequireComponent(typeof(PlayerTeam), typeof(InputReader))]
    public class PlayerLobbyChoices : NetworkBehaviour
    {
        [Inject] private readonly LobbyMenuState _lobbyMenuState;
        [Inject] private readonly AbilityCatalog _catalog;
        [Inject] private readonly PlayerSessionDirectory _sessionDirectory;
        [Inject] private readonly IPlayerRegistry _playerRegistry;
        [Inject] private readonly SessionMapCatalog _mapCatalog;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private InputReader _inputReader;

        private readonly List<LobbyOption> _optionBuffer = new();
        private readonly List<PlayerSession> _sessionBuffer = new();
        private readonly List<int> _voteCountBuffer = new();
        private bool _isInLobby;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            if (!IsOwner) return;

            _lobbyMenuState.OnAbilityPickRequested += HandleAbilityPickRequested;
            _lobbyMenuState.OnReadyToggleRequested += HandleReadyToggleRequested;
            _lobbyMenuState.OnMapVoteRequested += HandleMapVoteRequested;
            _sessionDirectory.OnSessionChanged += HandleSessionChanged;
            _sessionDirectory.OnSessionRemoved += HandleSessionRemoved;
            _inputReader.OnToggleMenu += HandleToggleMenu;
            _mapCatalog.OnChanged += HandleMapCatalogChanged;
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
            RefreshMapOptions();
            RefreshChoice();
            RefreshMapVotes();
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

        private void HandleMapVoteRequested(int mapIndex) => VoteMapServerRpc(mapIndex);

        private void HandleSessionChanged(PlayerSession session)
        {
            if (session.ClientId == OwnerClientId) RefreshChoice();
            if (_isInLobby) RefreshMapVotes();
        }

        // a client gets the server's map list (bundle maps included) after it may already be in the lobby
        private void HandleMapCatalogChanged()
        {
            if (!_isInLobby) return;

            RefreshMapOptions();
            RefreshMapVotes();
        }

        // a player who leaves takes their vote with them
        private void HandleSessionRemoved(ulong _)
        {
            if (_isInLobby) RefreshMapVotes();
        }

        // no pick yet shows the default the player will get
        private void RefreshChoice()
        {
            bool hasSession = _sessionDirectory.TryGetSession(OwnerClientId, out var session);
            var ability = _catalog.Resolve(hasSession ? session.AbilityId : PlayerSession.NoAbility);
            _lobbyMenuState.SetChoice(ability != null ? ability.Id : PlayerSession.NoAbility, hasSession && session.IsReady);
        }

        private void RefreshMapOptions()
        {
            _optionBuffer.Clear();
            for (int mapIndex = 0; mapIndex < _mapCatalog.MapCount; mapIndex++)
            {
                _optionBuffer.Add(new LobbyOption(mapIndex, _mapCatalog.GetMapDisplayName(mapIndex), _mapCatalog.GetMapPreview(mapIndex)));
            }

            _lobbyMenuState.SetMapOptions(_optionBuffer);
        }

        private void RefreshMapVotes()
        {
            _sessionBuffer.Clear();
            _sessionBuffer.AddRange(_sessionDirectory.Sessions);
            _voteCountBuffer.Clear();
            for (int mapIndex = 0; mapIndex < _mapCatalog.MapCount; mapIndex++)
            {
                _voteCountBuffer.Add(MapVoteTally.CountVotes(_sessionBuffer, mapIndex));
            }

            bool hasSession = _sessionDirectory.TryGetSession(OwnerClientId, out var session);
            int mapVote = hasSession && session.MapVote != PlayerSession.NoMapVote ? session.MapVote : LobbyMenuState.NoMapVote;
            _lobbyMenuState.SetMapVotes(_voteCountBuffer, mapVote);
        }

        [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Owner)]
        private void PickAbilityServerRpc(int abilityId)
        {
            if (_playerRegistry == null || _team.Team != Team.None || !_catalog.TryGet(abilityId, out _)) return;
            _playerRegistry.SetAbility(OwnerClientId, abilityId);
        }

        // any index outside the catalog takes the vote back
        [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Owner)]
        private void VoteMapServerRpc(int mapIndex)
        {
            if (_playerRegistry == null || _team.Team != Team.None) return;

            bool isValidMap = mapIndex >= 0 && mapIndex < _mapCatalog.MapCount;
            _playerRegistry.SetMapVote(OwnerClientId, isValidMap ? mapIndex : PlayerSession.NoMapVote);
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
            _lobbyMenuState.OnMapVoteRequested -= HandleMapVoteRequested;
            _sessionDirectory.OnSessionChanged -= HandleSessionChanged;
            _sessionDirectory.OnSessionRemoved -= HandleSessionRemoved;
            _inputReader.OnToggleMenu -= HandleToggleMenu;
            _mapCatalog.OnChanged -= HandleMapCatalogChanged;
            ExitLobby();
        }
    }
}
