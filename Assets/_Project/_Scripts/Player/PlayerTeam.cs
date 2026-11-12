using Reflex.Attributes;
using System;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Applies the team from this player's session (stats and model) on every instance; PlayerRegistry owns the value
    public class PlayerTeam : NetworkBehaviour
    {
        [Inject] private readonly PlayerStats _defaultStats;
        [Inject] private readonly CatcherStats _catcherStats;
        [Inject] private readonly RunnerStats _runnerStats;
        [Inject] private readonly PlayerSessionDirectory _sessionDirectory;
        [SerializeField] private Transform _model;

        public event Action<PlayerStats> OnStatsChanged;
        public event Action<Transform> OnModelChanged;

        private Team _team;
        private PlayerStats _currentStats;

        public Team Team => _team;
        public PlayerStats CurrentStats => _currentStats;
        public Transform Model => _model;

        // The session may not exist yet (it's added when the player reaches the lobby), so start from no team
        public override void OnNetworkSpawn()
        {
            _sessionDirectory.OnSessionChanged += HandleSessionChanged;
            var team = _sessionDirectory.TryGetSession(OwnerClientId, out var session) ? session.Team : Team.None;
            ApplyTeam(team);
        }

        private void HandleSessionChanged(PlayerSession session)
        {
            if (session.ClientId != OwnerClientId || session.Team == _team) return;
            ApplyTeam(session.Team);
        }

        private void ApplyTeam(Team team)
        {
            _team = team;
            _currentStats = team switch
            {
                Team.Catcher => _catcherStats,
                Team.Runner => _runnerStats,
                _ => _defaultStats
            };

            ChangeModel(_currentStats.Model);
            OnStatsChanged?.Invoke(_currentStats);
        }

        private void ChangeModel(Transform modelPrefab)
        {
            if (modelPrefab == null) return;

            if (_model != null) Destroy(_model.gameObject);
            _model = Instantiate(modelPrefab, transform);

            // the owner looks through the model's eyes, so it must not see its own body
            if (IsOwner) _model.GetComponentInChildren<Renderer>().enabled = false;
            OnModelChanged?.Invoke(_model);
        }

        public override void OnNetworkDespawn() => _sessionDirectory.OnSessionChanged -= HandleSessionChanged;
    }

    public enum Team
    {
        None,
        Catcher,
        Runner
    }
}
