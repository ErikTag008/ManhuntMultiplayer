using Cysharp.Threading.Tasks;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Abilities
{
    // A snare left by the Trip Trap ability. It sits on the ground where the runner dropped it; the first catcher to run over it
    // is slowed and can't lunge for a moment (CatcherStats snare settings), and the trap is used up. The server watches for catchers,
    // since catchers' positions reach it from every owner; it despawns the trap when it triggers or its lifetime ends.
    public class TripTrap : NetworkBehaviour
    {
        [SerializeField] private LayerMask _catcherLayers;
        // 1 = the Default layer, where the map geometry lives
        [SerializeField] private LayerMask _environmentLayers = 1;
        [SerializeField, Min(0f)] private float _triggerRadiusInMeters = 0.9f;
        // the trigger sphere sits this high above the trap, so a catcher jumping over it clears it
        [SerializeField, Min(0f)] private float _triggerHeightInMeters = 0.5f;
        [SerializeField, Min(0f)] private float _lifetimeInSeconds = 20f;
        // dropped mid-jump or off a ledge, the trap falls to the ground this far below at most; with none in reach it is removed
        [SerializeField, Min(0f)] private float _groundSearchDepthInMeters = 20f;
        [SerializeField, Min(0f)] private float _groundProbeHeightInMeters = 0.6f;
        [SerializeField, Min(1)] private int _overlapBufferSize = 8;

        private CancellationTokenSource _lifetimeCTS = new();
        private Collider[] _overlapHits;
        private bool _isUsedUp;
        // despawning inside OnNetworkSpawn isn't safe, so a trap with no ground under it is removed on the next physics step
        private bool _hasNoGround;

        private void Awake() => _overlapHits = new Collider[_overlapBufferSize];

        public override void OnNetworkSpawn()
        {
            if (!IsServer) return;

            _hasNoGround = !TrySnapToGround();
            RestartCTS(ref _lifetimeCTS);
            DespawnAfterLifetimeAsync(_lifetimeCTS.Token).Forget();
        }

        private void FixedUpdate()
        {
            if (!IsSpawned || !IsServer || _isUsedUp) return;
            if (_hasNoGround)
            {
                UseUp();
                return;
            }

            Vector3 center = transform.position + Vector3.up * _triggerHeightInMeters;
            int hitCount = Physics.OverlapSphereNonAlloc(center, _triggerRadiusInMeters, _overlapHits, _catcherLayers, QueryTriggerInteraction.Ignore);
            for (int i = 0; i < hitCount; i++)
            {
                var team = _overlapHits[i].GetComponentInParent<PlayerTeam>();
                if (team == null || team.Team != Team.Catcher || !team.TryGetComponent(out PlayerCombat combat)) continue;

                combat.Snare();
                UseUp();
                return;
            }
        }

        private bool TrySnapToGround()
        {
            Vector3 position = transform.position;
            if (!Physics.Raycast(position + Vector3.up * _groundProbeHeightInMeters, Vector3.down, out RaycastHit groundHit,
                _groundProbeHeightInMeters + _groundSearchDepthInMeters, _environmentLayers, QueryTriggerInteraction.Ignore)) return false;

            position.y = groundHit.point.y;
            transform.position = position;
            return true;
        }

        // Server only: one catcher per trap
        private void UseUp()
        {
            if (!IsServer || _isUsedUp || !IsSpawned) return;

            _isUsedUp = true;
            NetworkObject.Despawn();
        }

        private async UniTaskVoid DespawnAfterLifetimeAsync(CancellationToken token)
        {
            await UniTask.WaitForSeconds(_lifetimeInSeconds, cancellationToken: token);
            UseUp();
        }

        private static void RestartCTS(ref CancellationTokenSource cts)
        {
            cts?.Cancel();
            cts?.Dispose();
            cts = new();
        }

        public override void OnNetworkDespawn() => _lifetimeCTS?.Cancel();

        public override void OnDestroy()
        {
            _lifetimeCTS?.Cancel();
            _lifetimeCTS?.Dispose();
            base.OnDestroy();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position + Vector3.up * _triggerHeightInMeters, _triggerRadiusInMeters);
        }
    }
}
