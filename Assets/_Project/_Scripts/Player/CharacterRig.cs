using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Bones of a character model that gameplay drives on top of its animation. Sits on the model prefab root,
    // so each model (the placeholder now, the human-made one later) points it at its own bones.
    public class CharacterRig : MonoBehaviour
    {
        [SerializeField] private Transform _head;
        [SerializeField] private Transform _spine;

        public Transform Head => _head;
        public Transform Spine => _spine;
    }
}
