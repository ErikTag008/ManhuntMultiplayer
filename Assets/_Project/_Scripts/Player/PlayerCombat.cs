using Cysharp.Threading.Tasks;
using KBCore.Refs;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Player.Abilities;
using Project.Assets._Project._Scripts.Player.Drops;
using Project.Assets._Project._Scripts.Weapons;
using System;
using System.Collections.Generic;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Holds the team's weapon in the model's hand; the owner swings, every instance plays the swing, the server resolves the catch.
    // A tap swings on release; holding Attack until the charge is full lunges forward on release (CatcherStats.Lunge).
    [RequireComponent(typeof(PlayerTeam), typeof(InputReader), typeof(PlayerHideHold))]
    [RequireComponent(typeof(PlayerController))]
    public class PlayerCombat : NetworkBehaviour
    {
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField, Self] private PlayerHideHold _hideHold;
        [SerializeField, Self] private PlayerController _controller;
        // used only when the model has no weapon socket
        [SerializeField] private Transform _weaponPivot;
        [SerializeField] private int _maxCatchTargets = 3;
        // the owner's clock and the server's can disagree slightly, so an honest swing may arrive a little early
        [SerializeField] private float _cooldownToleranceInSeconds = 0.1f;

        public event Action<MeleeWeaponBase> OnWeaponChanged;
        public event Action OnAttackStarted;
        public event Action OnLungeStarted;

        private MeleeWeaponBase _currentWeapon;
        private Collider[] _catchTargets;
        // a runner with several colliders is hit once per catch, so a shield can't be used up and then knocked through
        private readonly List<PlayerTeam> _caughtTeams = new();
        private bool _isAttackInputBound;
        private float _nextAttackTime;
        private bool _isAttackPressed;
        private float _attackPressTime;
        private bool _isCharging;
        private double _serverNextAttackTime = double.NegativeInfinity;
        // when the server last saw this catcher start charging; a lunge is only accepted after a real charge
        private double _serverChargeStartTime = double.NegativeInfinity;
        private CancellationTokenSource _swingCTS = new();
        private CancellationTokenSource _chargeCTS = new();

        public MeleeWeaponBase CurrentWeapon => _currentWeapon;
        public bool IsAttackReady => _isAttackInputBound && Time.time >= _nextAttackTime;
        public bool IsCharging => _isCharging;
        // owner only: 0..1 from the press to a full charge
        public float ChargeProgress => _isCharging && Lunge != null && Lunge.FullChargeDurationInSeconds > 0f
            ? Mathf.Clamp01((Time.time - _attackPressTime) / Lunge.FullChargeDurationInSeconds)
            : 0f;

        private LungeSettings Lunge => _team.CurrentStats is CatcherStats catcherStats ? catcherStats.Lunge : null;

        private void OnValidate() => this.ValidateRefs();

        private void Awake() => _catchTargets = new Collider[_maxCatchTargets];

        public override void OnNetworkSpawn()
        {
            _team.OnStatsChanged += HandleStatsChanged;
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

        // a held catcher still swings and lunges inside the spawn room; the server just catches nothing
        private void RefreshAttackInput()
        {
            bool canAttack = IsOwner && _team.Team == Team.Catcher && _currentWeapon != null;
            if (!canAttack)
            {
                CancelSwing();
                CancelAttackPress();
            }
            ToggleAttackInput(canAttack);
        }

        private void ReplaceWeapon(MeleeWeaponBase weaponPrefab)
        {
            CancelSwing();
            CancelAttackPress();
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
            if (isEnabled)
            {
                _inputReader.OnAttackHeldChanged += HandleAttackHeldChanged;
                _inputReader.OnAttackCanceled += CancelAttackPress;
            }
            else
            {
                _inputReader.OnAttackHeldChanged -= HandleAttackHeldChanged;
                _inputReader.OnAttackCanceled -= CancelAttackPress;
            }
        }

        // Owner only: a release before the charge is full is a tap swing; after it, a lunge
        private void HandleAttackHeldChanged(bool isHeld)
        {
            if (isHeld)
            {
                StartAttackPress();
                return;
            }

            // a release without a press, e.g. a button already held when the input was bound
            if (!_isAttackPressed) return;

            var lunge = Lunge;
            bool isFullyCharged = lunge != null && Time.time - _attackPressTime >= lunge.FullChargeDurationInSeconds;
            CancelAttackPress();

            if (isFullyCharged) PerformLunge(lunge);
            else PerformAttack();
        }

        private void StartAttackPress()
        {
            if (_currentWeapon == null || Time.time < _nextAttackTime) return;

            _isAttackPressed = true;
            _attackPressTime = Time.time;

            var lunge = Lunge;
            if (lunge == null) return;

            RestartCTS(ref _chargeCTS);
            StartChargeAsync(lunge, _chargeCTS.Token).Forget();
        }

        // the charge pose and slow only start once the press is clearly longer than a tap
        private async UniTaskVoid StartChargeAsync(LungeSettings lunge, CancellationToken token)
        {
            await UniTask.WaitForSeconds(lunge.ChargeStartDelayInSeconds, cancellationToken: token);
            ToggleCharging(true, lunge);
        }

        // ends the press and the charge without attacking
        private void CancelAttackPress()
        {
            _isAttackPressed = false;
            _chargeCTS?.Cancel();
            ToggleCharging(false, Lunge);
        }

        private void ToggleCharging(bool isCharging, LungeSettings lunge)
        {
            if (_isCharging == isCharging) return;

            _isCharging = isCharging;
            // remote instances only mirror the pose; the slow and the broadcast belong to the owner
            if (!IsOwner) return;

            if (isCharging && IsServer) RecordServerChargeStart();
            // a team change also clears the whole stack, so a remove that finds nothing is fine
            if (lunge != null)
            {
                foreach (var modifier in lunge.ChargeModifiers)
                {
                    if (isCharging) _controller.StatModifiers.Add(modifier);
                    else _controller.StatModifiers.Remove(modifier);
                }
            }

            if (IsSpawned) PlayChargeRpc(isCharging);
        }

        // Owner only: the hand animation swings the weapon, and the hit is taken where the weapon is when the swing lands
        private void PerformAttack()
        {
            if (_currentWeapon == null || Time.time < _nextAttackTime) return;

            _nextAttackTime = Time.time + _currentWeapon.AttackCooldownInSeconds;
            OnAttackStarted?.Invoke();
            PlayAttackRpc();

            RestartCTS(ref _swingCTS);
            SwingAsync(_currentWeapon, _currentWeapon.HitDelayInSeconds, false, _swingCTS.Token).Forget();
        }

        // Owner only: the lunge rides the dash burst; its cooldown assumes a hit and a reported miss lengthens it.
        // When the dash can't run (e.g. mid-climb) the release is a normal swing instead.
        private void PerformLunge(LungeSettings lunge)
        {
            if (_currentWeapon == null || Time.time < _nextAttackTime) return;

            var movement = _controller.Movement;
            if (movement == null || !movement.Dash(lunge.LungeSpeed, lunge.LungeDurationInSeconds))
            {
                PerformAttack();
                return;
            }

            _nextAttackTime = Time.time + lunge.HitCooldownInSeconds;
            OnLungeStarted?.Invoke();
            PlayLungeRpc();

            RestartCTS(ref _swingCTS);
            SwingAsync(_currentWeapon, lunge.HitDelayInSeconds, true, _swingCTS.Token).Forget();
        }

        private async UniTaskVoid SwingAsync(MeleeWeaponBase weapon, float hitDelayInSeconds, bool isLunge, CancellationToken token)
        {
            await UniTask.WaitForSeconds(hitDelayInSeconds, cancellationToken: token);
            if (weapon == null || weapon != _currentWeapon) return;

            RequestCatchServerRpc(weapon.HitOrigin, isLunge);
        }

        private void CancelSwing() => _swingCTS?.Cancel();

        // the owner already played its own swing
        [Rpc(SendTo.NotOwner)]
        private void PlayAttackRpc() => OnAttackStarted?.Invoke();

        [Rpc(SendTo.NotOwner)]
        private void PlayChargeRpc(bool isCharging)
        {
            _isCharging = isCharging;
            if (isCharging && IsServer) RecordServerChargeStart();
        }

        private void RecordServerChargeStart() => _serverChargeStartTime = NetworkManager.ServerTime.Time;

        [Rpc(SendTo.NotOwner)]
        private void PlayLungeRpc() => OnLungeStarted?.Invoke();

        // A catcher's hit knocks every runner inside the hit sphere and pops any decoy there; other catchers are ignored.
        // The client only says where the swing landed and whether it was a lunge: the radius, reach and cooldowns are the server's own,
        // and a landing point out of the attacker's reach is dropped. A lunge reports back whether it caught anything.
        [Rpc(SendTo.Server)]
        private void RequestCatchServerRpc(Vector3 hitOrigin, bool isLunge)
        {
            if (_team.Team != Team.Catcher || _currentWeapon == null) return;

            var lunge = Lunge;
            if (isLunge && lunge == null) return;

            double now = NetworkManager.ServerTime.Time;
            if (now + _cooldownToleranceInSeconds < _serverNextAttackTime) return;
            // the charge started one start delay after the press, so a full charge leaves at least the rest before the lunge
            if (isLunge && now - _serverChargeStartTime + _cooldownToleranceInSeconds < lunge.FullChargeDurationInSeconds - lunge.ChargeStartDelayInSeconds) return;

            float hitRadius = isLunge ? lunge.HitRadius : _currentWeapon.HitRadius;
            float maxHitOriginDistance = isLunge ? lunge.MaxHitOriginDistance : _currentWeapon.MaxHitOriginDistance;
            // written as "not within" so a NaN or infinite origin is rejected too
            if (!(Vector3.Distance(hitOrigin, transform.position) <= maxHitOriginDistance)) return;

            // each charge allows one lunge
            if (isLunge) _serverChargeStartTime = double.NegativeInfinity;
            // a held catcher's warm-up swings run their cooldowns but never catch
            bool hasCaught = !_hideHold.IsHeld && TryCatchAt(hitOrigin, hitRadius);
            float cooldown = !isLunge ? _currentWeapon.AttackCooldownInSeconds
                : hasCaught ? lunge.HitCooldownInSeconds
                : lunge.MissCooldownInSeconds;
            // swings and lunges share the same hit delay by default, so request-to-request matches the owner's start-to-start
            _serverNextAttackTime = now + cooldown;

            if (isLunge) ReportLungeResultRpc(hasCaught);
        }

        // Server only: true when a runner was knocked, a shield took the hit or a decoy popped
        private bool TryCatchAt(Vector3 hitOrigin, float hitRadius)
        {
            bool hasCaught = false;
            int hitCount = Physics.OverlapSphereNonAlloc(hitOrigin, hitRadius, _catchTargets, _team.CurrentStats.AttackRaycastLayer);
            _caughtTeams.Clear();
            for (int i = 0; i < hitCount; i++)
            {
                var decoy = _catchTargets[i].GetComponentInParent<Decoy>();
                if (decoy != null)
                {
                    decoy.Pop();
                    hasCaught = true;
                    continue;
                }

                var targetTeam = _catchTargets[i].GetComponentInParent<PlayerTeam>();
                if (targetTeam == null || targetTeam == _team || targetTeam.Team != Team.Runner) continue;
                if (_caughtTeams.Contains(targetTeam)) continue;

                _caughtTeams.Add(targetTeam);

                if (!targetTeam.TryGetComponent(out PlayerLifeState targetLifeState)) continue;
                if (IsBlockedByShield(targetTeam, targetLifeState))
                {
                    hasCaught = true;
                    continue;
                }
                // a runner already down or just revived doesn't count as a catch
                if (!targetLifeState.IsUp || targetLifeState.IsInvulnerable) continue;

                targetLifeState.Knock();
                hasCaught = true;
            }

            return hasCaught;
        }

        // Server only: a shield drop takes the hit instead of the runner; only a catch that would knock uses it up
        private static bool IsBlockedByShield(PlayerTeam targetTeam, PlayerLifeState targetLifeState)
        {
            if (!targetLifeState.IsUp || targetLifeState.IsInvulnerable) return false;
            return targetTeam.TryGetComponent(out PlayerDropEffects targetDropEffects) && targetDropEffects.TryConsumeShield();
        }

        // Owner only: a missed lunge leaves the catcher slow and waiting longer for the next attack
        [Rpc(SendTo.Owner)]
        private void ReportLungeResultRpc(bool hasCaught)
        {
            var lunge = Lunge;
            if (hasCaught || lunge == null) return;

            _nextAttackTime = Mathf.Max(_nextAttackTime, Time.time + lunge.MissCooldownInSeconds - lunge.HitDelayInSeconds);
            foreach (var modifier in lunge.MissRecoveryModifiers)
            {
                _controller.StatModifiers.Remove(modifier);
                _controller.StatModifiers.Add(modifier, lunge.MissRecoveryDurationInSeconds);
            }
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
            ToggleAttackInput(false);
            CancelSwing();
            CancelAttackPress();
        }

        public override void OnDestroy()
        {
            _swingCTS?.Cancel();
            _swingCTS?.Dispose();
            _chargeCTS?.Cancel();
            _chargeCTS?.Dispose();
            base.OnDestroy();
        }
    }
}
