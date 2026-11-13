using Project.Assets._Project._Scripts.Player;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    // Single source of player session data: a server-written NetworkList, mirrored into PlayerSessionDirectory on every instance
    public class PlayerRegistry : NetworkBehaviour, IPlayerRegistry
    {
        [SerializeField] private string _defaultDisplayNameFormat = "Player {0}";

        public event Action OnSessionsChanged;

        private readonly List<PlayerController> _players = new();
        private readonly NetworkList<PlayerSession> _sessions = new();
        private GameSystemsRegistry _gameSystemsRegistry;
        private PlayerSessionDirectory _sessionDirectory;

        public int PlayerCount => _sessions.Count;

        // Kept idempotent: IPlayerRegistry is a transient factory, so each resolve injects this again
        [Inject]
        private void RegisterInGameSystems(GameSystemsRegistry gameSystemsRegistry, PlayerSessionDirectory sessionDirectory)
        {
            _gameSystemsRegistry = gameSystemsRegistry;
            _sessionDirectory = sessionDirectory;
            _gameSystemsRegistry.Register(this);
        }

        // GameManager injects GameSystems in its own OnNetworkSpawn, so the directory is only certain to be set here
        protected override void OnNetworkPostSpawn()
        {
            _sessions.OnListChanged += HandleSessionsChanged;
            MirrorAllSessions();
        }

        public List<PlayerController> GetPlayers() => _players;

        public bool TryGetSession(ulong clientId, out PlayerSession session)
        {
            int index = IndexOf(clientId);
            session = index >= 0 ? _sessions[index] : default;
            return index >= 0;
        }

        public void CopySessionsTo(List<PlayerSession> buffer)
        {
            buffer.Clear();
            foreach (var session in _sessions) buffer.Add(session);
        }

        public void RegisterPlayer(PlayerController player)
        {
            if (!IsServer) return;

            if (!_players.Contains(player)) _players.Add(player);
            if (IndexOf(player.OwnerClientId) >= 0) return;

            _sessions.Add(new PlayerSession
            {
                ClientId = player.OwnerClientId,
                DisplayName = string.Format(_defaultDisplayNameFormat, player.OwnerClientId),
                Team = Team.None,
                LifeState = LifeState.Up,
                AbilityId = PlayerSession.NoAbility
            });
            EUtils.Logger.Log($"[PlayerRegistry] Registered player {player.OwnerClientId}. Total: {_sessions.Count}");
        }

        // Despawn order on shutdown is arbitrary, so the list may already be gone
        public void UnregisterPlayer(PlayerController player)
        {
            if (!IsServer || !IsSpawned) return;

            _players.Remove(player);
            int index = IndexOf(player.OwnerClientId);
            if (index >= 0) _sessions.RemoveAt(index);
        }

        public void SetTeam(ulong clientId, Team team) => UpdateSession(clientId, (ref PlayerSession session) => session.Team = team);

        public void SetLifeState(ulong clientId, LifeState lifeState) => UpdateSession(clientId, (ref PlayerSession session) => session.LifeState = lifeState);

        public void SetAbility(ulong clientId, int abilityId) => UpdateSession(clientId, (ref PlayerSession session) => session.AbilityId = abilityId);

        public void SetReady(ulong clientId, bool isReady) => UpdateSession(clientId, (ref PlayerSession session) => session.IsReady = isReady);

        public void ResetLifeStates()
        {
            for (int i = 0; i < _sessions.Count; i++)
            {
                SetLifeState(_sessions[i].ClientId, LifeState.Up);
            }
        }

        // Teams are rolled each round, so the lobby is neutral: default model, no weapon, everyone up and not ready.
        // The ability pick is kept between rounds.
        public void ResetForLobby()
        {
            for (int i = 0; i < _sessions.Count; i++)
            {
                UpdateSession(_sessions[i].ClientId, (ref PlayerSession session) =>
                {
                    session.Team = Team.None;
                    session.LifeState = LifeState.Up;
                    session.IsReady = false;
                });
            }
        }

        private delegate void SessionChange(ref PlayerSession session);

        // Writes only real changes, so no-op resets don't send list events
        private void UpdateSession(ulong clientId, SessionChange change)
        {
            if (!IsServer) return;

            int index = IndexOf(clientId);
            if (index < 0) return;

            var session = _sessions[index];
            change(ref session);
            if (session.Equals(_sessions[index])) return;

            _sessions[index] = session;
        }

        private int IndexOf(ulong clientId)
        {
            for (int i = 0; i < _sessions.Count; i++)
            {
                if (_sessions[i].ClientId == clientId) return i;
            }
            return -1;
        }

        private void HandleSessionsChanged(NetworkListEvent<PlayerSession> listEvent)
        {
            switch (listEvent.Type)
            {
                case NetworkListEvent<PlayerSession>.EventType.Add:
                case NetworkListEvent<PlayerSession>.EventType.Insert:
                case NetworkListEvent<PlayerSession>.EventType.Value:
                    _sessionDirectory.Set(listEvent.Value);
                    break;
                case NetworkListEvent<PlayerSession>.EventType.Remove:
                case NetworkListEvent<PlayerSession>.EventType.RemoveAt:
                    _sessionDirectory.Remove(listEvent.Value.ClientId);
                    break;
                default:
                    MirrorAllSessions();
                    break;
            }

            OnSessionsChanged?.Invoke();
        }

        private void MirrorAllSessions()
        {
            _sessionDirectory.Clear();
            foreach (var session in _sessions) _sessionDirectory.Set(session);
        }

        public override void OnNetworkDespawn()
        {
            _sessions.OnListChanged -= HandleSessionsChanged;
            _sessionDirectory?.Clear();
        }

        public override void OnDestroy()
        {
            _gameSystemsRegistry?.Unregister(this);
            base.OnDestroy();
        }
    }
}
