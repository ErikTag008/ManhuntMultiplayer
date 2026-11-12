using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using System;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Up / Knocked / Eliminated read from this player's session; PlayerRegistry owns the value.
    // The server runs the bleed-out timer while the player is knocked.
    public class PlayerLifeState : NetworkBehaviour
    {
        [Inject] private readonly PlayerSessionDirectory _sessionDirectory;
        [Inject] private readonly IPlayerRegistry _playerRegistry;
        [Inject] private readonly RunnerStats _runnerStats;

        public event Action<LifeState> OnLifeStateChanged;

        private readonly NetworkVariable<double> _bleedOutEndTime = new();
        private CancellationTokenSource _bleedOutCTS;
        private LifeState _state;

        public LifeState State => _state;
        public bool IsUp => _state == LifeState.Up;
        public bool IsKnocked => _state == LifeState.Knocked;
        // Knocked runners still crawl; only elimination stops movement
        public bool CanMove => _state != LifeState.Eliminated;
        public float BleedOutRemainingInSeconds => IsKnocked ? Mathf.Max(0f, (float)(_bleedOutEndTime.Value - NetworkManager.ServerTime.Time)) : 0f;

        public override void OnNetworkSpawn()
        {
            _sessionDirectory.OnSessionChanged += HandleSessionChanged;
            _state = _sessionDirectory.TryGetSession(OwnerClientId, out var session) ? session.LifeState : LifeState.Up;
        }

        // Server only; players are spawned after GameSystems, so the registry is injected on the server
        public void Knock()
        {
            if (!IsServer || !IsUp) return;
            if (_playerRegistry == null)
            {
                EUtils.Logger.LogError($"[PlayerLifeState] No player registry; can't knock player {OwnerClientId}.");
                return;
            }

            _playerRegistry.SetLifeState(OwnerClientId, LifeState.Knocked);
        }

        private void HandleSessionChanged(PlayerSession session)
        {
            if (session.ClientId != OwnerClientId || session.LifeState == _state) return;

            _state = session.LifeState;
            // every path into or out of Knocked (catch, rescue, round reset) passes through here on the server
            if (IsServer)
            {
                if (IsKnocked) StartBleedOut();
                else StopBleedOut();
            }

            OnLifeStateChanged?.Invoke(_state);
        }

        private void StartBleedOut()
        {
            RestartCTS(ref _bleedOutCTS);
            _bleedOutEndTime.Value = NetworkManager.ServerTime.Time + _runnerStats.BleedOutDurationInSeconds;
            BleedOutAsync(_bleedOutCTS.Token).Forget();
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
