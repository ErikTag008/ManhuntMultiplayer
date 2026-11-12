using Reflex.Attributes;
using System;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Owns the player's team and applies the matching stats and model on every instance
    public class PlayerTeam : NetworkBehaviour
    {
        [Inject] private readonly PlayerStats _defaultStats;
        [Inject] private readonly CatcherStats _catcherStats;
        [Inject] private readonly RunnerStats _runnerStats;
        [SerializeField] private Transform _model;

        public event Action<PlayerStats> OnStatsChanged;
        public event Action<Transform> OnModelChanged;

        private readonly NetworkVariable<Team> _team = new();
        private PlayerStats _currentStats;

        public Team Team => _team.Value;
        public PlayerStats CurrentStats => _currentStats;
        public Transform Model => _model;

        // Applying the current value here also covers late joiners, since initial values don't raise OnValueChanged
        public override void OnNetworkSpawn()
        {
            _team.OnValueChanged += HandleTeamChanged;
            ApplyTeam(_team.Value);
        }

        public void SetTeam(Team team)
        {
            if (!IsServer) return;
            _team.Value = team;
        }

        private void HandleTeamChanged(Team previous, Team current) => ApplyTeam(current);

        private void ApplyTeam(Team team)
        {
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

        public override void OnNetworkDespawn() => _team.OnValueChanged -= HandleTeamChanged;
    }

    public enum Team
    {
        None,
        Catcher,
        Runner
    }
}
