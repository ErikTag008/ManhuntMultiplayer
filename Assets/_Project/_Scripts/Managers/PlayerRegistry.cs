using Project.Assets._Project._Scripts.Networking;
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
        [Inject] private readonly IConnectionService _connectionService;
        [SerializeField] private string _defaultDisplayNameFormat = "Player {0}";

        public event Action OnSessionsChanged;
        // Server only
        public event Action<ulong> OnBledOut;

        private readonly List<PlayerController> _players = new();
        private readonly NetworkList<PlayerSession> _sessions = new();
        private GameSystemsRegistry _gameSystemsRegistry;
        private PlayerSessionDirectory _sessionDirectory;
        // lives as long as the hosted session, so a player who leaves and rejoins goes to the back
        private int _lastCatcherQueueOrder;

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
                DisplayName = GetDisplayName(player.OwnerClientId),
                Team = Team.None,
                LifeState = LifeState.Up,
                AbilityId = PlayerSession.NoAbility,
                MapVote = PlayerSession.NoMapVote,
                CatcherQueueOrder = TakeNextCatcherQueueOrder()
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

        public void Knock(ulong clientId) => UpdateSession(clientId, (ref PlayerSession session) =>
        {
            session.LifeState = LifeState.Knocked;
            session.Knocks++;
        });

        public void ReportBledOut(ulong clientId)
        {
            if (!IsServer) return;
            OnBledOut?.Invoke(clientId);
        }

        // Infection: the runner joins the catchers standing, in one session change so no instance sees a catcher still knocked
        public void Infect(ulong clientId) => UpdateSession(clientId, (ref PlayerSession session) =>
        {
            session.Team = Team.Catcher;
            session.LifeState = LifeState.Up;
        });

        public bool TryGetPlayer(ulong clientId, out PlayerController player)
        {
            foreach (var registeredPlayer in _players)
            {
                if (registeredPlayer == null || registeredPlayer.OwnerClientId != clientId) continue;

                player = registeredPlayer;
                return true;
            }

            player = null;
            return false;
        }

        public void SetAbility(ulong clientId, int abilityId) => UpdateSession(clientId, (ref PlayerSession session) => session.AbilityId = abilityId);

        public void SetReady(ulong clientId, bool isReady) => UpdateSession(clientId, (ref PlayerSession session) => session.IsReady = isReady);

        public void SetMapVote(ulong clientId, int mapIndex) => UpdateSession(clientId, (ref PlayerSession session) => session.MapVote = mapIndex);

        public void MoveToBackOfCatcherQueue(ulong clientId)
        {
            if (!IsServer || IndexOf(clientId) < 0) return;

            int order = TakeNextCatcherQueueOrder();
            UpdateSession(clientId, (ref PlayerSession session) => session.CatcherQueueOrder = order);
        }

        public void ResetLifeStates()
        {
            for (int i = 0; i < _sessions.Count; i++)
            {
                SetLifeState(_sessions[i].ClientId, LifeState.Up);
            }
        }

        public void AddCatch(ulong clientId) => UpdateSession(clientId, (ref PlayerSession session) => session.Catches++);

        public void AddRescue(ulong clientId) => UpdateSession(clientId, (ref PlayerSession session) => session.Rescues++);

        public void AddStationCompleted(ulong clientId) => UpdateSession(clientId, (ref PlayerSession session) => session.StationsCompleted++);

        public void RecordChase(ulong clientId, float durationInSeconds) => UpdateSession(clientId, (ref PlayerSession session) =>
            session.LongestChaseInSeconds = Mathf.Max(session.LongestChaseInSeconds, durationInSeconds));

        public void ResetRoundStats()
        {
            for (int i = 0; i < _sessions.Count; i++)
            {
                UpdateSession(_sessions[i].ClientId, (ref PlayerSession session) =>
                {
                    session.Catches = 0;
                    session.Rescues = 0;
                    session.StationsCompleted = 0;
                    session.LongestChaseInSeconds = 0f;
                    session.Knocks = 0;
                });
            }
        }

        // nobody is left to rescue them, so their bleed-out ends here instead of running on through the results
        public void EliminateKnockedPlayers()
        {
            for (int i = 0; i < _sessions.Count; i++)
            {
                if (_sessions[i].LifeState == LifeState.Knocked) SetLifeState(_sessions[i].ClientId, LifeState.Eliminated);
            }
        }

        // Teams are picked each round, so the lobby is neutral: default model, no weapon, everyone up and not ready.
        // Each match gets a fresh map vote; the ability pick is kept between rounds.
        public void ResetForLobby()
        {
            for (int i = 0; i < _sessions.Count; i++)
            {
                UpdateSession(_sessions[i].ClientId, (ref PlayerSession session) =>
                {
                    session.Team = Team.None;
                    session.LifeState = LifeState.Up;
                    session.IsReady = false;
                    session.MapVote = PlayerSession.NoMapVote;
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

        private int TakeNextCatcherQueueOrder() => ++_lastCatcherQueueOrder;

        // the name the client connected with (Steam), else the numbered default
        private string GetDisplayName(ulong clientId) =>
            _connectionService.TryGetPlayerName(clientId, out var name) ? name : string.Format(_defaultDisplayNameFormat, clientId);

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
