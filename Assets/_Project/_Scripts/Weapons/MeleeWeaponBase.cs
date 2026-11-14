using UnityEngine;

namespace Project.Assets._Project._Scripts.Weapons
{
    // A held melee weapon: the model's hand animation swings it, this only describes its grip and hit.
    // The prefab root is the grip point; it sits on the character's weapon socket.
    public class MeleeWeaponBase : MonoBehaviour
    {
        [SerializeField] private Transform _hitDetectionCenter;
        [SerializeField] private float _attackCheckRadius = 0.75f;
        // time from the swing start until the weapon reaches the target; match the Attack animation
        [SerializeField] private float _hitDelayInSeconds = 0.25f;
        // from one swing start to the next
        [SerializeField] private float _attackCooldownInSeconds = 1f;
        // the server rejects a hit centred farther than this from the attacker's position (reach plus network lag)
        [SerializeField] private float _maxHitOriginDistance = 5f;

        public Vector3 HitOrigin => _hitDetectionCenter != null ? _hitDetectionCenter.position : transform.position;
        public float HitRadius => _attackCheckRadius;
        public float HitDelayInSeconds => _hitDelayInSeconds;
        public float AttackCooldownInSeconds => _attackCooldownInSeconds;
        public float MaxHitOriginDistance => _maxHitOriginDistance;

        // the socket places the grip; a weapon with its own offset in the prefab would sit wrong on another model
        public void AttachTo(Transform socket)
        {
            transform.SetParent(socket, false);
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(HitOrigin, _attackCheckRadius);
        }
    }
}
