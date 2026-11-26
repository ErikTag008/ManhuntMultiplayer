using KBCore.Refs;
using Project.Assets._Project._Scripts.Weapons;
using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // While a round's map loads the body still stands at its lobby spot, which is somewhere random in the new map.
    // From the load until the server places it at its round spawn the body is hidden on every instance, and the owner
    // floats still. Other instances show it once their synced position has caught up with the spawn, so the old spot
    // never flashes up. A placement that never comes lets go after a while.
    [RequireComponent(typeof(Rigidbody), typeof(PlayerTeam), typeof(PlayerGhost))]
    [RequireComponent(typeof(PlayerCombat))]
    public class PlayerRoundPlacement : NetworkBehaviour
    {
        [SerializeField, Self] private Rigidbody _rb;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private PlayerGhost _ghost;
        [SerializeField, Self] private PlayerCombat _combat;
        // a synced position this close to the spawn counts as arrived
        [SerializeField, Min(0f)] private float _arrivedDistanceInMeters = 1f;
        // other instances show the body after this long even if its position hasn't arrived yet
        [SerializeField, Min(0f)] private float _revealMaxWaitInSeconds = 1f;
        // a map load that takes longer than this gives the body back without a placement
        [SerializeField, Min(0f)] private float _holdMaxInSeconds = 60f;

        // fires on the owner when movement should stop or come back
        public event Action<bool> OnHoldingChanged;

        private readonly NetworkVariable<Vector3> _placedPosition = new();
        private readonly NetworkVariable<bool> _isAwaitingPlacement = new();
        private readonly List<Renderer> _rendererBuffer = new();
        private readonly List<Renderer> _hiddenRenderers = new();
        private bool _isHidden;
        private bool _isHolding;
        private float _holdEndTime;
        private float _revealDeadline;

        public bool IsHidden => _isHidden;
        // Owner only
        public bool IsHolding => _isHolding;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            _isAwaitingPlacement.OnValueChanged += HandleAwaitingPlacementChanged;
            _team.OnModelChanged += HandleModelChanged;
            _combat.OnWeaponChanged += HandleWeaponChanged;
            // the spawn value doesn't raise OnValueChanged
            if (_isAwaitingPlacement.Value) StartAwaiting();
        }

        // arrival is checked here, after the whole delta (spawn and flag) has been applied
        private void Update()
        {
            if (!_isHidden) return;

            if (Time.time >= _holdEndTime)
            {
                StopHolding();
                Reveal();
                return;
            }

            if (_isAwaitingPlacement.Value) return;
            if (IsOwner || HasArrived() || Time.time >= _revealDeadline) Reveal();
        }

        private void FixedUpdate()
        {
            if (!_isHolding) return;

            _rb.useGravity = false;
            _rb.linearVelocity = Vector3.zero;
        }

        // Server only: before the round's map loads
        public void StartAwaitingPlacement()
        {
            if (!IsServer || _isAwaitingPlacement.Value) return;

            _isAwaitingPlacement.Value = true;
        }

        // Server only: after the teleport to the round spawn was sent
        public void StopAwaitingPlacement(Vector3 placedPosition)
        {
            if (!IsServer || !_isAwaitingPlacement.Value) return;

            _placedPosition.Value = placedPosition;
            _isAwaitingPlacement.Value = false;
        }

        private void HandleAwaitingPlacementChanged(bool _, bool isAwaiting)
        {
            if (isAwaiting)
            {
                StartAwaiting();
                return;
            }

            _revealDeadline = Time.time + _revealMaxWaitInSeconds;
            StopHolding();
        }

        private void StartAwaiting()
        {
            _holdEndTime = Time.time + _holdMaxInSeconds;
            HideBody();
            StartHolding();
        }

        // a team change during the load swaps in a new, visible model
        private void HandleModelChanged(Transform model)
        {
            if (_isHidden && model != null) HideRenderers(model);
        }

        // the team's weapon is made after its model, so it isn't covered by the model's hide
        private void HandleWeaponChanged(MeleeWeaponBase weapon)
        {
            if (_isHidden && weapon != null) HideRenderers(weapon.transform);
        }

        private bool HasArrived() => (transform.position - _placedPosition.Value).sqrMagnitude <= _arrivedDistanceInMeters * _arrivedDistanceInMeters;

        private void HideBody()
        {
            _isHidden = true;
            if (_team.Model != null) HideRenderers(_team.Model);
        }

        // a renderer someone else already hid (a ghost) stays theirs to restore
        private void HideRenderers(Transform visual)
        {
            visual.GetComponentsInChildren(true, _rendererBuffer);
            foreach (var renderer in _rendererBuffer)
            {
                if (renderer.forceRenderingOff) continue;

                renderer.forceRenderingOff = true;
                _hiddenRenderers.Add(renderer);
            }
        }

        // a player who turned ghost meanwhile stays invisible
        private void Reveal()
        {
            RestoreRenderers();
            _ghost.MatchGhostVisibility(_team.Model);
        }

        private void RestoreRenderers()
        {
            _isHidden = false;
            foreach (var renderer in _hiddenRenderers)
            {
                if (renderer != null) renderer.forceRenderingOff = false;
            }
            _hiddenRenderers.Clear();
        }

        private void StartHolding()
        {
            if (!IsOwner || _isHolding) return;

            _isHolding = true;
            OnHoldingChanged?.Invoke(true);
        }

        // gravity is the body's normal state; a ghost turns it off again on its next step
        private void StopHolding()
        {
            if (!_isHolding) return;

            _isHolding = false;
            _rb.useGravity = true;
            OnHoldingChanged?.Invoke(false);
        }

        public override void OnNetworkDespawn()
        {
            _isAwaitingPlacement.OnValueChanged -= HandleAwaitingPlacementChanged;
            _team.OnModelChanged -= HandleModelChanged;
            _combat.OnWeaponChanged -= HandleWeaponChanged;
            // a body despawned mid-hold gets its renderers and gravity back
            StopHolding();
            RestoreRenderers();
        }
    }
}
