using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Cosmetics
{
    // Every unlock, looked up by the id stored in the save and in the synced loadout
    [CreateAssetMenu(fileName = "CosmeticCatalog", menuName = "ScriptableObjects/CosmeticCatalog", order = 1)]
    public class CosmeticCatalog : ScriptableObject
    {
        [field: SerializeField] public string SaveKey { get; private set; } = "CosmeticProfile";
        [field: SerializeField] public List<CosmeticItem> Items { get; private set; } = new();

        public bool Contains(CosmeticItem item) => item != null && Items.Contains(item);

        public bool TryGet(int id, CosmeticSlot slot, out CosmeticItem item)
        {
            foreach (var candidate in Items)
            {
                if (candidate == null || candidate.Id != id || candidate.Slot != slot) continue;

                item = candidate;
                return true;
            }

            item = null;
            return false;
        }

        public CosmeticItem GetDefault(CosmeticSlot slot)
        {
            foreach (var item in Items)
            {
                if (item != null && item.Slot == slot && item.IsDefault) return item;
            }

            return null;
        }

        // a synced id: ownership can't be checked, so only an unknown id falls back to the default
        public CosmeticItem Resolve(int id, CosmeticSlot slot) => TryGet(id, slot, out var item) ? item : GetDefault(slot);

        // the saved pick while it still exists and is owned, otherwise the slot's default
        public CosmeticItem ResolveEquipped(CosmeticProfile profile, CosmeticSlot slot) =>
            TryGet(profile.GetEquippedId(slot), slot, out var item) && profile.IsOwned(item) ? item : GetDefault(slot);

        public void CopyItems(CosmeticSlot slot, List<CosmeticItem> items)
        {
            items.Clear();
            foreach (var item in Items)
            {
                if (item != null && item.Slot == slot) items.Add(item);
            }
        }
    }
}
