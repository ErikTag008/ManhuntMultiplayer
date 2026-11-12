using KBCore.Refs;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Weapons;
using System;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Holds the team's weapon; the owner attacks, the server resolves the catch
    [RequireComponent(typeof(PlayerTeam), typeof(InputReader))]
    public class PlayerCombat : NetworkBehaviour
    {
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField] private Transform _weaponPivot;
        [SerializeField] private int _maxCatchTargets = 3;

        public event Action<MeleeWeaponBase> OnWeaponChanged;

        private MeleeWeaponBase _currentWeapon;
        private Collider[] _catchTargets;
        private bool _isAttackInputBound;

        public MeleeWeaponBase CurrentWeapon => _currentWeapon;

        private void OnValidate() => this.ValidateRefs();

        private void Awake() => _catchTargets = new Collider[_maxCatchTargets];

        public override void OnNetworkSpawn() => _team.OnStatsChanged += HandleStatsChanged;

        // every OnNetworkSpawn has run by now, so PlayerTeam's stats are applied whatever the component order
        protected override void OnNetworkPostSpawn() => HandleStatsChanged(_team.CurrentStats);

        private void HandleStatsChanged(PlayerStats stats)
        {
            if (stats == null) return;

            ReplaceWeapon(stats.WeaponPrefab);
            ToggleAttackInput(IsOwner && _team.Team == Team.Catcher && _currentWeapon != null);
        }

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
            if (_team.Team != Team.Catcher) return;

            int hitCount = Physics.OverlapSphereNonAlloc(hitOrigin, radius, _catchTargets, _team.CurrentStats.AttackRaycastLayer);
            for (int i = 0; i < hitCount; i++)
            {
                var targetTeam = _catchTargets[i].GetComponentInParent<PlayerTeam>();
                if (targetTeam == null || targetTeam == _team || targetTeam.Team != Team.Runner) continue;

                if (targetTeam.TryGetComponent(out PlayerLifeState targetLifeState)) targetLifeState.Knock();
            }
        }

        public override void OnNetworkDespawn()
        {
            _team.OnStatsChanged -= HandleStatsChanged;
            ToggleAttackInput(false);
        }
    }
}
