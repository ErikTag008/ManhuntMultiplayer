using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System.Threading;
using System;

namespace Project.Assets._Project._Scripts.Weapons
{
    public class MeleeWeaponBase : WeaponBase
    {
        private bool _isAttackDown = false;
        [SerializeField] private MeleeAttackType _meleeAttackType = MeleeAttackType.Swing;
        [SerializeField] private float _attackCheckRadius = 2f;
        [SerializeField] private float _windupAnimationDuration = 0.2f;
        [SerializeField] private float _attackAnimationDuration = 0.5f;
        [SerializeField] private float _pullBackAniationDuration = 0.3f;
        [SerializeField] private Ease _windupEase = Ease.InExpo;
        [SerializeField] private Ease _attackEase = Ease.OutQuad;
        [SerializeField] private Ease _pullBackEase = Ease.OutQuad;
        private bool IsSwingAttack => _meleeAttackType == MeleeAttackType.Swing;
        private bool IsThrustAttack => _meleeAttackType == MeleeAttackType.Thrust;
        private bool IsSlashAttack => _meleeAttackType == MeleeAttackType.Slash;
        [Alchemy.Inspector.ShowIf(nameof(IsSwingAttack))]
        [SerializeField] private Vector3 _swingWindUpAngle = new(-45, 0, 0), _swingAttackAngle = new(90f, 0,0);

        [Alchemy.Inspector.ShowIf(nameof(IsThrustAttack))]
        [SerializeField] private Vector3 _thrustWindUpPos = new(0, 0, -0.5f), _thrustAttackPos = new(0, 0, 1f);

        [Alchemy.Inspector.ShowIf(nameof(IsSlashAttack))]
        [SerializeField] private Vector3 _slashWindUpAngle = new(0, -45, 0), _slashAttackAngle = new(0, 135f, 0);
        [SerializeField] private int _attackDamage = 5;
        [SerializeField] private float _attackCooldown = 1f;
        [SerializeField] private Transform _hitDetectionCenter;
        private bool _canAttack = true;
        private Sequence _swingSequence, _thrustSequence, _slashSequence;
        public event Action<Vector3> OnWeaponPositionChanged;
        public event Action<Quaternion> OnWeaponRotationChanged;
        public event Action<Vector3, float> OnCheckDamageRequested;

        private float _networkUpdateMinMagnitude;
        private Vector3 _lastWeaponPosition;
        private Quaternion _lastWeaponRotation;

        public override void SetNetworkUpdateMinMagnitude(float minMagnitude)
        {
            _networkUpdateMinMagnitude = minMagnitude;
        }

        [Alchemy.Inspector.Button]
        public override void Attack()
        {
            _isAttackDown = true;
            if (!_canAttack) return;
            AttackWithCooldown(this.destroyCancellationToken).Forget();
            EUtils.Logger.Log("Melee Attack");
        }

        public override void StopAttack()
        {
            _isAttackDown = false;
            EUtils.Logger.Log("Stop Melee Attack");
        }
        public override void UpdateTarget(Vector3 target)
        {
            // This method can be used to update the target position for the melee weapon if needed.
        }

        private async UniTaskVoid AttackWithCooldown(CancellationToken token)
        {
            _canAttack = false;
            
            switch (_meleeAttackType)
            {
                case MeleeAttackType.Swing:
                    _swingSequence?.Kill();
                    _swingSequence = CreateSwing();
                    _swingSequence.Play();
                    break;
                case MeleeAttackType.Thrust:
                    _thrustSequence?.Kill();
                    _thrustSequence = CreateThrust();
                    _thrustSequence.Play();
                    break;
                case MeleeAttackType.Slash:
                    _slashSequence?.Kill();
                    _slashSequence = CreateSlash();
                    _slashSequence.Play();
                    break;
            }
            await UniTask.WaitForSeconds(_attackAnimationDuration + _pullBackAniationDuration, cancellationToken: token);
            await UniTask.WaitForSeconds(_attackCooldown, cancellationToken: token);
            _canAttack = true;
        }

        private void CheckDamage()
        {
            OnCheckDamageRequested?.Invoke(_hitDetectionCenter.position, _attackCheckRadius);
        }
        private void UpdateWeaponPosition()
        {
            if (Vector3.Distance(transform.localPosition,_lastWeaponPosition) > _networkUpdateMinMagnitude)
            {
                _lastWeaponPosition = transform.localPosition;
                OnWeaponPositionChanged?.Invoke(_lastWeaponPosition);
            }
        }
        private void UpdateWeaponRotation()
        {
            if (Mathf.Abs(transform.localEulerAngles.magnitude - _lastWeaponRotation.eulerAngles.magnitude) > _networkUpdateMinMagnitude)
            {
                _lastWeaponRotation = transform.rotation;
                OnWeaponRotationChanged?.Invoke(_lastWeaponRotation);
            }

        }

        private Sequence CreateSwing()
        {
            Vector3 startRot = transform.localEulerAngles;

            return DOTween.Sequence()
                .Append(transform.DOLocalRotate(
                    startRot + _swingWindUpAngle,
                    _windupAnimationDuration)
                    .SetEase(_windupEase))
                    .OnUpdate(UpdateWeaponRotation)

                .Append(transform.DOLocalRotate(
                    startRot + _swingAttackAngle,
                    _attackAnimationDuration)
                    .SetEase(_attackEase))
                    .OnUpdate(UpdateWeaponRotation)


                .AppendCallback(CheckDamage)

                .Append(transform.DOLocalRotate(
                    startRot,
                    _pullBackAniationDuration)
                    .SetEase(_pullBackEase))
                    .OnUpdate(UpdateWeaponRotation);


        }

        private Sequence CreateThrust()
        {
            Vector3 startPos = transform.localPosition;
            return DOTween.Sequence()
                .Append(transform.DOLocalMove(startPos + _thrustWindUpPos, _windupAnimationDuration)
                    .SetEase(_windupEase))
                    .OnUpdate(UpdateWeaponPosition)

                .Append(transform.DOLocalMove(startPos + _thrustAttackPos - _thrustWindUpPos, _attackAnimationDuration)
                    .SetEase(_attackEase))
                    .OnUpdate(UpdateWeaponPosition)

                .AppendCallback(CheckDamage)
                .Append(transform.DOLocalMove(startPos, _attackAnimationDuration)
                    .SetEase(_pullBackEase))
                    .OnUpdate(UpdateWeaponPosition);

        }

        private Sequence CreateSlash()
        {
            Vector3 startRot = transform.localEulerAngles;
            return DOTween.Sequence()
                .Append(transform.DOLocalRotate(startRot + _slashWindUpAngle, _windupAnimationDuration)
                    .SetEase(_windupEase))
                    .OnUpdate(UpdateWeaponRotation)

                .Append(transform.DOLocalRotate(startRot + _slashAttackAngle, _attackAnimationDuration)
                    .SetEase(_attackEase))
                    .OnUpdate(UpdateWeaponRotation)

                .AppendCallback(CheckDamage)
                .Append(transform.DOLocalRotate(startRot, _pullBackAniationDuration)
                    .SetEase(_pullBackEase))
                    .OnUpdate(UpdateWeaponRotation);

        }

        private void OnDrawGizmos()
        {
            if (_hitDetectionCenter == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_hitDetectionCenter.position, _attackCheckRadius);
        }

        public override void Reload()
        {
            // Melee weapons typically don't have a reload mechanic, but this method can be used to reset any necessary states or play a reload animation if desired.
        }

        public enum MeleeAttackType
        {
            Swing,
            Thrust,
            Slash
        }
    }
}
