using KBCore.Refs;
using Project.Assets._Project._Scripts.UI.HUD;
using Reflex.Attributes;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Owner only: pushes the round's runner counts and this player's bleed-out, rescue progress and ability cooldown into the gameplay HUD
    [RequireComponent(typeof(PlayerLifeState), typeof(PlayerRescue), typeof(PlayerAbility))]
    public class PlayerHUDFeed : NetworkBehaviour
    {
        [Inject] private readonly GameHUDState _hudState;
        [Inject] private readonly PlayerSessionDirectory _sessionDirectory;
        [Inject] private readonly RunnerStats _runnerStats;
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField, Self] private PlayerRescue _rescue;
        [SerializeField, Self] private PlayerAbility _ability;

        private bool _hasBleedOutStarted;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            if (!IsOwner) return;

            _sessionDirectory.OnSessionChanged += HandleSessionChanged;
            _sessionDirectory.OnSessionRemoved += HandleSessionRemoved;
            _lifeState.OnLifeStateChanged += HandleLifeStateChanged;
            RefreshRunnerCounts();
        }

        private void Update()
        {
            if (!IsSpawned || !IsOwner) return;

            RefreshBleedOut();
            RefreshRescue();
            RefreshAbility();
        }

        private void HandleSessionChanged(PlayerSession _) => RefreshRunnerCounts();

        // a runner who leaves mid-round no longer counts
        private void HandleSessionRemoved(ulong _) => RefreshRunnerCounts();

        private void HandleLifeStateChanged(LifeState _) => _hasBleedOutStarted = false;

        private void RefreshRunnerCounts()
        {
            var counts = RunnerCounts.From(_sessionDirectory.Sessions);
            _hudState.SetRunnerCounts(counts.Up, counts.Knocked, counts.Eliminated);
        }

        // The knocked state and the bleed-out end time come from different network objects, so right after a knock
        // the new end time may not have arrived yet. The server clears the end time when a bleed-out ends,
        // so until then it reads zero and the bar waits for a value above zero.
        private void RefreshBleedOut()
        {
            float remaining = _lifeState.BleedOutRemainingInSeconds;
            if (_lifeState.IsKnocked && remaining > 0f) _hasBleedOutStarted = true;

            bool isShown = _lifeState.IsKnocked && _hasBleedOutStarted;
            float progress = isShown ? remaining / _runnerStats.BleedOutDurationInSeconds : 0f;
            _hudState.SetBleedOut(isShown, isShown ? remaining : 0f, progress);
        }

        // progress is synced on both the rescuer and the knocked runner, and drops to zero when the rescue stops
        private void RefreshRescue()
        {
            float progress = _rescue.RescueProgress;
            _hudState.SetRescue(progress > 0f, progress);
        }

        // only runners have an ability, so catchers and the lobby show no slot
        private void RefreshAbility()
        {
            var ability = _ability.Ability;
            if (ability == null)
            {
                _hudState.SetAbility(false, null, null, 0f, 0f);
                return;
            }

            float remaining = _ability.CooldownRemainingInSeconds;
            float progress = ability.CooldownInSeconds > 0f ? remaining / ability.CooldownInSeconds : 0f;
            _hudState.SetAbility(true, ability.DisplayName, ability.ReadyHint, remaining, progress);
        }

        public override void OnNetworkDespawn()
        {
            if (!IsOwner) return;

            _sessionDirectory.OnSessionChanged -= HandleSessionChanged;
            _sessionDirectory.OnSessionRemoved -= HandleSessionRemoved;
            _lifeState.OnLifeStateChanged -= HandleLifeStateChanged;
            _hudState.SetBleedOut(false, 0f, 0f);
            _hudState.SetRescue(false, 0f);
            _hudState.SetAbility(false, null, null, 0f, 0f);
        }
    }
}
