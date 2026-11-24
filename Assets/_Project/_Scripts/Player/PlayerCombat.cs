using Cysharp.Threading.Tasks;
using KBCore.Refs;
using Project.Assets._Project._Scripts.Input;
using Project.Assets._Project._Scripts.Player.Abilities;
using Project.Assets._Project._Scripts.Player.Drops;
using Project.Assets._Project._Scripts.Weapons;
using Reflex.Attributes;
using System;
using System.Collections.Generic;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Holds the team's weapon in the model's hand; the owner swings, every instance plays the swing, the server resolves the catch.
    // A tap swings on release; holding Attack until the charge is full lunges forward on release (CatcherStats.Lunge).
    // The owner finds the targets with a sweep along its own view, against the runners it sees (fair to the catcher: what lands on
    // screen counts). The server only accepts targets within a lag-sized distance of the catcher (fair to runners: no hits from far
    // away), and the owner never counts a runner behind a wall.
    [RequireComponent(typeof(PlayerTeam), typeof(InputReader), typeof(PlayerHideHold))]
    [RequireComponent(typeof(PlayerController))]
    public class PlayerCombat : NetworkBehaviour
    {
        // injected by PlayerController.Awake together with the rest of the player; only the server uses it
        [Inject] private readonly IPlayerRegistry _playerRegistry;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private InputReader _inputReader;
        [SerializeField, Self] private PlayerHideHold _hideHold;
        [SerializeField, Self] private PlayerController _controller;
        // used only when the model has no weapon socket
        [SerializeField] private Transform _weaponPivot;
        [SerializeField] private int _maxCatchTargets = 3;
        // colliders one sweep can return; a runner has several and knocked runners fill slots too
        [SerializeField] private int _sweepBufferSize = 16;
        // the owner's clock and the server's can disagree slightly, so an honest swing may arrive a little early
        [SerializeField] private float _cooldownToleranceInSeconds = 0.1f;

        public event Action<MeleeWeaponBase> OnWeaponChanged;
        public event Action OnAttackStarted;
        public event Action OnLungeStarted;

        private MeleeWeaponBase _currentWeapon;
        private Collider[] _sweepHits;
        private readonly List<NetworkObject> _sweepTargets = new();
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
        // owner only: a Trip Trap snare blocks the lunge until then
        private float _snareEndTime = float.NegativeInfinity;

        public MeleeWeaponBase CurrentWeapon => _currentWeapon;
        public bool IsAttackReady => _isAttackInputBound && Time.time >= _nextAttackTime;
        public bool IsCharging => _isCharging;
        public bool IsSnared => Time.time < _snareEndTime;
        // owner only: 0..1 from the press to a full charge
        public float ChargeProgress => _isCharging && Lunge != null && Lunge.FullChargeDurationInSeconds > 0f
            ? Mathf.Clamp01((Time.time - _attackPressTime) / Lunge.FullChargeDurationInSeconds)
            : 0f;

        private LungeSettings Lunge => _team.CurrentStats is CatcherStats catcherStats ? catcherStats.Lunge : null;

        private void OnValidate() => this.ValidateRefs();

        private void Awake() => _sweepHits = new Collider[_sweepBufferSize];

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
            bool isFullyCharged = lunge != null && !IsSnared && Time.time - _attackPressTime >= lunge.FullChargeDurationInSeconds;
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
            if (lunge == null || IsSnared) return;

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
            var sweep = new SwingSweep(_currentWeapon.HitDelayInSeconds, _currentWeapon.HitWindowInSeconds, _currentWeapon.ReachInMeters, _currentWeapon.HitRadius);
            SwingAsync(_currentWeapon, sweep, false, _swingCTS.Token).Forget();
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
            var sweep = new SwingSweep(lunge.HitDelayInSeconds, lunge.HitWindowInSeconds, lunge.ReachInMeters, lunge.HitRadius);
            SwingAsync(_currentWeapon, sweep, true, _swingCTS.Token).Forget();
        }

        // Sweeps every frame of the hit window and reports the first frame that finds a target, or an empty miss when the window ends
        private async UniTaskVoid SwingAsync(MeleeWeaponBase weapon, SwingSweep sweep, bool isLunge, CancellationToken token)
        {
            await UniTask.WaitForSeconds(sweep.HitDelayInSeconds, cancellationToken: token);

            float windowEndTime = Time.time + sweep.HitWindowInSeconds;
            while (true)
            {
                if (weapon == null || weapon != _currentWeapon) return;
                if (FindSweepTargets(sweep.ReachInMeters, sweep.RadiusInMeters) > 0 || Time.time >= windowEndTime) break;

                await UniTask.Yield(cancellationToken: token);
            }

            var targets = new NetworkObjectReference[_sweepTargets.Count];
            for (int i = 0; i < targets.Length; i++) targets[i] = _sweepTargets[i];
            RequestCatchServerRpc(targets, isLunge);
        }

        // Owner only: a capsule from the eye along the view; a standing, catchable runner or a decoy counts when nothing solid is between
        private int FindSweepTargets(float reachInMeters, float radiusInMeters)
        {
            _sweepTargets.Clear();
            var viewCamera = _controller.ViewCamera;
            if (viewCamera == null || _team.CurrentStats is not CatcherStats catcherStats) return 0;

            Vector3 eye = viewCamera.transform.position;
            Vector3 end = eye + viewCamera.transform.forward * reachInMeters;
            int hitCount = Physics.OverlapCapsuleNonAlloc(eye, end, radiusInMeters, _sweepHits, catcherStats.AttackRaycastLayer);
            for (int i = 0; i < hitCount && _sweepTargets.Count < _maxCatchTargets; i++)
            {
                var hit = _sweepHits[i];
                if (!TryGetSweepTarget(hit, out NetworkObject target) || _sweepTargets.Contains(target)) continue;
                if (IsBehindCover(eye, hit, catcherStats.HitBlockingLayers)) continue;

                _sweepTargets.Add(target);
            }

            return _sweepTargets.Count;
        }

        // a knocked runner can't be caught, so it doesn't use up the swing (invulnerability is only known on the server, so the host's check is the only one that sees it)
        private bool TryGetSweepTarget(Collider hit, out NetworkObject target)
        {
            target = null;
            var decoy = hit.GetComponentInParent<Decoy>();
            if (decoy != null)
            {
                target = decoy.NetworkObject;
                return target != null;
            }

            var targetTeam = hit.GetComponentInParent<PlayerTeam>();
            if (targetTeam == null || targetTeam == _team || targetTeam.Team != Team.Runner) return false;
            if (!targetTeam.TryGetComponent(out PlayerLifeState targetLifeState) || !targetLifeState.IsUp || targetLifeState.IsInvulnerable) return false;

            target = targetTeam.NetworkObject;
            return target != null;
        }

        // aims at the target's nearest point, so a runner half out from behind a corner can still be hit
        private static bool IsBehindCover(Vector3 eye, Collider hit, LayerMask blockingLayers)
        {
            Vector3 toTarget = hit.ClosestPoint(eye) - eye;
            float distance = toTarget.magnitude;
            if (distance <= 0f) return false;

            return Physics.Raycast(eye, toTarget / distance, distance, blockingLayers, QueryTriggerInteraction.Ignore);
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

        // A catcher's hit knocks the runners the owner's sweep found and pops any decoy among them; other catchers are ignored.
        // The client only names its targets and whether it was a lunge: cooldowns and the distance limit are the server's own,
        // and a target farther from the catcher than the limit is dropped. A lunge reports back whether it caught anything.
        [Rpc(SendTo.Server)]
        private void RequestCatchServerRpc(NetworkObjectReference[] targets, bool isLunge)
        {
            if (_team.Team != Team.Catcher || _currentWeapon == null) return;

            var lunge = Lunge;
            if (isLunge && lunge == null) return;

            double now = NetworkManager.ServerTime.Time;
            if (now + _cooldownToleranceInSeconds < _serverNextAttackTime) return;
            // the charge started one start delay after the press, so a full charge leaves at least the rest before the lunge
            if (isLunge && now - _serverChargeStartTime + _cooldownToleranceInSeconds < lunge.FullChargeDurationInSeconds - lunge.ChargeStartDelayInSeconds) return;

            float maxTargetDistance = isLunge ? lunge.MaxTargetDistance : _currentWeapon.MaxTargetDistance;

            // each charge allows one lunge
            if (isLunge) _serverChargeStartTime = double.NegativeInfinity;
            // a held catcher's warm-up swings run their cooldowns but never catch
            bool hasCaught = !_hideHold.IsHeld && TryCatch(targets, maxTargetDistance);
            float cooldown = !isLunge ? _currentWeapon.AttackCooldownInSeconds
                : hasCaught ? lunge.HitCooldownInSeconds
                : lunge.MissCooldownInSeconds;
            // swings and lunges share the same hit delay by default, so request-to-request matches the owner's start-to-start
            _serverNextAttackTime = now + cooldown;

            if (isLunge) ReportLungeResultRpc(hasCaught);
        }

        // Server only: true when a runner was knocked, a shield took the hit or a decoy popped
        private bool TryCatch(NetworkObjectReference[] targets, float maxTargetDistance)
        {
            if (targets == null) return false;

            bool hasCaught = false;
            _caughtTeams.Clear();
            int targetCount = Mathf.Min(targets.Length, _maxCatchTargets);
            for (int i = 0; i < targetCount; i++)
            {
                if (!targets[i].TryGet(out NetworkObject target)) continue;
                if (!(Vector3.Distance(target.transform.position, transform.position) <= maxTargetDistance)) continue;

                if (target.TryGetComponent(out Decoy decoy))
                {
                    decoy.Pop();
                    hasCaught = true;
                    continue;
                }

                if (!target.TryGetComponent(out PlayerTeam targetTeam) || targetTeam == _team || targetTeam.Team != Team.Runner) continue;
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

                if (targetLifeState.Knock()) _playerRegistry?.AddCatch(OwnerClientId);
                hasCaught = true;
            }

            return hasCaught;
        }

        // Server only: a runner's Trip Trap caught this catcher; the owner applies the slow, since movement is the owner's
        public void Snare()
        {
            if (!IsServer || _team.Team != Team.Catcher) return;

            SnareRpc();
        }

        [Rpc(SendTo.Owner)]
        private void SnareRpc()
        {
            if (_team.CurrentStats is not CatcherStats catcherStats) return;

            CancelAttackPress();
            _snareEndTime = Time.time + catcherStats.SnareDurationInSeconds;
            foreach (var modifier in catcherStats.SnareModifiers)
            {
                _controller.StatModifiers.Remove(modifier);
                _controller.StatModifiers.Add(modifier, catcherStats.SnareDurationInSeconds);
            }
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

        // what one swing or lunge sweeps, captured when it starts so a stats change mid-swing can't mix two settings
        private readonly struct SwingSweep
        {
            public readonly float HitDelayInSeconds;
            public readonly float HitWindowInSeconds;
            public readonly float ReachInMeters;
            public readonly float RadiusInMeters;

            public SwingSweep(float hitDelayInSeconds, float hitWindowInSeconds, float reachInMeters, float radiusInMeters)
            {
                HitDelayInSeconds = hitDelayInSeconds;
                HitWindowInSeconds = hitWindowInSeconds;
                ReachInMeters = reachInMeters;
                RadiusInMeters = radiusInMeters;
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
