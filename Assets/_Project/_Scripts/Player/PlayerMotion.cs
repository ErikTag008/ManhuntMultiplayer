using KBCore.Refs;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Estimates this player's movement from its transform on every instance (remote players have no movement object),
    // for animation and footsteps. Runs before the components that read it each frame.
    [DefaultExecutionOrder(-10)]
    [RequireComponent(typeof(PlayerTeam))]
    public class PlayerMotion : ValidatedMonoBehaviour
    {
        [SerializeField, Self] private PlayerTeam _team;
        // remote players move in network steps, so raw per-frame speed would flicker
        [SerializeField] private float _speedSmoothing = 12f;
        [SerializeField] private float _groundProbeHeight = 0.1f;
        [SerializeField] private float _groundProbeDistance = 0.25f;
        // a bigger jump between two frames is a teleport (respawn, spawn point), not movement
        [SerializeField] private float _maxSampleDistance = 3f;

        private Vector3 _lastPosition;
        private float _planarSpeed;
        private float _verticalSpeed;
        private float _planarDistanceThisFrame;
        private bool _isGrounded;

        public float PlanarSpeed => _planarSpeed;
        public float VerticalSpeed => _verticalSpeed;
        // Unsmoothed, and zero on a teleport frame
        public float PlanarDistanceThisFrame => _planarDistanceThisFrame;
        public bool IsGrounded => _isGrounded;
        // 1 = the team's full run speed
        public float NormalizedPlanarSpeed
        {
            get
            {
                float maxMoveSpeed = _team.CurrentStats != null ? _team.CurrentStats.MaxMoveSpeed : 0f;
                return maxMoveSpeed > 0f ? _planarSpeed / maxMoveSpeed : 0f;
            }
        }

        private void Awake() => _lastPosition = transform.position;

        private void LateUpdate()
        {
            Vector3 position = transform.position;
            Vector3 delta = position - _lastPosition;
            _lastPosition = position;
            _planarDistanceThisFrame = 0f;
            _isGrounded = ProbeGround();
            if (delta.magnitude > _maxSampleDistance || Time.deltaTime <= 0f) return;

            float planarDistance = new Vector2(delta.x, delta.z).magnitude;
            _planarDistanceThisFrame = planarDistance;
            _planarSpeed = EUtils.Math.Lerp(_planarSpeed, planarDistance / Time.deltaTime, _speedSmoothing);
            _verticalSpeed = EUtils.Math.Lerp(_verticalSpeed, delta.y / Time.deltaTime, _speedSmoothing);
        }

        private bool ProbeGround()
        {
            if (_team.CurrentStats == null) return false;
            return Physics.Raycast(transform.position + Vector3.up * _groundProbeHeight, Vector3.down, _groundProbeHeight + _groundProbeDistance, _team.CurrentStats.GroundCheckLayers);
        }
    }
}
