using KBCore.Refs;
using Project.Assets._Project._Scripts.UI;
using Reflex.Attributes;
using System;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Catchers are held while the runners hide: no moving or catching, and a blindfold on their own screen.
    // Every instance works it out from the replicated hide phase and team, so the server can refuse a held catcher's catch.
    [RequireComponent(typeof(PlayerTeam))]
    public class PlayerHideHold : NetworkBehaviour
    {
        [Inject] private readonly HidePhase _hidePhase;
        [Inject] private readonly IUIManager _uiManager;
        [SerializeField, Self] private PlayerTeam _team;

        public event Action<bool> OnHeldChanged;

        private bool _isHeld;

        public bool IsHeld => _isHeld;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            _hidePhase.OnChanged += HandleHidePhaseChanged;
            _team.OnStatsChanged += HandleStatsChanged;
        }

        // every OnNetworkSpawn has run by now, so the team is applied whatever the component order
        protected override void OnNetworkPostSpawn() => RefreshHeld();

        private void HandleHidePhaseChanged(bool _) => RefreshHeld();

        private void HandleStatsChanged(PlayerStats _) => RefreshHeld();

        private void RefreshHeld() => ToggleHeld(_hidePhase.IsActive && _team.Team == Team.Catcher);

        private void ToggleHeld(bool isHeld)
        {
            if (_isHeld == isHeld) return;

            _isHeld = isHeld;
            if (IsOwner) _uiManager.ToggleBlindfold(isHeld);
            OnHeldChanged?.Invoke(isHeld);
        }

        public override void OnNetworkDespawn()
        {
            _hidePhase.OnChanged -= HandleHidePhaseChanged;
            _team.OnStatsChanged -= HandleStatsChanged;
            ToggleHeld(false);
        }
    }
}
