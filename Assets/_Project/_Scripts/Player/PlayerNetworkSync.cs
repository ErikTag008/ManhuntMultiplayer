using KBCore.Refs;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Owner writes the look rotations; the held weapon follows the animated hand. Remote instances ease toward the synced values every frame
    [RequireComponent(typeof(PlayerTeam))]
    public class PlayerNetworkSync : NetworkBehaviour
    {
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField] private Transform _cameraFollower;

        private readonly NetworkVariable<float> _modelYaw = new(0f, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
        private readonly NetworkVariable<Quaternion> _cameraFollowerRotation = new(Quaternion.identity, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

        private float SendThresholdInDegrees => _team.CurrentStats.NetworkVariableDetectionMinMagnitude;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            _team.OnModelChanged += HandleModelChanged;
        }

        // runs after the other components' spawn, once the model exists
        protected override void OnNetworkPostSpawn() => SnapToSyncedValues();

        private void Update()
        {
            if (!IsSpawned || IsOwner || _team.CurrentStats == null) return;

            float smoothingSpeed = _team.CurrentStats.NetworkVariableSmoothingSpeed;
            var model = _team.Model;
            if (model != null)
                model.rotation = EUtils.Math.Slerp(model.rotation, Quaternion.Euler(0f, _modelYaw.Value, 0f), smoothingSpeed);

            _cameraFollower.rotation = EUtils.Math.Slerp(_cameraFollower.rotation, _cameraFollowerRotation.Value, smoothingSpeed);
        }

        // Owner only; small changes are skipped to keep traffic down, remote smoothing hides the steps
        public void SendModelYaw(float yaw)
        {
            if (!IsOwner) return;
            if (Mathf.Abs(Mathf.DeltaAngle(_modelYaw.Value, yaw)) < SendThresholdInDegrees) return;

            _modelYaw.Value = yaw;
        }

        public void SendCameraFollowerRotation(Quaternion rotation)
        {
            if (!IsOwner) return;
            if (Quaternion.Angle(_cameraFollowerRotation.Value, rotation) < SendThresholdInDegrees) return;

            _cameraFollowerRotation.Value = rotation;
        }

        // a fresh model would otherwise swing in from its default rotation
        private void HandleModelChanged(Transform model)
        {
            if (!IsOwner && model != null) model.rotation = Quaternion.Euler(0f, _modelYaw.Value, 0f);
        }

        // initial values arrive with the spawn and don't raise OnValueChanged
        private void SnapToSyncedValues()
        {
            if (IsOwner) return;

            HandleModelChanged(_team.Model);
            _cameraFollower.rotation = _cameraFollowerRotation.Value;
        }

        public override void OnNetworkDespawn()
        {
            _team.OnModelChanged -= HandleModelChanged;
        }
    }
}
