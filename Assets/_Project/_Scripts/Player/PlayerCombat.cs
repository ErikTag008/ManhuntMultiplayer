using KBCore.Refs;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Player.Drops;
using Project.Assets._Project._Scripts.Weapons;
using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Holds the team's weapon; the owner attacks, the server resolves the catch
    [RequireComponent(typeof(PlayerTeam), typeof(InputReader), typeof(PlayerHideHold))]
    public class PlayerCombat : NetworkBehaviour
    {
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField, Self] private PlayerHideHold _hideHold;
        [SerializeField] private Transform _weaponPivot;
        [SerializeField] private int _maxCatchTargets = 3;

        public event Action<MeleeWeaponBase> OnWeaponChanged;

        private MeleeWeaponBase _currentWeapon;
        private Collider[] _catchTargets;
        // a runner with several colliders is hit once per catch, so a shield can't be used up and then knocked through
        private readonly List<PlayerTeam> _caughtTeams = new();
        private bool _isAttackInputBound;

        public MeleeWeaponBase CurrentWeapon => _currentWeapon;

        private void OnValidate() => this.ValidateRefs();

        private void Awake() => _catchTargets = new Collider[_maxCatchTargets];

        public override void OnNetworkSpawn()
        {
            _team.OnStatsChanged += HandleStatsChanged;
            _hideHold.OnHeldChanged += HandleHeldChanged;
        }

        // every OnNetworkSpawn has run by now, so PlayerTeam's stats are applied whatever the component order
        protected override void OnNetworkPostSpawn() => HandleStatsChanged(_team.CurrentStats);

        private void HandleStatsChanged(PlayerStats stats)
        {
            if (stats == null) return;

            ReplaceWeapon(stats.WeaponPrefab);
            RefreshAttackInput();
        }

        private void HandleHeldChanged(bool _) => RefreshAttackInput();

        // a catcher held during the hide phase can't swing
        private void RefreshAttackInput() => ToggleAttackInput(IsOwner && _team.Team == Team.Catcher && _currentWeapon != null && !_hideHold.IsHeld);

        private void ReplaceWeapon(MeleeWeaponBase weaponPrefab)
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.OnCheckDamageRequested -= RequestCatchServerRpc;
                Destroy(_currentWeapon.gameObject);
                _currentWeapon = null;
            }

            if (weaponPrefab != null)
            {
                _currentWeapon = Instantiate(weaponPrefab, _weaponPivot);
                // only the owner swings, so only its weapon asks the server to resolve a hit
                if (IsOwner) _currentWeapon.OnCheckDamageRequested += RequestCatchServerRpc;
            }

            OnWeaponChanged?.Invoke(_currentWeapon);
        }

        private void ToggleAttackInput(bool isEnabled)
        {
            if (_isAttackInputBound == isEnabled) return;

            _isAttackInputBound = isEnabled;
            if (isEnabled) _inputReader.OnAttack += PerformAttack;
            else _inputReader.OnAttack -= PerformAttack;
        }

        private void PerformAttack()
        {
            if (_currentWeapon != null) _currentWeapon.Attack();
        }

        // A catcher's hit knocks every runner inside the weapon's hit sphere; other catchers are ignored
        [Rpc(SendTo.Server)]
        private void RequestCatchServerRpc(Vector3 hitOrigin, float radius)
        {
            if (_team.Team != Team.Catcher || _hideHold.IsHeld) return;

            int hitCount = Physics.OverlapSphereNonAlloc(hitOrigin, radius, _catchTargets, _team.CurrentStats.AttackRaycastLayer);
            _caughtTeams.Clear();
            for (int i = 0; i < hitCount; i++)
            {
                var targetTeam = _catchTargets[i].GetComponentInParent<PlayerTeam>();
                if (targetTeam == null || targetTeam == _team || targetTeam.Team != Team.Runner) continue;
                if (_caughtTeams.Contains(targetTeam)) continue;

                _caughtTeams.Add(targetTeam);

                if (!targetTeam.TryGetComponent(out PlayerLifeState targetLifeState)) continue;
                if (IsBlockedByShield(targetTeam, targetLifeState)) continue;

                targetLifeState.Knock();
            }
        }

        // Server only: a shield drop takes the hit instead of the runner; only a catch that would knock uses it up
        private static bool IsBlockedByShield(PlayerTeam targetTeam, PlayerLifeState targetLifeState)
        {
            if (!targetLifeState.IsUp || targetLifeState.IsInvulnerable) return false;
            return targetTeam.TryGetComponent(out PlayerDropEffects targetDropEffects) && targetDropEffects.TryConsumeShield();
        }

        public override void OnNetworkDespawn()
        {
            _team.OnStatsChanged -= HandleStatsChanged;
            _hideHold.OnHeldChanged -= HandleHeldChanged;
            ToggleAttackInput(false);
        }
    }
}
