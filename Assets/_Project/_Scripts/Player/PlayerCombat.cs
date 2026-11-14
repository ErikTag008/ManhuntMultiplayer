using Cysharp.Threading.Tasks;
using KBCore.Refs;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Player.Drops;
using Project.Assets._Project._Scripts.Weapons;
using System;
using System.Collections.Generic;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Holds the team's weapon in the model's hand; the owner swings, every instance plays the swing, the server resolves the catch
    [RequireComponent(typeof(PlayerTeam), typeof(InputReader), typeof(PlayerHideHold))]
    public class PlayerCombat : NetworkBehaviour
    {
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField, Self] private PlayerHideHold _hideHold;
        // used only when the model has no weapon socket
        [SerializeField] private Transform _weaponPivot;
        [SerializeField] private int _maxCatchTargets = 3;
        // the owner's clock and the server's can disagree slightly, so an honest swing may arrive a little early
        [SerializeField] private float _cooldownToleranceInSeconds = 0.1f;

        public event Action<MeleeWeaponBase> OnWeaponChanged;
        public event Action OnAttackStarted;

        private MeleeWeaponBase _currentWeapon;
        private Collider[] _catchTargets;
        // a runner with several colliders is hit once per catch, so a shield can't be used up and then knocked through
        private readonly List<PlayerTeam> _caughtTeams = new();
        private bool _isAttackInputBound;
        private float _nextAttackTime;
        private double _lastServerCatchTime = double.NegativeInfinity;
        private CancellationTokenSource _swingCTS = new();

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

        // the team's model is swapped just before its stats are announced, so the new hand already exists here
        private void HandleStatsChanged(PlayerStats stats)
        {
            if (stats == null) return;

            ReplaceWeapon(stats.WeaponPrefab);
            RefreshAttackInput();
        }

        private void HandleHeldChanged(bool _) => RefreshAttackInput();

        // a catcher held during the hide phase can't swing
        private void RefreshAttackInput()
        {
            bool canAttack = IsOwner && _team.Team == Team.Catcher && _currentWeapon != null && !_hideHold.IsHeld;
            if (!canAttack) CancelSwing();
            ToggleAttackInput(canAttack);
        }

        private void ReplaceWeapon(MeleeWeaponBase weaponPrefab)
        {
            CancelSwing();
            if (_currentWeapon != null)
            {
                Destroy(_currentWeapon.gameObject);
                _currentWeapon = null;
            }

            if (weaponPrefab != null)
            {
                _currentWeapon = Instantiate(weaponPrefab);
                _currentWeapon.AttachTo(FindWeaponSocket());
            }

            OnWeaponChanged?.Invoke(_currentWeapon);
        }

        private Transform FindWeaponSocket()
        {
            var model = _team.Model;
            var rig = model != null ? model.GetComponentInChildren<CharacterRig>() : null;
            return rig != null && rig.WeaponSocket != null ? rig.WeaponSocket : _weaponPivot;
        }

        private void ToggleAttackInput(bool isEnabled)
        {
            if (_isAttackInputBound == isEnabled) return;

            _isAttackInputBound = isEnabled;
            if (isEnabled) _inputReader.OnAttack += PerformAttack;
            else _inputReader.OnAttack -= PerformAttack;
        }

        // Owner only: the hand animation swings the weapon, and the hit is taken where the weapon is when the swing lands
        private void PerformAttack()
        {
            if (_currentWeapon == null || Time.time < _nextAttackTime) return;

            _nextAttackTime = Time.time + _currentWeapon.AttackCooldownInSeconds;
            OnAttackStarted?.Invoke();
            PlayAttackRpc();

            RestartCTS(ref _swingCTS);
            SwingAsync(_currentWeapon, _swingCTS.Token).Forget();
        }

        private async UniTaskVoid SwingAsync(MeleeWeaponBase weapon, CancellationToken token)
        {
            await UniTask.WaitForSeconds(weapon.HitDelayInSeconds, cancellationToken: token);
            if (weapon == null || weapon != _currentWeapon) return;

            RequestCatchServerRpc(weapon.HitOrigin);
        }

        private void CancelSwing() => _swingCTS?.Cancel();

        // the owner already played its own swing
        [Rpc(SendTo.NotOwner)]
        private void PlayAttackRpc() => OnAttackStarted?.Invoke();

        // A catcher's hit knocks every runner inside the weapon's hit sphere; other catchers are ignored.
        // The client only says where the swing landed: the radius and cooldown are the server's own,
        // and a landing point out of the attacker's reach is dropped.
        [Rpc(SendTo.Server)]
        private void RequestCatchServerRpc(Vector3 hitOrigin)
        {
            if (_team.Team != Team.Catcher || _hideHold.IsHeld || _currentWeapon == null) return;

            double now = NetworkManager.ServerTime.Time;
            if (now - _lastServerCatchTime + _cooldownToleranceInSeconds < _currentWeapon.AttackCooldownInSeconds) return;
            // written as "not within" so a NaN or infinite origin is rejected too
            if (!(Vector3.Distance(hitOrigin, transform.position) <= _currentWeapon.MaxHitOriginDistance)) return;

            _lastServerCatchTime = now;
            int hitCount = Physics.OverlapSphereNonAlloc(hitOrigin, _currentWeapon.HitRadius, _catchTargets, _team.CurrentStats.AttackRaycastLayer);
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

        private static void RestartCTS(ref CancellationTokenSource cts)
        {
            cts?.Cancel();
            cts?.Dispose();
            cts = new();
        }

        public override void OnNetworkDespawn()
        {
            _team.OnStatsChanged -= HandleStatsChanged;
            _hideHold.OnHeldChanged -= HandleHeldChanged;
            ToggleAttackInput(false);
            CancelSwing();
        }

        public override void OnDestroy()
        {
            _swingCTS?.Cancel();
            _swingCTS?.Dispose();
            base.OnDestroy();
        }
    }
}
