using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Cosmetics
{
    // The player's saved points, bought items and picks. Public fields so JsonUtility can save them;
    // fields missing from an older save keep their defaults.
    [Serializable]
    public class CosmeticProfile
    {
        // no pick saved: the slot shows its default
        public const int NoItem = -1;

        public int Points;
        // default items are owned without being listed
        public List<int> OwnedItemIds = new();
        public int EquippedCatcherWeaponId = NoItem;
        public int EquippedCatcherOutfitId = NoItem;
        public int EquippedRunnerOutfitId = NoItem;

        public static CosmeticProfile FromJson(string json)
        {
            var profile = new CosmeticProfile();
            JsonUtility.FromJsonOverwrite(json, profile);
            profile.Sanitize();
            return profile;
        }

        public string ToJson() => JsonUtility.ToJson(this);

        public bool IsOwned(CosmeticItem item) => item != null && (item.IsDefault || OwnedItemIds.Contains(item.Id));

        public PurchaseResult CheckPurchase(CosmeticItem item)
        {
            if (item == null) return PurchaseResult.Unavailable;
            if (IsOwned(item)) return PurchaseResult.AlreadyOwned;
            return Points >= item.Price ? PurchaseResult.Allowed : PurchaseResult.NotEnoughPoints;
        }

        // Call only after CheckPurchase allowed it
        public void Buy(CosmeticItem item)
        {
            Points -= item.Price;
            OwnedItemIds.Add(item.Id);
        }

        public int GetEquippedId(CosmeticSlot slot) => slot switch
        {
            CosmeticSlot.CatcherWeapon => EquippedCatcherWeaponId,
            CosmeticSlot.CatcherOutfit => EquippedCatcherOutfitId,
            CosmeticSlot.RunnerOutfit => EquippedRunnerOutfitId,
            _ => NoItem
        };

        public void SetEquippedId(CosmeticSlot slot, int id)
        {
            switch (slot)
            {
                case CosmeticSlot.CatcherWeapon:
                    EquippedCatcherWeaponId = id;
                    break;
                case CosmeticSlot.CatcherOutfit:
                    EquippedCatcherOutfitId = id;
                    break;
                case CosmeticSlot.RunnerOutfit:
                    EquippedRunnerOutfitId = id;
                    break;
            }
        }

        // a hand-edited or broken save can't go below zero points or lose the owned list
        private void Sanitize()
        {
            Points = Mathf.Max(0, Points);
            OwnedItemIds ??= new();
        }
    }

    public enum PurchaseResult
    {
        Allowed,
        AlreadyOwned,
        NotEnoughPoints,
        Unavailable
    }
}
