using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using Reflex.Extensions;
using Reflex.Injectors;
using System.Threading;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Assets._Project._Scripts.Player.Abilities
{
    // A smoke sphere left by the Smoke Bomb ability: it blocks sight through it and hides revealed runners inside it from catchers.
    // Every instance grows and shrinks the visual on its own clock; the server despawns it when the lifetime ends.
    public class SmokeCloud : NetworkBehaviour
    {
        private const float DiameterPerRadius = 2f;

        [Inject] private readonly SmokeCloudDirectory _directory;
        // scaled to the cloud's diameter; a unit sphere mesh is expected
        [SerializeField] private Transform _visual;
        [SerializeField, Min(0f)] private float _radiusInMeters = 6f;
        [SerializeField, Min(0f)] private float _lifetimeInSeconds = 6f;
        [SerializeField, Min(0f)] private float _growDurationInSeconds = 0.4f;
        [SerializeField, Min(0f)] private float _shrinkDurationInSeconds = 0.6f;

        private CancellationTokenSource _lifetimeCTS = new();
        private float _spawnTime;

        private void Awake() => GameObjectInjector.InjectObject(gameObject, SceneManager.GetActiveScene().GetSceneContainer());

        public override void OnNetworkSpawn()
        {
            _spawnTime = Time.time;
            _visual.localScale = Vector3.zero;
            _directory.Add(this);
            if (!IsServer) return;

            RestartCTS(ref _lifetimeCTS);
            DespawnAfterLifetimeAsync(_lifetimeCTS.Token).Forget();
        }

        private void Update()
        {
            if (!IsSpawned) return;

            float age = Time.time - _spawnTime;
            float grow = _growDurationInSeconds > 0f ? Mathf.Clamp01(age / _growDurationInSeconds) : 1f;
            float shrink = _shrinkDurationInSeconds > 0f ? Mathf.Clamp01((_lifetimeInSeconds - age) / _shrinkDurationInSeconds) : 1f;
            _visual.localScale = Vector3.one * (_radiusInMeters * DiameterPerRadius * Mathf.Min(grow, shrink));
        }

        public bool Contains(Vector3 position) => (position - transform.position).sqrMagnitude <= _radiusInMeters * _radiusInMeters;

        private async UniTaskVoid DespawnAfterLifetimeAsync(CancellationToken token)
        {
            await UniTask.WaitForSeconds(_lifetimeInSeconds, cancellationToken: token);
            if (IsSpawned) NetworkObject.Despawn();
        }

        private static void RestartCTS(ref CancellationTokenSource cts)
        {
            cts?.Cancel();
            cts?.Dispose();
            cts = new();
        }

        public override void OnNetworkDespawn()
        {
            _directory.Remove(this);
            _lifetimeCTS?.Cancel();
        }

        // a cloud destroyed without a despawn (shutdown order) must not stay listed
        public override void OnDestroy()
        {
            _directory?.Remove(this);
            _lifetimeCTS?.Cancel();
            _lifetimeCTS?.Dispose();
            base.OnDestroy();
        }
    }
}
