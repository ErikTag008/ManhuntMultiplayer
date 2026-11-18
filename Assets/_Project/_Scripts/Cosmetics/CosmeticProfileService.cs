using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Cosmetics
{
    // Holds the local player's cosmetic profile, saves it to PlayerPrefs after every change and says what changed.
    // Local only for now (Steam stats/cloud later), so another player's ownership can't be checked.
    public class CosmeticProfileService
    {
        private readonly CosmeticCatalog _catalog;
        private readonly CosmeticProfile _profile;

        // points, owned items or picks changed
        public event Action OnChanged;
        // a pick changed, so the synced loadout has to be sent again
        public event Action OnLoadoutChanged;

        public CosmeticCatalog Catalog => _catalog;
        public int Points => _profile.Points;

        public CosmeticProfileService(CosmeticCatalog catalog)
        {
            _catalog = catalog;
            _profile = Load();
        }

        public bool IsOwned(CosmeticItem item) => _profile.IsOwned(item);

        public bool IsEquipped(CosmeticItem item) => item != null && GetEquipped(item.Slot) == item;

        public CosmeticItem GetEquipped(CosmeticSlot slot) => _catalog.ResolveEquipped(_profile, slot);

        public int GetEquippedId(CosmeticSlot slot)
        {
            var item = GetEquipped(slot);
            return item != null ? item.Id : CosmeticProfile.NoItem;
        }

        public PurchaseResult CheckPurchase(CosmeticItem item) => _catalog.Contains(item) ? _profile.CheckPurchase(item) : PurchaseResult.Unavailable;

        public void AddPoints(int amount)
        {
            if (amount <= 0) return;

            _profile.Points += amount;
            Save();
            OnChanged?.Invoke();
        }

        public bool TryBuy(CosmeticItem item)
        {
            if (CheckPurchase(item) != PurchaseResult.Allowed) return false;

            _profile.Buy(item);
            Save();
            OnChanged?.Invoke();
            return true;
        }

        public bool TryEquip(CosmeticItem item)
        {
            if (!_catalog.Contains(item) || !_profile.IsOwned(item) || IsEquipped(item)) return false;

            _profile.SetEquippedId(item.Slot, item.Id);
            Save();
            OnChanged?.Invoke();
            OnLoadoutChanged?.Invoke();
            return true;
        }

        private void Save()
        {
            PlayerPrefs.SetString(_catalog.SaveKey, _profile.ToJson());
            PlayerPrefs.Save();
        }

        private CosmeticProfile Load()
        {
            if (!PlayerPrefs.HasKey(_catalog.SaveKey)) return new CosmeticProfile();

            try
            {
                return CosmeticProfile.FromJson(PlayerPrefs.GetString(_catalog.SaveKey));
            }
            catch (ArgumentException exception)
            {
                EUtils.Logger.LogWarning($"[CosmeticProfileService] Saved cosmetics could not be read, starting fresh. {exception.Message}");
                return new CosmeticProfile();
            }
        }
    }
}
