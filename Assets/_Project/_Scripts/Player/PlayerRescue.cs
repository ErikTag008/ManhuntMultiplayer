using Cysharp.Threading.Tasks;
using KBCore.Refs;
using Project.Assets._Project._Scripts.Input;
using Reflex.Attributes;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // A standing runner holds Interact near a knocked runner to revive them. The owner sends the hold, the server runs the rescue.
    [RequireComponent(typeof(PlayerTeam), typeof(PlayerLifeState), typeof(InputReader))]
    public class PlayerRescue : NetworkBehaviour
    {
        [Inject] private readonly IPlayerRegistry _playerRegistry;
        [Inject] private readonly RunnerStats _runnerStats;
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField, Self] private InputReader _inputReader;

        // 0..1, written on both the rescuer and the knocked runner so each HUD can show it
        private readonly NetworkVariable<float> _rescueProgress = new();
        private CancellationTokenSource _holdCTS;
        // Server only
        private bool _isInteractHeld;
        private PlayerRescue _target;
        private PlayerRescue _rescuer;

        public float RescueProgress => _rescueProgress.Value;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            if (IsOwner) _inputReader.OnInteractHeldChanged += HandleInteractHeldChanged;
        }

        private void HandleInteractHeldChanged(bool isHeld)
        {
            EUtils.Logger.Log($"[TEMP-RESCUE-DIAG] owner {OwnerClientId} held={isHeld}, sending RPC");
            if (isHeld) StartHoldServerRpc();
            else StopHoldServerRpc();
        }

        [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Owner)]
        private void StartHoldServerRpc() => ToggleInteractHeld(true);

        [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Owner)]
        private void StopHoldServerRpc() => ToggleInteractHeld(false);

        // Server only
        private void ToggleInteractHeld(bool isHeld)
        {
            EUtils.Logger.Log($"[TEMP-RESCUE-DIAG] server: player {OwnerClientId} held={isHeld} team={_team.Team} state={_lifeState.State} registry={(_playerRegistry != null)} players={(_playerRegistry != null ? _playerRegistry.GetPlayers().Count : -1)}");
            if (isHeld) LogRescueCandidates();
            if (_isInteractHeld == isHeld) return;

            _isInteractHeld = isHeld;
            if (isHeld)
            {
                RestartCTS(ref _holdCTS);
                HoldInteractAsync(_holdCTS.Token).Forget();
            }
            else
            {
                DisposeCTS(ref _holdCTS);
                DetachTarget(true);
            }
        }

        // While Interact is held the rescuer keeps looking for a knocked runner in range, so walking up while holding works.
        // Releasing, moving out of range, getting caught or the target leaving Knocked drops the target and resets progress.
        private async UniTaskVoid HoldInteractAsync(CancellationToken token)
        {
            float elapsedInSeconds = 0f;
            while (!token.IsCancellationRequested)
            {
                if (_target != null && !CanContinueRescue()) DetachTarget(true);

                if (_target == null)
                {
                    elapsedInSeconds = 0f;
                    if (CanRescue() && TryFindRescueTarget(out var target)) AttachTarget(target);
                }
                else
                {
                    elapsedInSeconds += Time.deltaTime;
                    SetProgress(Mathf.Clamp01(elapsedInSeconds / _runnerStats.RescueDurationInSeconds));
                    // the conditions were checked this frame, so nothing can have cancelled the rescue in between
                    if (elapsedInSeconds >= _runnerStats.RescueDurationInSeconds) CompleteRescue();
                }

                await UniTask.Yield(token);
            }
        }

        private void LogRescueCandidates()
        {
            foreach (var player in _playerRegistry.GetPlayers())
            {
                if (player.OwnerClientId == OwnerClientId) continue;
                float distance = Vector3.Distance(player.transform.position, transform.position);
                bool hasRescue = player.TryGetComponent(out PlayerRescue candidate);
                EUtils.Logger.Log($"[TEMP-RESCUE-DIAG]   candidate {player.OwnerClientId}: team={player.Team} state={player.LifeState.State} dist={distance:F2} hasRescue={hasRescue} taken={(hasRescue && candidate._rescuer != null)}");
            }
        }

        private bool CanRescue() => _team.Team == Team.Runner && _lifeState.IsUp;

        // The nearest knocked runner in range that nobody else is already rescuing
        private bool TryFindRescueTarget(out PlayerRescue target)
        {
            target = null;
            float closestSqrDistance = _runnerStats.RescueRange * _runnerStats.RescueRange;

            foreach (var player in _playerRegistry.GetPlayers())
            {
                if (player.Team != Team.Runner || !player.LifeState.IsKnocked) continue;
                if (!player.TryGetComponent(out PlayerRescue candidate) || candidate == this || candidate._rescuer != null) continue;

                float sqrDistance = (player.transform.position - transform.position).sqrMagnitude;
                if (sqrDistance > closestSqrDistance) continue;

                closestSqrDistance = sqrDistance;
                target = candidate;
            }

            return target != null;
        }

        private bool CanContinueRescue()
        {
            if (!_target.IsSpawned || !CanRescue() || !_target._lifeState.IsKnocked) return false;

            float sqrRange = _runnerStats.RescueRange * _runnerStats.RescueRange;
            return (_target.transform.position - transform.position).sqrMagnitude <= sqrRange;
        }

        private void AttachTarget(PlayerRescue target)
        {
            EUtils.Logger.Log($"[TEMP-RESCUE-DIAG] server: {OwnerClientId} attached to {target.OwnerClientId}");
            _target = target;
            target._rescuer = this;
            target._lifeState.PauseBleedOut();
        }

        private void CompleteRescue()
        {
            var target = _target;
            DetachTarget(false);
            target._lifeState.Revive();
        }

        private void SetProgress(float progress)
        {
            _rescueProgress.Value = progress;
            _target._rescueProgress.Value = progress;
        }

        // The knocked runner's bleed-out resumes from where it paused unless the rescue finished
        private void DetachTarget(bool isResumingBleedOut)
        {
            if (_target == null) return;
            EUtils.Logger.Log($"[TEMP-RESCUE-DIAG] server: {OwnerClientId} detached from {_target.OwnerClientId} resume={isResumingBleedOut} canRescue={CanRescue()} targetState={_target._lifeState.State}");

            if (_target.IsSpawned)
            {
                _target._rescueProgress.Value = 0f;
                if (isResumingBleedOut) _target._lifeState.ResumeBleedOut();
            }

            _target._rescuer = null;
            DropTarget();
        }

        // Also used when the target despawns mid-rescue, so nothing is written to it
        private void DropTarget()
        {
            _target = null;
            if (IsSpawned) _rescueProgress.Value = 0f;
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
            if (IsOwner) _inputReader.OnInteractHeldChanged -= HandleInteractHeldChanged;
            if (!IsServer) return;

            ToggleInteractHeld(false);
            if (_rescuer == null) return;

            _rescuer.DropTarget();
            _rescuer = null;
        }

        public override void OnDestroy()
        {
            DisposeCTS(ref _holdCTS);
            base.OnDestroy();
        }
    }
}
