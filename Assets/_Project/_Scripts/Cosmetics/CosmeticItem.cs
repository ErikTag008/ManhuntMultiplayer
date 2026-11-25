using UnityEngine;

namespace Project.Assets._Project._Scripts.Cosmetics
{
    // One unlock in the shop. The Id is saved and sent over the network, so it is never reused for another item.
    // The look is a placeholder swap point: a weapon only uses MaterialOverride; an outfit may attach a prefab to a
    // rig anchor and/or tint the body with MaterialOverride.
    [CreateAssetMenu(fileName = "CosmeticItem", menuName = "ScriptableObjects/CosmeticItem", order = 1)]
    public class CosmeticItem : ScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public string DisplayName { get; private set; }
        [field: SerializeField] public CosmeticSlot Slot { get; private set; }
        [field: SerializeField, Min(0)] public int Price { get; private set; }
        // always owned, and what a slot falls back to when the saved pick is missing or not owned
        [field: SerializeField] public bool IsDefault { get; private set; }
        // replaces every material on the weapon (weapon slot) or the body (outfit slots); empty keeps the model's own
        [field: SerializeField] public Material MaterialOverride { get; private set; }
        // outfit slots only: visuals placed on the anchor, e.g. a hat on the head; its colliders are removed
        [field: SerializeField] public GameObject AttachmentPrefab { get; private set; }
        [field: SerializeField] public CosmeticAnchor Anchor { get; private set; } = CosmeticAnchor.Head;
        // optional shop tile picture; empty uses one rendered from the item on its model
        [field: SerializeField] public Texture Icon { get; private set; }
    }

    // The CharacterRig bone an outfit attachment sits on
    public enum CosmeticAnchor
    {
        Head,
        Spine
    }
}
