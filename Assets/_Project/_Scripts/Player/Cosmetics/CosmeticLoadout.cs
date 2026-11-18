using Project.Assets._Project._Scripts.Cosmetics;
using System;
using Unity.Netcode;

namespace Project.Assets._Project._Scripts.Player.Cosmetics
{
    // A player's equipped item id per slot, as synced to every instance
    public struct CosmeticLoadout : INetworkSerializable, IEquatable<CosmeticLoadout>
    {
        public int CatcherWeaponId;
        public int CatcherOutfitId;
        public int RunnerOutfitId;

        public static CosmeticLoadout Empty => new()
        {
            CatcherWeaponId = CosmeticProfile.NoItem,
            CatcherOutfitId = CosmeticProfile.NoItem,
            RunnerOutfitId = CosmeticProfile.NoItem
        };

        public static CosmeticLoadout FromProfile(CosmeticProfileService profile) => new()
        {
            CatcherWeaponId = profile.GetEquippedId(CosmeticSlot.CatcherWeapon),
            CatcherOutfitId = profile.GetEquippedId(CosmeticSlot.CatcherOutfit),
            RunnerOutfitId = profile.GetEquippedId(CosmeticSlot.RunnerOutfit)
        };

        public readonly int GetId(CosmeticSlot slot) => slot switch
        {
            CosmeticSlot.CatcherWeapon => CatcherWeaponId,
            CosmeticSlot.CatcherOutfit => CatcherOutfitId,
            CosmeticSlot.RunnerOutfit => RunnerOutfitId,
            _ => CosmeticProfile.NoItem
        };

        // ids the catalog doesn't have for that slot become no pick, so every instance shows the default there
        public readonly CosmeticLoadout ValidatedBy(CosmeticCatalog catalog) => new()
        {
            CatcherWeaponId = ValidateId(catalog, CatcherWeaponId, CosmeticSlot.CatcherWeapon),
            CatcherOutfitId = ValidateId(catalog, CatcherOutfitId, CosmeticSlot.CatcherOutfit),
            RunnerOutfitId = ValidateId(catalog, RunnerOutfitId, CosmeticSlot.RunnerOutfit)
        };

        private static int ValidateId(CosmeticCatalog catalog, int id, CosmeticSlot slot) =>
            catalog.TryGet(id, slot, out _) ? id : CosmeticProfile.NoItem;

        public readonly bool Equals(CosmeticLoadout other) =>
            CatcherWeaponId == other.CatcherWeaponId &&
            CatcherOutfitId == other.CatcherOutfitId &&
            RunnerOutfitId == other.RunnerOutfitId;

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref CatcherWeaponId);
            serializer.SerializeValue(ref CatcherOutfitId);
            serializer.SerializeValue(ref RunnerOutfitId);
        }
    }
}
