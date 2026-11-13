using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using System;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Up / Knocked / Eliminated read from this player's session; PlayerRegistry owns the value.
    // The server runs the bleed-out timer while the player is knocked; a rescue pauses it.
    public class PlayerLifeState : NetworkBehaviour
    {
        [Inject] private readonly PlayerSessionDirectory _sessionDirectory;
        [Inject] private readonly IPlayerRegistry _playerRegistry;
        [Inject] private readonly RunnerStats _runnerStats;

        public event Action<LifeState> OnLifeStateChanged;

        private readonly NetworkVariable<double> _bleedOutEndTime = new();
        private readonly NetworkVariable<bool> _isBleedOutPaused = new();
        private readonly NetworkVariable<float> _pausedBleedOutRemainingInSeconds = new();
        private CancellationTokenSource _bleedOutCTS;
        private LifeState _state;
        // Server only
        private double _invulnerableUntil;

        public LifeState State => _state;
        public bool IsUp => _state == LifeState.Up;
        public bool IsKnocked => _state == LifeState.Knocked;
        public bool IsEliminated => _state == LifeState.Eliminated;
        // Knocked runners still crawl; only elimination stops movement
        public bool CanMove => _state != LifeState.Eliminated;
        public bool IsBleedOutPaused => IsKnocked && _isBleedOutPaused.Value;
        public float BleedOutRemainingInSeconds
        {
            get
            {
                if (!IsKnocked) return 0f;
                if (_isBleedOutPaused.Value) return _pausedBleedOutRemainingInSeconds.Value;
                return Mathf.Max(0f, (float)(_bleedOutEndTime.Value - NetworkManager.ServerTime.Time));
            }
        }
        // Server only
        public bool IsInvulnerable => NetworkManager.ServerTime.Time < _invulnerableUntil;

        public override void OnNetworkSpawn()
        {
            _sessionDirectory.OnSessionChanged += HandleSessionChanged;
            _state = _sessionDirectory.TryGetSession(OwnerClientId, out var session) ? session.LifeState : LifeState.Up;
        }

        // Server only; players are spawned after GameSystems, so the registry is injected on the server
        public void Knock()
        {
            if (!IsServer || !IsUp || IsInvulnerable) return;
            if (_playerRegistry == null)
            {
                EUtils.Logger.LogError($"[PlayerLifeState] No player registry; can't knock player {OwnerClientId}.");
                return;
            }

            _playerRegistry.SetLifeState(OwnerClientId, LifeState.Knocked);
        }

        // Server only: a finished rescue stands the player back up
        public void Revive()
        {
            if (!IsServer || !IsKnocked) return;
            if (_playerRegistry == null)
            {
                EUtils.Logger.LogError($"[PlayerLifeState] No player registry; can't revive player {OwnerClientId}.");
                return;
            }

            _invulnerableUntil = NetworkManager.ServerTime.Time + _runnerStats.ReviveInvulnerabilityDurationInSeconds;
            _playerRegistry.SetLifeState(OwnerClientId, LifeState.Up);
        }

        // Server only: a rescue in progress holds the timer and keeps what was left for a cancelled rescue
        public void PauseBleedOut()
        {
            if (!IsServer || !IsKnocked || _isBleedOutPaused.Value) return;

            _pausedBleedOutRemainingInSeconds.Value = BleedOutRemainingInSeconds;
            _isBleedOutPaused.Value = true;
            DisposeCTS(ref _bleedOutCTS);
        }

        // Server only
        public void ResumeBleedOut()
        {
            if (!IsServer || !IsKnocked || !_isBleedOutPaused.Value) return;
            StartBleedOut(_pausedBleedOutRemainingInSeconds.Value);
        }

        private void HandleSessionChanged(PlayerSession session)
        {
            if (session.ClientId != OwnerClientId || session.LifeState == _state) return;

            _state = session.LifeState;
            // every path into or out of Knocked (catch, rescue, round reset) passes through here on the server
            if (IsServer)
            {
                if (IsKnocked) StartBleedOut(_runnerStats.BleedOutDurationInSeconds);
                else EndBleedOut();
            }

            OnLifeStateChanged?.Invoke(_state);
        }

        private void StartBleedOut(float durationInSeconds)
        {
            RestartCTS(ref _bleedOutCTS);
            _isBleedOutPaused.Value = false;
            _bleedOutEndTime.Value = NetworkManager.ServerTime.Time + durationInSeconds;
            BleedOutAsync(_bleedOutCTS.Token).Forget();
        }

        // a cleared end time reads as zero remaining, so a later knock never shows this one's leftover time
        private void EndBleedOut()
        {
            StopBleedOut();
            _isBleedOutPaused.Value = false;
            _bleedOutEndTime.Value = 0;
        }

        private void StopBleedOut() => DisposeCTS(ref _bleedOutCTS);

        // waits on the same server clock clients read, so the synced countdown and elimination agree
        private async UniTaskVoid BleedOutAsync(CancellationToken token)
        {
            await UniTask.WaitUntil(() => NetworkManager.ServerTime.Time >= _bleedOutEndTime.Value, cancellationToken: token);
            if (!IsKnocked) return;

            _playerRegistry.SetLifeState(OwnerClientId, LifeState.Eliminated);
        }

        private static void RestartCTS(ref CancellationTokenSource cts)
        {
            DisposeCTS(ref cts);
            cts = new();
        }

        private static void DisposeCTS(ref CancellationTokenSource cts)
        {
            cts?.Cancel();
            cts?.Dispose();
            cts = null;
        }

        public override void OnNetworkDespawn()
        {
            _sessionDirectory.OnSessionChanged -= HandleSessionChanged;
            StopBleedOut();
        }

        public override void OnDestroy()
        {
            StopBleedOut();
            base.OnDestroy();
        }
    }

    public enum LifeState
    {
        Up,
        Knocked,
        Eliminated
    }
}
