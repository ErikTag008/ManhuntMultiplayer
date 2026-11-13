using KBCore.Refs;
using Project.Assets._Project._Scripts.Player.Abilities;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Feeds the current model's Animator from this player's movement and synced state on every instance, so remote
    // players animate too. The parameter names are the contract any model's Animator Controller must match
    // (the placeholder now, the human-made one later).
    [RequireComponent(typeof(PlayerTeam), typeof(PlayerLifeState), typeof(PlayerRescue))]
    [RequireComponent(typeof(PlayerAbility))]
    public class PlayerAnimator : ValidatedMonoBehaviour
    {
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField, Self] private PlayerRescue _rescue;
        [SerializeField, Self] private PlayerAbility _ability;
        [SerializeField] private string _moveSpeedParameter = "MoveSpeed";
        [SerializeField] private string _verticalSpeedParameter = "VerticalSpeed";
        [SerializeField] private string _isGroundedParameter = "IsGrounded";
        [SerializeField] private string _lifeStateParameter = "LifeState";
        [SerializeField] private string _isRescuingParameter = "IsRescuing";
        // remote players move in network steps, so raw per-frame speed would flicker the blend
        [SerializeField] private float _speedSmoothing = 12f;
        [SerializeField] private float _groundProbeHeight = 0.1f;
        [SerializeField] private float _groundProbeDistance = 0.25f;
        // a bigger jump between two frames is a teleport (respawn, spawn point), not movement
        [SerializeField] private float _maxSampleDistance = 3f;

        private Animator _animator;
        private int _moveSpeedId;
        private int _verticalSpeedId;
        private int _isGroundedId;
        private int _lifeStateId;
        private int _isRescuingId;
        // the last ability trigger set, so it can be cleared if the player goes down before it plays
        private int _pendingAbilityTriggerId;
        private Vector3 _lastPosition;
        private float _smoothedPlanarSpeed;
        private float _smoothedVerticalSpeed;

        private void Awake()
        {
            _moveSpeedId = Animator.StringToHash(_moveSpeedParameter);
            _verticalSpeedId = Animator.StringToHash(_verticalSpeedParameter);
            _isGroundedId = Animator.StringToHash(_isGroundedParameter);
            _lifeStateId = Animator.StringToHash(_lifeStateParameter);
            _isRescuingId = Animator.StringToHash(_isRescuingParameter);
            _lastPosition = transform.position;

            // subscribed before any OnNetworkSpawn, so the first team model is caught too
            _team.OnModelChanged += HandleModelChanged;
            _ability.OnAbilityUsed += HandleAbilityUsed;
            _lifeState.OnLifeStateChanged += HandleLifeStateChanged;
        }

        private void Start() => HandleModelChanged(_team.Model);

        private void LateUpdate()
        {
            Vector3 position = transform.position;
            Vector3 delta = position - _lastPosition;
            _lastPosition = position;
            if (_animator == null || _team.CurrentStats == null) return;

            if (delta.magnitude <= _maxSampleDistance && Time.deltaTime > 0f)
            {
                Vector3 velocity = delta / Time.deltaTime;
                _smoothedPlanarSpeed = EUtils.Math.Lerp(_smoothedPlanarSpeed, new Vector2(velocity.x, velocity.z).magnitude, _speedSmoothing);
                _smoothedVerticalSpeed = EUtils.Math.Lerp(_smoothedVerticalSpeed, velocity.y, _speedSmoothing);
            }
            float maxMoveSpeed = _team.CurrentStats.MaxMoveSpeed;

            _animator.SetFloat(_moveSpeedId, maxMoveSpeed > 0f ? _smoothedPlanarSpeed / maxMoveSpeed : 0f);
            _animator.SetFloat(_verticalSpeedId, _smoothedVerticalSpeed);
            _animator.SetBool(_isGroundedId, IsGrounded());
            _animator.SetInteger(_lifeStateId, (int)_lifeState.State);
            // progress runs on both the rescuer and the knocked runner; only the one standing kneels to help
            _animator.SetBool(_isRescuingId, _lifeState.IsUp && _rescue.RescueProgress > 0f);
        }

        // Owner-side movement isn't available on remote instances, so grounding is probed here for everyone
        private bool IsGrounded() =>
            Physics.Raycast(transform.position + Vector3.up * _groundProbeHeight, Vector3.down, _groundProbeHeight + _groundProbeDistance, _team.CurrentStats.GroundCheckLayers);

        private void HandleModelChanged(Transform model)
        {
            _animator = model != null ? model.GetComponentInChildren<Animator>() : null;
            if (_animator != null) _animator.applyRootMotion = false;
        }

        // each ability names its own trigger, so a double jump doesn't play the dash
        private void HandleAbilityUsed(AbilityData ability)
        {
            if (_animator == null || string.IsNullOrEmpty(ability.AnimationTrigger)) return;

            _pendingAbilityTriggerId = Animator.StringToHash(ability.AnimationTrigger);
            _animator.SetTrigger(_pendingAbilityTriggerId);
        }

        private void HandleLifeStateChanged(LifeState state)
        {
            if (state == LifeState.Up || _animator == null || _pendingAbilityTriggerId == 0) return;
            _animator.ResetTrigger(_pendingAbilityTriggerId);
        }

        private void OnDestroy()
        {
            _team.OnModelChanged -= HandleModelChanged;
            _ability.OnAbilityUsed -= HandleAbilityUsed;
            _lifeState.OnLifeStateChanged -= HandleLifeStateChanged;
        }
    }
}
