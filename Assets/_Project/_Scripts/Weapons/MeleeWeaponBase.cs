using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Assets._Project._Scripts.Weapons
{
    // A held melee weapon: the model's hand animation swings it, this only describes its grip and hit.
    // The hit itself is a sweep from the attacker's eye along the view, so it lands where the crosshair is, whatever the animation does.
    // The prefab root is the grip point; it sits on the character's weapon socket.
    public class MeleeWeaponBase : MonoBehaviour
    {
        // the weapon's sweet spot; only drawn as a gizmo now that the hit follows the view
        [SerializeField] private Transform _hitDetectionCenter;
        // thickness of the sweep around the view line; the target's own collider adds to it
        [SerializeField] private float _attackCheckRadius = 0.45f;
        // how far the sweep reaches from the eye
        [SerializeField] private float _reachInMeters = 2.4f;
        // time from the swing start until the weapon reaches the target; match the Attack animation
        [SerializeField] private float _hitDelayInSeconds = 0.25f;
        // the sweep repeats every frame for this long after the hit delay, so a runner crossing the swing isn't missed between frames
        [SerializeField] private float _hitWindowInSeconds = 0.1f;
        // from one swing start to the next
        [SerializeField] private float _attackCooldownInSeconds = 1f;
        // the server rejects a target farther than this from the attacker (reach plus both players' network lag)
        [SerializeField, FormerlySerializedAs("_maxHitOriginDistance")] private float _maxTargetDistance = 7f;

        public Vector3 HitOrigin => _hitDetectionCenter != null ? _hitDetectionCenter.position : transform.position;
        public float HitRadius => _attackCheckRadius;
        public float ReachInMeters => _reachInMeters;
        public float HitDelayInSeconds => _hitDelayInSeconds;
        public float HitWindowInSeconds => _hitWindowInSeconds;
        public float AttackCooldownInSeconds => _attackCooldownInSeconds;
        public float MaxTargetDistance => _maxTargetDistance;

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
