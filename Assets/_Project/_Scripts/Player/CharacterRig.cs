using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Bones of a character model that gameplay drives on top of its animation. Sits on the model prefab root,
    // so each model (the placeholder now, the human-made one later) points it at its own bones.
    public class CharacterRig : MonoBehaviour
    {
        [SerializeField] private Transform _head;
        [SerializeField] private Transform _spine;
        // a child of the hand bone, rotated so a held weapon's grip points the right way; on a humanoid
        // model without one, the right hand bone itself is used
        [SerializeField] private Transform _weaponSocket;

        public Transform Head => _head;
        public Transform Spine => _spine;
        public Transform WeaponSocket => _weaponSocket;

        private void Awake()
        {
            if (_weaponSocket != null) return;

            var animator = GetComponentInChildren<Animator>();
            if (animator != null && animator.isHuman) _weaponSocket = animator.GetBoneTransform(HumanBodyBones.RightHand);
        }
    }
}
