using KBCore.Refs;
using Project.Assets._Project._Scripts.Player.Abilities;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Feeds the current model's Animator from this player's estimated movement and synced state on every instance, so remote
    // players animate too. The parameter names are the contract any model's Animator Controller must match
    // (the placeholder now, the human-made one later).
    [RequireComponent(typeof(PlayerTeam), typeof(PlayerLifeState), typeof(PlayerRescue))]
    [RequireComponent(typeof(PlayerAbility), typeof(PlayerMotion), typeof(PlayerPosture))]
    [RequireComponent(typeof(PlayerCombat))]
    public class PlayerAnimator : ValidatedMonoBehaviour
    {
        [SerializeField, Self] private PlayerTeam _team;
        [SerializeField, Self] private PlayerLifeState _lifeState;
        [SerializeField, Self] private PlayerRescue _rescue;
        [SerializeField, Self] private PlayerAbility _ability;
        [SerializeField, Self] private PlayerMotion _motion;
        [SerializeField, Self] private PlayerPosture _posture;
        [SerializeField, Self] private PlayerCombat _combat;
        // the owner's look rotation, synced and smoothed on remote instances by PlayerNetworkSync
        [SerializeField] private Transform _cameraFollower;
        [SerializeField] private string _moveSpeedParameter = "MoveSpeed";
        [SerializeField] private string _verticalSpeedParameter = "VerticalSpeed";
        [SerializeField] private string _isGroundedParameter = "IsGrounded";
        [SerializeField] private string _lifeStateParameter = "LifeState";
        [SerializeField] private string _isRescuingParameter = "IsRescuing";
        [SerializeField] private string _isCrouchingParameter = "IsCrouching";
        [SerializeField] private string _isSlidingParameter = "IsSliding";
        [SerializeField] private string _isMantlingParameter = "IsMantling";
        [SerializeField] private string _attackParameter = "Attack";
        [SerializeField] private string _isChargingAttackParameter = "IsChargingAttack";
        [SerializeField] private string _lungeParameter = "Lunge";
        // the attack override layer only gets weight while it plays something: its idle state has no clip, and an
        // idle state with Write Defaults off keeps holding the last pose over the whole body, freezing the walk
        [SerializeField] private string _attackLayerName = "Attack";
        [SerializeField] private string _attackLayerIdleStateName = "Empty";
        // looking up or down tilts the head, and the spine takes the rest so the body follows the gaze
        [SerializeField, Range(0f, 1f)] private float _headLookShare = 0.6f;
        [SerializeField] private float _maxLookPitchInDegrees = 70f;

        private Animator _animator;
        private CharacterRig _rig;
        private int _moveSpeedId;
        private int _verticalSpeedId;
        private int _isGroundedId;
        private int _lifeStateId;
        private int _isRescuingId;
        private int _isCrouchingId;
        private int _isSlidingId;
        private int _isMantlingId;
        private int _attackId;
        private int _isChargingAttackId;
        private int _lungeId;
        private int _attackLayerIdleStateId;
        // -1 when the model's controller has no attack layer
        private int _attackLayerIndex = -1;
        // the last ability trigger set, so it can be cleared if the player goes down before it plays
        private int _pendingAbilityTriggerId;

        private void Awake()
        {
            _moveSpeedId = Animator.StringToHash(_moveSpeedParameter);
            _verticalSpeedId = Animator.StringToHash(_verticalSpeedParameter);
            _isGroundedId = Animator.StringToHash(_isGroundedParameter);
            _lifeStateId = Animator.StringToHash(_lifeStateParameter);
            _isRescuingId = Animator.StringToHash(_isRescuingParameter);
            _isCrouchingId = Animator.StringToHash(_isCrouchingParameter);
            _isSlidingId = Animator.StringToHash(_isSlidingParameter);
            _isMantlingId = Animator.StringToHash(_isMantlingParameter);
            _attackId = Animator.StringToHash(_attackParameter);
            _isChargingAttackId = Animator.StringToHash(_isChargingAttackParameter);
            _lungeId = Animator.StringToHash(_lungeParameter);
            _attackLayerIdleStateId = Animator.StringToHash(_attackLayerIdleStateName);

            // subscribed before any OnNetworkSpawn, so the first team model is caught too
            _team.OnModelChanged += HandleModelChanged;
            _ability.OnAbilityUsed += HandleAbilityUsed;
            _lifeState.OnLifeStateChanged += HandleLifeStateChanged;
            _combat.OnAttackStarted += HandleAttackStarted;
            _combat.OnLungeStarted += HandleLungeStarted;
        }

        private void Start() => HandleModelChanged(_team.Model);

        private void LateUpdate()
        {
            if (_animator == null) return;

            _animator.SetFloat(_moveSpeedId, _motion.NormalizedPlanarSpeed);
            _animator.SetFloat(_verticalSpeedId, _motion.VerticalSpeed);
            _animator.SetBool(_isGroundedId, _motion.IsGrounded);
            _animator.SetInteger(_lifeStateId, (int)_lifeState.State);
            // progress runs on both the rescuer and the knocked runner; only the one standing kneels to help
            _animator.SetBool(_isRescuingId, _lifeState.IsUp && _rescue.RescueProgress > 0f);
            _animator.SetBool(_isCrouchingId, _posture.Posture == Posture.Crouching);
            _animator.SetBool(_isSlidingId, _posture.Posture == Posture.Sliding);
            _animator.SetBool(_isMantlingId, _posture.Posture == Posture.Mantling);
            _animator.SetBool(_isChargingAttackId, _combat.IsCharging);
            RefreshAttackLayerWeight();
            ApplyLookPitch();
        }

        // a trigger set this frame moves the layer out of idle on the next Animator update, a frame before it gets its weight
        private void RefreshAttackLayerWeight()
        {
            if (_attackLayerIndex < 0) return;

            bool isAttackLayerBusy = _animator.IsInTransition(_attackLayerIndex)
                || _animator.GetCurrentAnimatorStateInfo(_attackLayerIndex).shortNameHash != _attackLayerIdleStateId;
            _animator.SetLayerWeight(_attackLayerIndex, isAttackLayerBusy ? 1f : 0f);
        }

        // Runs after the Animator wrote this frame's pose, so the tilt is added on top of the animation.
        // Knocked and eliminated poses keep their own head.
        private void ApplyLookPitch()
        {
            if (_rig == null || _cameraFollower == null || !_lifeState.IsUp) return;

            float lookDown = Mathf.Asin(Mathf.Clamp(-_cameraFollower.forward.y, -1f, 1f)) * Mathf.Rad2Deg;
            lookDown = Mathf.Clamp(lookDown, -_maxLookPitchInDegrees, _maxLookPitchInDegrees);
            if (_rig.Spine != null) _rig.Spine.localRotation *= Quaternion.Euler(lookDown * (1f - _headLookShare), 0f, 0f);
            if (_rig.Head != null) _rig.Head.localRotation *= Quaternion.Euler(lookDown * _headLookShare, 0f, 0f);
        }

        private void HandleModelChanged(Transform model)
        {
            _animator = model != null ? model.GetComponentInChildren<Animator>() : null;
            _rig = model != null ? model.GetComponentInChildren<CharacterRig>() : null;
            _attackLayerIndex = -1;
            if (_animator == null) return;

            _attackLayerIndex = _animator.GetLayerIndex(_attackLayerName);

            _animator.applyRootMotion = false;
            // the look tilt is added to the animated pose every frame, so the pose must be rewritten every frame too
            _animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
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

        // the held weapon rides on the hand, so this swing is the weapon's whole attack animation
        private void HandleAttackStarted()
        {
            if (_animator != null) _animator.SetTrigger(_attackId);
        }

        private void HandleLungeStarted()
        {
            if (_animator != null) _animator.SetTrigger(_lungeId);
        }

        private void OnDestroy()
        {
            _team.OnModelChanged -= HandleModelChanged;
            _ability.OnAbilityUsed -= HandleAbilityUsed;
            _lifeState.OnLifeStateChanged -= HandleLifeStateChanged;
            _combat.OnAttackStarted -= HandleAttackStarted;
            _combat.OnLungeStarted -= HandleLungeStarted;
        }
    }
}
