using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{

    public class PlayerMovement : IPlayerMovement
    {
        private readonly Rigidbody _rb;
        private readonly PlayerPosture _posture;
        private IMovementStats _stats;
        private readonly Transform _groundCheck;
        private Camera _camera;
        private Transform _model;
        private Transform _cameraFollower;
        private float _lastGroundedTime = -Mathf.Infinity;
        private float _lastJumpPressedTime = -Mathf.Infinity;
        private Vector3 _lastGroundNormal = Vector3.up;
        private bool _movementEnabled = true;
        private int _airJumpFrame = -1;
        private bool _isParkourEnabled = true;
        private bool _isCrouchHeld;
        private float _slideEndTime;
        private float _lastSlideStopTime = -Mathf.Infinity;
        private float _lastWallJumpTime = -Mathf.Infinity;
        private float _wallJumpControlLockEndTime = -Mathf.Infinity;
        private Vector3 _lastWallJumpNormal;
        private bool _hasWallJumpedSinceGrounded;
        private int _wallJumpFrame = -1;
        private bool _isMantling;
        private float _mantleStartTime;
        private Vector3 _mantleRiseTarget;
        private Vector3 _mantleLanding;
        private float _dashEndTime = -Mathf.Infinity;
        private Vector3 _dashVelocity;
        public event Action<float> ModelRotationChanged;
        public event Action<Quaternion> CameraFollowerRotationChanged;

        public PlayerMovement(Rigidbody rb, IMovementStats stats, Transform groundCheck, Camera camera, Transform model, Transform cameraFollower, PlayerPosture posture)
        {
            _rb = rb;
            _stats = stats;
            _groundCheck = groundCheck;
            _camera = camera;
            _model = model;
            _cameraFollower = cameraFollower;
            _posture = posture;
        }

        private ParkourSettings Parkour => _stats.Parkour;
        private bool IsSliding => _posture.Posture == Posture.Sliding;
        private bool IsDashing => Time.time < _dashEndTime;

        public void ToggleMovement(bool isEnabled)
        {
            _movementEnabled = isEnabled;
            if (!_movementEnabled)
            {
                StopDash();
                CancelMantle();
                _rb.linearVelocity = Vector3.zero;
                _rb.angularVelocity = Vector3.zero;
            }
        }

        // Off while knocked: crawling players can't slide, wall-jump or climb
        public void ToggleParkour(bool isEnabled)
        {
            _isParkourEnabled = isEnabled;
            if (_isParkourEnabled) return;

            CancelMantle();
            if (IsSliding) StopSlide();
            // eliminated players stop running HandleFixedMovement, so the stand-up can't wait for UpdatePosture
            if (_posture.Posture == Posture.Crouching && _stats != null && HasHeadroomToStand()) _posture.ChangePosture(Posture.Standing);
        }

        public void ToggleCrouchHeld(bool isHeld)
        {
            _isCrouchHeld = isHeld;
            if (!isHeld || !_movementEnabled || !_isParkourEnabled || _isMantling || _stats == null) return;

            if (CanStartSlide()) StartSlide();
            else if (_posture.Posture == Posture.Standing) _posture.ChangePosture(Posture.Crouching);
        }

        public void ChangeCamera(Camera camera)
        {
            _camera = camera;
        }
        public void ChangeStats(IMovementStats stats)
        {
            if (stats == null) return;
            _stats = stats;
        }
        public void ChangeModel(Transform model)
        {
            if (model == null) return;
            _model = model;
        }
        public void ChangeCameraFollower(Transform cameraFollower)
        {
            if (cameraFollower == null) return;
            _cameraFollower = cameraFollower;
        }
        public void HandleJump(bool isButtonDown = true)
        {
            if (!_movementEnabled) return;

            if (isButtonDown)
            {
                // this press was already spent on an air jump; buffering it too would give a third jump on landing
                if (Time.frameCount == _airJumpFrame || _isMantling) return;

                _lastJumpPressedTime = Time.time;
                if ((IsGrounded() || Time.time - _lastGroundedTime <= _stats.CoyoteTime) && GetVelocityAlongGroundNormal() < _stats.GroundCheckMaxYVelocity)
                {
                    PerformJump();
                    _lastJumpPressedTime = -Mathf.Infinity;
                    return;
                }

                if (TryWallJump()) _lastJumpPressedTime = -Mathf.Infinity;
            }
            else
            {
                if(_rb.linearVelocity.y > _stats.JumpButtonUpMinVerticalVelocity)
                {
                    SlowDownVerticalVelocity();
                }
                _lastJumpPressedTime = -Mathf.Infinity;
            }

            void SlowDownVerticalVelocity()
            {
                var velocityVector = _rb.linearVelocity;
                velocityVector.y *= _stats.JumpButtonUpVerticalVelocityMultiplier;
                _rb.linearVelocity = velocityVector;
            }
        }

        public bool IsGrounded()
        {
            if (_groundCheck == null || _stats == null) return false;

            if (Physics.Raycast(_groundCheck.position, Vector3.down, out RaycastHit hitInfo, _stats.GroundCheckRadius, _stats.GroundCheckLayers))
            {
                _lastGroundNormal = hitInfo.normal;
                if (_model == null) return false;
                float groundAngle = Vector3.Angle(_lastGroundNormal, _model.up);
                return groundAngle <= _stats.MaxGroundAngle;
            }
            else
            {
                _lastGroundNormal = Vector3.up;
                return false;
            }
        }

        private float GetVelocityAlongGroundNormal()
        {
            return Vector3.Dot(_rb.linearVelocity, _lastGroundNormal);
        }

        public void HandleFixedMovement(Vector2 moveDirection)
        {
            if(_stats == null || !_movementEnabled) return;
            if (_isMantling)
            {
                UpdateMantle();
                return;
            }

            bool grounded = IsGrounded();
            if (grounded)
            {
                _lastGroundedTime = Time.time;
                _hasWallJumpedSinceGrounded = false;
            }

            UpdatePosture(grounded);
            if (!grounded && TryStartMantle(moveDirection)) return;

            if (IsDashing)
            {
                HoldDashVelocity();
                if (!grounded && _rb.linearVelocity.y < 0f) _rb.AddForce(Physics.gravity, ForceMode.Acceleration);
                TryConsumeBufferedJump(grounded);
                return;
            }

            // a slide coasts on its own momentum, so input doesn't steer or brake it
            if (!IsSliding) HandleHorizontalMovement(moveDirection, grounded);
            if (grounded)
            {
                _rb.linearDamping = IsSliding ? Parkour.SlideDamping : _stats.HorizontalDamping;
            }
            else
            {
                _rb.linearDamping = _stats.VerticalDamping;
                if (_rb.linearVelocity.y < 0f)
                    _rb.AddForce(Physics.gravity, ForceMode.Acceleration);
            }

            TryConsumeBufferedJump(grounded);

        }

        public void HandleRotation()
        {
            HandleModelRotation();
            HandleCameraFollowerRotation();
        }

        private void HandleCameraFollowerRotation()
        {
            if (!_cameraFollower || !_cameraFollower.gameObject.activeInHierarchy || _stats == null) return;
            Quaternion newRotation = _camera.transform.rotation;
            _cameraFollower.rotation = newRotation;
            CameraFollowerRotationChanged?.Invoke(newRotation);
        }

        private void HandleModelRotation()
        {
            if (!_camera || !_camera.gameObject.activeInHierarchy || _stats == null || !_movementEnabled) return;

            Vector3 cameraForward = _camera.transform.forward;
            cameraForward.y = 0f;
            if (cameraForward == Vector3.zero) return;

            Quaternion newRotation = Quaternion.LookRotation(cameraForward);
            if(_model != null)
                _model.rotation = newRotation;

            ModelRotationChanged?.Invoke(newRotation.eulerAngles.y);
        }

        private void HandleHorizontalMovement(Vector2 moveDirection, bool grounded)
        {
            if (!_camera || !_camera.gameObject.activeInHierarchy || _stats == null || !_movementEnabled) return;
            Vector3 moveVector = _camera.transform.forward * moveDirection.y +
                                 _camera.transform.right * moveDirection.x;
            float magnitude = moveDirection.magnitude;

            moveVector.y = 0f;
            if (moveVector.sqrMagnitude > 0f) moveVector.Normalize();

            // project desired movement onto ground plane when grounded
            Vector3 moveDir = grounded
                            ? Vector3.ProjectOnPlane(moveVector, _lastGroundNormal)
                            : moveVector;


            if (moveDir.sqrMagnitude > 0f) moveDir.Normalize();

            Vector3 velocity = _rb.linearVelocity;
            Vector3 planarVelocity = grounded
                                    ? Vector3.ProjectOnPlane(velocity, _lastGroundNormal)
                                    : new Vector3(velocity.x, 0f, velocity.z);

            float maxSpeed = _posture.Posture == Posture.Crouching ? _stats.MaxMoveSpeed * Parkour.CrouchSpeedMultiplier : _stats.MaxMoveSpeed;
            float accel = grounded ? _stats.GroundAcceleration : GetAirAcceleration();

            Vector3 targetVelocity = magnitude * maxSpeed * moveDir;
            Vector3 velocityDelta = targetVelocity - planarVelocity;

            velocityDelta = Vector3.ClampMagnitude(velocityDelta, accel * Time.fixedDeltaTime);
            Vector3 applyDelta = grounded
                                ? Vector3.ProjectOnPlane(velocityDelta, _lastGroundNormal)
                                : velocityDelta;
            _rb.AddForce(applyDelta, ForceMode.VelocityChange);
        }

        // right after a wall-jump there is no air steering, so holding toward the wall doesn't cancel the kick
        private float GetAirAcceleration() => Time.time < _wallJumpControlLockEndTime ? 0f : _stats.AirAcceleration;

        private void TryConsumeBufferedJump(bool grounded)
        {
            if (!_movementEnabled) return;

            if (Time.time - _lastJumpPressedTime > _stats.JumpBuffer) return;

            if ((grounded || Time.time - _lastGroundedTime <= _stats.CoyoteTime) && GetVelocityAlongGroundNormal() < _stats.GroundCheckMaxYVelocity)
            {
                PerformJump();
                _lastJumpPressedTime = -Mathf.Infinity;
                return;
            }
        }

        // True when a jump press now would be an ordinary jump: on the ground or within coyote time
        public bool CanJumpFromGround() =>
            _stats != null && (IsGrounded() || Time.time - _lastGroundedTime <= _stats.CoyoteTime);

        // True when a jump press now kicks off a wall, or this frame's press already did; air-jump abilities stand back for it
        public bool CanWallJump() => Time.frameCount == _wallJumpFrame || TryGetWallJumpNormal(out _);

        // Replaces the fall with a fresh upward push. HandleJump may see the same press after this, so it's marked as spent.
        public void AirJump(float jumpForceMultiplier)
        {
            if (!_movementEnabled || _stats == null || _isMantling) return;

            Vector3 velocity = _rb.linearVelocity;
            _rb.linearVelocity = new Vector3(velocity.x, 0f, velocity.z);
            _rb.AddForce(Vector3.up * (_stats.JumpForce * jumpForceMultiplier), ForceMode.VelocityChange);
            _lastJumpPressedTime = -Mathf.Infinity;
            _airJumpFrame = Time.frameCount;
        }

        // A burst along the view direction, flattened so looking up or down doesn't launch the player.
        // The speed is held for the whole duration; afterwards normal movement and damping slow it down.
        public void Dash(float speed, float durationInSeconds)
        {
            if (!_movementEnabled || !_camera || _isMantling) return;

            Vector3 direction = _camera.transform.forward;
            direction.y = 0f;
            if (direction.sqrMagnitude <= 0f) return;

            if (IsSliding) StopSlide();
            _dashVelocity = direction.normalized * speed;
            _dashEndTime = Time.time + durationInSeconds;
            HoldDashVelocity();
        }

        // input, damping and the slide don't act during a dash; gravity still pulls it down off ledges
        private void HoldDashVelocity()
        {
            _rb.linearDamping = 0f;
            _rb.linearVelocity = _dashVelocity + Vector3.up * _rb.linearVelocity.y;
        }

        private void StopDash() => _dashEndTime = -Mathf.Infinity;

        private void PerformJump()
        {
            if (!_movementEnabled) return;
            if (IsSliding) StopSlide();
            // remove any velocity component that points into the ground normal
            float intoNormal = Vector3.Dot(_rb.linearVelocity, _lastGroundNormal);
            if (intoNormal < 0f)
            {
                _rb.linearVelocity -= _lastGroundNormal * intoNormal;
            }

            // choose jump direction: along ground normal when grounded, otherwise world up
            Vector3 jumpDir = IsGrounded() ? _lastGroundNormal : Vector3.up;

            _rb.AddForce(jumpDir * _stats.JumpForce, ForceMode.VelocityChange);
        }

        // Crouch held keeps the body low; letting go stands up again once nothing is overhead
        private void UpdatePosture(bool grounded)
        {
            switch (_posture.Posture)
            {
                case Posture.Sliding:
                    if (!grounded || !_isCrouchHeld || Time.time >= _slideEndTime || GetPlanarVelocity().magnitude < Parkour.SlideEndSpeed)
                        StopSlide();
                    break;
                case Posture.Crouching:
                    if ((!_isCrouchHeld || !_isParkourEnabled) && HasHeadroomToStand()) _posture.ChangePosture(Posture.Standing);
                    break;
                case Posture.Standing:
                    if (_isCrouchHeld && _isParkourEnabled) _posture.ChangePosture(Posture.Crouching);
                    break;
            }
        }

        private bool CanStartSlide()
        {
            if (IsSliding || Time.time < _lastSlideStopTime + Parkour.SlideCooldownInSeconds) return false;
            return IsGrounded() && GetPlanarVelocity().magnitude >= Parkour.SlideMinStartSpeed;
        }

        // The slide keeps the run's direction and adds a burst on top
        private void StartSlide()
        {
            Vector3 planarVelocity = GetPlanarVelocity();
            Vector3 otherVelocity = _rb.linearVelocity - planarVelocity;
            float slideSpeed = Mathf.Min(planarVelocity.magnitude + Parkour.SlideBoostSpeed, Parkour.SlideMaxSpeed);
            _rb.linearVelocity = planarVelocity.normalized * slideSpeed + otherVelocity;
            _slideEndTime = Time.time + Parkour.SlideMaxDurationInSeconds;
            _posture.ChangePosture(Posture.Sliding);
        }

        private void StopSlide()
        {
            _lastSlideStopTime = Time.time;
            bool staysLow = (_isCrouchHeld && _isParkourEnabled) || !HasHeadroomToStand();
            _posture.ChangePosture(staysLow ? Posture.Crouching : Posture.Standing);
        }

        private Vector3 GetPlanarVelocity() => Vector3.ProjectOnPlane(_rb.linearVelocity, _lastGroundNormal);

        private bool HasHeadroomToStand() => _posture.HasHeadroomToStand(_rb.position, _stats.GroundCheckLayers, Parkour.SurfaceClearance);

        private bool TryWallJump()
        {
            if (!TryGetWallJumpNormal(out Vector3 wallNormal)) return false;

            StopDash();
            // the kick replaces the push into the wall and keeps the run along it
            Vector3 velocity = _rb.linearVelocity;
            Vector3 planarVelocity = new(velocity.x, 0f, velocity.z);
            Vector3 alongWall = planarVelocity - wallNormal * Vector3.Dot(planarVelocity, wallNormal);
            _rb.linearVelocity = alongWall + wallNormal * Parkour.WallJumpAwaySpeed + Vector3.up * Parkour.WallJumpUpSpeed;

            _lastWallJumpTime = Time.time;
            _wallJumpControlLockEndTime = Time.time + Parkour.WallJumpControlLockInSeconds;
            _lastWallJumpNormal = wallNormal;
            _hasWallJumpedSinceGrounded = true;
            _wallJumpFrame = Time.frameCount;
            return true;
        }

        // Airborne next to a wall that isn't the one just used; landing frees every wall again
        private bool TryGetWallJumpNormal(out Vector3 wallNormal)
        {
            wallNormal = Vector3.zero;
            if (!_movementEnabled || !_isParkourEnabled || _isMantling || _stats == null) return false;
            if (CanJumpFromGround() || Time.time < _lastWallJumpTime + Parkour.WallJumpCooldownInSeconds) return false;
            if (!ParkourProbe.TryFindWall(_rb.position, _posture.BodyRadius, Parkour, _stats.GroundCheckLayers, out wallNormal)) return false;

            return !_hasWallJumpedSinceGrounded || Vector3.Dot(wallNormal, _lastWallJumpNormal) < Parkour.SameWallNormalDot;
        }

        // Airborne and pushing forward at a ledge in reach: pull up onto it
        private bool TryStartMantle(Vector2 moveDirection)
        {
            if (!_isParkourEnabled || !_camera || moveDirection.y < Parkour.MantleMinForwardInput) return false;

            Vector3 forward = _camera.transform.forward;
            if (!ParkourProbe.TryFindLedge(_rb.position, forward, _posture.BodyRadius, _posture.StandingHeight, _stats.MaxGroundAngle,
                    Parkour, _stats.GroundCheckLayers, out Vector3 landing)) return false;

            Vector3 feetPosition = _rb.position;
            _mantleRiseTarget = new Vector3(feetPosition.x, landing.y, feetPosition.z);
            _mantleLanding = landing;
            _mantleStartTime = Time.time;
            StopDash();
            _isMantling = true;
            _lastJumpPressedTime = -Mathf.Infinity;
            _rb.useGravity = false;
            _rb.linearDamping = 0f;
            _posture.ChangePosture(Posture.Mantling);
            UpdateMantle();
            return true;
        }

        // Straight up beside the wall first, then forward over the edge, each in a fixed time
        private void UpdateMantle()
        {
            float elapsed = Time.time - _mantleStartTime;
            float riseDuration = Parkour.MantleRiseDurationInSeconds;
            float totalDuration = riseDuration + Parkour.MantleForwardDurationInSeconds;

            if (elapsed < riseDuration) MoveToward(_mantleRiseTarget, riseDuration - elapsed);
            else if (elapsed < totalDuration) MoveToward(_mantleLanding, totalDuration - elapsed);
            else FinishMantle();
        }

        private void MoveToward(Vector3 target, float remainingTime)
        {
            _rb.linearVelocity = (target - _rb.position) / Mathf.Max(remainingTime, Time.fixedDeltaTime);
        }

        private void FinishMantle()
        {
            Vector3 forward = _mantleLanding - _mantleRiseTarget;
            forward.y = 0f;
            CancelMantle();
            _rb.linearVelocity = forward.sqrMagnitude > 0f ? forward.normalized * Parkour.MantleExitSpeed : Vector3.zero;
        }

        private void CancelMantle()
        {
            if (!_isMantling) return;

            _isMantling = false;
            _rb.useGravity = true;
            bool staysLow = _isCrouchHeld && _isParkourEnabled;
            _posture.ChangePosture(staysLow ? Posture.Crouching : Posture.Standing);
        }

        public void DrawGizmos()
        {
            if (!_movementEnabled) return;

            if (_groundCheck != null && _stats != null)
            {
                Gizmos.color = IsGrounded() ? Color.green : Color.red;
                Gizmos.DrawWireSphere(_groundCheck.position, _stats.GroundCheckRadius);
            }
        }


    }
}
