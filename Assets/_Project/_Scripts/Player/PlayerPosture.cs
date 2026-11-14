using KBCore.Refs;
using System;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // The owner's movement picks the posture; every instance shrinks the body and lowers the eyes to match,
    // so a crouched runner is as small for the catcher as it is on its own screen. The body collider comes with
    // each team model, so it's picked up again whenever the model changes.
    [RequireComponent(typeof(PlayerTeam))]
    public class PlayerPosture : NetworkBehaviour
    {
        // the top comes down by the height lost, so the centre comes down by half of it
        private const float CenterShiftPerHeightLost = 0.5f;

        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField] private Transform _cameraTarget;

        public event Action<Posture> OnPostureChanged;

        private readonly NetworkVariable<Posture> _posture = new(Posture.Standing, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
        private CapsuleCollider _body;
        private float _standingHeight;
        private Vector3 _standingCenter;
        private Vector3 _standingCameraLocalPosition;
        private Vector3 _targetCameraLocalPosition;

        public Posture Posture => _posture.Value;
        public bool IsLowered => _posture.Value is Posture.Crouching or Posture.Sliding;
        public float BodyRadius => _body != null ? _body.radius : 0f;
        public float StandingHeight => _standingHeight;

        private void OnValidate() => this.ValidateRefs();

        // subscribed before any OnNetworkSpawn, so the first team model is caught too
        private void Awake()
        {
            _standingCameraLocalPosition = _cameraTarget.localPosition;
            _targetCameraLocalPosition = _standingCameraLocalPosition;
            _team.OnModelChanged += HandleModelChanged;
            _team.OnStatsChanged += HandleStatsChanged;
        }

        public override void OnNetworkSpawn()
        {
            _posture.OnValueChanged += HandlePostureValueChanged;
            HandleModelChanged(_team.Model);
            ApplyBody(snapCamera: true);
        }

        private void Update()
        {
            if (_team.CurrentStats == null) return;

            _cameraTarget.localPosition = EUtils.Math.Lerp(_cameraTarget.localPosition, _targetCameraLocalPosition, _team.CurrentStats.Parkour.CrouchCameraSmoothing);
        }

        // Owner only
        public void ChangePosture(Posture posture)
        {
            if (!IsOwner || _posture.Value == posture) return;
            _posture.Value = posture;
        }

        // Whether the full standing body fits at these feet; the ground itself is left out by starting the check above it
        public bool HasHeadroomToStand(Vector3 feetPosition, LayerMask obstacleLayers, float groundClearance)
        {
            if (_body == null) return true;

            float radius = _body.radius;
            Vector3 bottom = feetPosition + Vector3.up * (radius + groundClearance);
            Vector3 top = feetPosition + Vector3.up * (_standingHeight - radius);
            return !Physics.CheckCapsule(bottom, top, radius, obstacleLayers, QueryTriggerInteraction.Ignore);
        }

        private void HandlePostureValueChanged(Posture previous, Posture current)
        {
            ApplyBody(snapCamera: false);
            OnPostureChanged?.Invoke(current);
        }

        private void HandleModelChanged(Transform model)
        {
            var body = model != null ? model.GetComponentInChildren<CapsuleCollider>() : null;
            // the same model again (spawn after the team already applied it) may already be shrunk, so its size isn't the standing size
            if (body == null || body == _body) return;

            _body = body;

            _standingHeight = _body.height;
            _standingCenter = _body.center;
            ApplyBody(snapCamera: false);
        }

        private void HandleStatsChanged(PlayerStats _) => ApplyBody(snapCamera: false);

        // The body keeps its feet where they are and loses height from the top
        private void ApplyBody(bool snapCamera)
        {
            if (_team.CurrentStats == null || _body == null) return;

            float height = IsLowered ? Mathf.Min(_team.CurrentStats.Parkour.CrouchHeight, _standingHeight) : _standingHeight;
            float heightLost = _standingHeight - height;
            _body.height = height;
            _body.center = _standingCenter + Vector3.down * (heightLost * CenterShiftPerHeightLost);
            _targetCameraLocalPosition = _standingCameraLocalPosition + Vector3.down * heightLost;
            if (snapCamera) _cameraTarget.localPosition = _targetCameraLocalPosition;
        }

        public override void OnNetworkDespawn() => _posture.OnValueChanged -= HandlePostureValueChanged;

        public override void OnDestroy()
        {
            _team.OnModelChanged -= HandleModelChanged;
            _team.OnStatsChanged -= HandleStatsChanged;
            base.OnDestroy();
        }
    }
}
