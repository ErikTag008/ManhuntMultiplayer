using Cysharp.Threading.Tasks;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Abilities
{
    // A runner look-alike left by the Decoy ability. The server runs it straight ahead along the ground until a wall stops it
    // or its lifetime ends; a catcher's hit pops it. Every instance animates it and plays its footsteps while it runs.
    public class Decoy : NetworkBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _footstepSource;
        [SerializeField] private FootstepSoundSet _soundSet;
        [SerializeField, Min(0f)] private float _runSpeed = 15f;
        [SerializeField, Min(0f)] private float _lifetimeInSeconds = 4f;
        [SerializeField] private LayerMask _environmentLayers = ~0;
        // a wall closer than this ahead, measured at chest height, stops the run
        [SerializeField, Min(0f)] private float _wallCheckDistanceInMeters = 0.6f;
        [SerializeField, Min(0f)] private float _wallCheckHeightInMeters = 1f;
        // the ground is searched from this high above the feet down to this far below them, so small steps are followed
        [SerializeField, Min(0f)] private float _groundProbeHeightInMeters = 0.6f;
        [SerializeField, Min(0f)] private float _groundProbeDepthInMeters = 1.5f;
        // used mid-jump or off a ledge, the decoy drops to the ground this far below at most; with none in reach it is removed
        [SerializeField, Min(0f)] private float _spawnGroundSearchDepthInMeters = 20f;
        // what the player Animator's MoveSpeed would read at a full run
        [SerializeField, Range(0f, 1f)] private float _animatorRunSpeed = 0.63f;
        [SerializeField] private string _moveSpeedParameter = "MoveSpeed";
        [SerializeField] private string _isGroundedParameter = "IsGrounded";
        [SerializeField, Min(0f)] private float _stepsPerSecond = 2.8f;

        private readonly NetworkVariable<bool> _isRunning = new();

        private CancellationTokenSource _lifetimeCTS = new();
        private int _moveSpeedId;
        private int _isGroundedId;
        private float _stepProgress;
        private int _lastClipIndex = -1;
        private bool _isPopped;
        // despawning inside OnNetworkSpawn isn't safe, so a decoy with no ground under it is removed on the next physics step
        private bool _hasNoGround;

        private void Awake()
        {
            _moveSpeedId = Animator.StringToHash(_moveSpeedParameter);
            _isGroundedId = Animator.StringToHash(_isGroundedParameter);
        }

        public override void OnNetworkSpawn()
        {
            if (_animator != null) _animator.SetBool(_isGroundedId, true);
            if (!IsServer) return;

            _hasNoGround = !TrySnapToGround(_spawnGroundSearchDepthInMeters);
            _isRunning.Value = !_hasNoGround;
            RestartCTS(ref _lifetimeCTS);
            DespawnAfterLifetimeAsync(_lifetimeCTS.Token).Forget();
        }

        private void FixedUpdate()
        {
            if (!IsSpawned || !IsServer) return;
            if (_hasNoGround)
            {
                Pop();
                return;
            }

            if (!_isRunning.Value) return;

            float step = _runSpeed * Time.fixedDeltaTime;
            Vector3 position = transform.position;
            Vector3 forward = transform.forward;
            if (Physics.Raycast(position + Vector3.up * _wallCheckHeightInMeters, forward, _wallCheckDistanceInMeters + step, _environmentLayers, QueryTriggerInteraction.Ignore))
            {
                _isRunning.Value = false;
                return;
            }

            Vector3 next = position + forward * step;
            // running off a ledge or into a pit ends the run where it is rather than floating on
            if (!Physics.Raycast(next + Vector3.up * _groundProbeHeightInMeters, Vector3.down, out RaycastHit groundHit,
                _groundProbeHeightInMeters + _groundProbeDepthInMeters, _environmentLayers, QueryTriggerInteraction.Ignore))
            {
                _isRunning.Value = false;
                return;
            }

            next.y = groundHit.point.y;
            transform.position = next;
        }

        private void Update()
        {
            if (!IsSpawned) return;

            bool isRunning = _isRunning.Value;
            if (_animator != null) _animator.SetFloat(_moveSpeedId, isRunning ? _animatorRunSpeed : 0f);
            if (isRunning) TryPlayStep();
        }

        // Server only: a catcher's hit removes it at once; several colliders hit in one swing pop it once
        public void Pop()
        {
            if (!IsServer || _isPopped || !IsSpawned) return;

            _isPopped = true;
            NetworkObject.Despawn();
        }

        private bool TrySnapToGround(float searchDepthInMeters)
        {
            Vector3 position = transform.position;
            if (!Physics.Raycast(position + Vector3.up * _groundProbeHeightInMeters, Vector3.down, out RaycastHit groundHit,
                _groundProbeHeightInMeters + searchDepthInMeters, _environmentLayers, QueryTriggerInteraction.Ignore)) return false;

            position.y = groundHit.point.y;
            transform.position = position;
            return true;
        }

        private void TryPlayStep()
        {
            _stepProgress += _stepsPerSecond * Time.deltaTime;
            if (_stepProgress < 1f) return;

            _stepProgress -= 1f;
            if (_footstepSource == null || _soundSet == null) return;

            int index = _soundSet.PickNextIndex(_lastClipIndex);
            if (index < 0) return;

            _lastClipIndex = index;
            _footstepSource.pitch = Random.Range(_soundSet.PitchRange.x, _soundSet.PitchRange.y);
            _footstepSource.PlayOneShot(_soundSet.Clips[index], _soundSet.Volume);
        }

        private async UniTaskVoid DespawnAfterLifetimeAsync(CancellationToken token)
        {
            await UniTask.WaitForSeconds(_lifetimeInSeconds, cancellationToken: token);
            Pop();
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
    }
}
