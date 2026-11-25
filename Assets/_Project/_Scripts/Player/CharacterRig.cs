using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Bones of a character model that gameplay drives on top of its animation. Sits on the model prefab root,
    // so each model (the placeholder now, the human-made one later) points it at its own bones. On a humanoid
    // model, a bone left empty falls back to the Avatar's matching bone.
    public class CharacterRig : MonoBehaviour
    {
        [SerializeField] private Transform _head;
        [SerializeField] private Transform _spine;
        // a child of the hand bone, rotated so a held weapon's grip points the right way; on a humanoid
        // model without one, the right hand bone itself is used
        [SerializeField] private Transform _weaponSocket;

        private bool _hasResolvedFallbacks;

        public Transform Head
        {
            get
            {
                ResolveFallbacks();
                return _head;
            }
        }

        public Transform Spine
        {
            get
            {
                ResolveFallbacks();
                return _spine;
            }
        }

        public Transform WeaponSocket
        {
            get
            {
                ResolveFallbacks();
                return _weaponSocket;
            }
        }

        private void Awake() => ResolveFallbacks();

        // also on first use, since a model spawned inactive is read before its Awake runs
        private void ResolveFallbacks()
        {
            if (_hasResolvedFallbacks) return;
            if (_head != null && _spine != null && _weaponSocket != null) return;

            _hasResolvedFallbacks = true;
            var animator = GetComponentInChildren<Animator>(true);
            if (animator == null || !animator.isHuman) return;

            if (_head == null) _head = FindBone(animator, HumanBodyBones.Head);
            if (_spine == null) _spine = FindBone(animator, HumanBodyBones.Spine);
            if (_weaponSocket == null) _weaponSocket = FindBone(animator, HumanBodyBones.RightHand);
        }

        // an Animator that hasn't bound to its model yet (inactive) returns no bones, so then the Avatar's bone map is read
        private static Transform FindBone(Animator animator, HumanBodyBones bone)
        {
            if (animator.isInitialized) return animator.GetBoneTransform(bone);

            string humanName = HumanTrait.BoneName[(int)bone];
            foreach (var mapping in animator.avatar.humanDescription.human)
            {
                if (mapping.humanName == humanName) return FindSkeletonBone(animator, mapping.boneName);
            }

            return null;
        }

        // the skinned meshes' bones first, so an attachment that shares a bone's name is never picked
        private static Transform FindSkeletonBone(Animator animator, string boneName)
        {
            foreach (var skinnedMesh in animator.GetComponentsInChildren<SkinnedMeshRenderer>(true))
            {
                foreach (var bone in skinnedMesh.bones)
                {
                    if (bone != null && bone.name == boneName) return bone;
                }
            }

            return FindChild(animator.transform, boneName);
        }

        private static Transform FindChild(Transform parent, string childName)
        {
            foreach (Transform child in parent)
            {
                if (child.name == childName) return child;

                var found = FindChild(child, childName);
                if (found != null) return found;
            }

            return null;
        }
    }
}
