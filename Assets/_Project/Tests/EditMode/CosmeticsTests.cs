using NUnit.Framework;
using Project.Assets._Project._Scripts.Cosmetics;
using Project.Assets._Project._Scripts.Player.Cosmetics;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class CosmeticsTests
    {
        private const string TestSaveKey = "CosmeticsTests.CosmeticProfile";
        private const int DefaultWeaponId = 1;
        private const int GoldWeaponId = 2;
        private const int DefaultRunnerOutfitId = 10;
        private const int CapId = 11;
        private const int GoldPrice = 100;
        private const int CapPrice = 50;

        private readonly List<Object> _created = new();
        private PointRewards _rewards;
        private CosmeticCatalog _catalog;
        private CosmeticItem _defaultWeapon;
        private CosmeticItem _goldWeapon;
        private CosmeticItem _defaultRunnerOutfit;
        private CosmeticItem _cap;

        [SetUp]
        public void SetUp()
        {
            _rewards = Create<PointRewards>();
            var serializedRewards = new SerializedObject(_rewards);
            serializedRewards.FindProperty("<PointsPerRound>k__BackingField").intValue = 10;
            serializedRewards.FindProperty("<WinBonus>k__BackingField").intValue = 20;
            serializedRewards.FindProperty("<PointsPerCatch>k__BackingField").intValue = 5;
            serializedRewards.FindProperty("<PointsPerRescue>k__BackingField").intValue = 4;
            serializedRewards.FindProperty("<PointsPerStation>k__BackingField").intValue = 3;
            serializedRewards.FindProperty("<ChaseStepInSeconds>k__BackingField").floatValue = 10f;
            serializedRewards.FindProperty("<PointsPerChaseStep>k__BackingField").intValue = 2;
            serializedRewards.FindProperty("<MaxChasePoints>k__BackingField").intValue = 6;
            serializedRewards.ApplyModifiedPropertiesWithoutUndo();

            _defaultWeapon = CreateItem(DefaultWeaponId, CosmeticSlot.CatcherWeapon, 0, true);
            _goldWeapon = CreateItem(GoldWeaponId, CosmeticSlot.CatcherWeapon, GoldPrice, false);
            _defaultRunnerOutfit = CreateItem(DefaultRunnerOutfitId, CosmeticSlot.RunnerOutfit, 0, true);
            _cap = CreateItem(CapId, CosmeticSlot.RunnerOutfit, CapPrice, false);

            _catalog = Create<CosmeticCatalog>();
            _catalog.Items.AddRange(new[] { _defaultWeapon, _goldWeapon, _defaultRunnerOutfit, _cap });
            var serializedCatalog = new SerializedObject(_catalog);
            serializedCatalog.FindProperty("<SaveKey>k__BackingField").stringValue = TestSaveKey;
            serializedCatalog.ApplyModifiedPropertiesWithoutUndo();
            PlayerPrefs.DeleteKey(TestSaveKey);
        }

        [TearDown]
        public void TearDown()
        {
            PlayerPrefs.DeleteKey(TestSaveKey);
            foreach (var created in _created) Object.DestroyImmediate(created);
            _created.Clear();
        }

        [Test]
        public void Points_WinnerGetsBaseWinBonusAndActions()
        {
            var points = PointsCalculator.Calculate(_rewards, true, true, 2, 1, 3, 25f);

            Assert.AreEqual(10, points.Base);
            Assert.AreEqual(20, points.WinBonus);
            Assert.AreEqual(10, points.Catches);
            Assert.AreEqual(4, points.Rescues);
            Assert.AreEqual(9, points.Stations);
            // two full 10 s steps
            Assert.AreEqual(4, points.Chase);
            Assert.AreEqual(57, points.Total);
        }

        [Test]
        public void Points_LoserGetsNoWinBonus()
        {
            var points = PointsCalculator.Calculate(_rewards, true, false, 0, 0, 0, 0f);

            Assert.AreEqual(0, points.WinBonus);
            Assert.AreEqual(10, points.Total);
        }

        [Test]
        public void Points_NoTeamEarnsNothing() => Assert.AreEqual(0, PointsCalculator.Calculate(_rewards, false, true, 3, 3, 3, 60f).Total);

        [Test]
        public void Points_ChaseIsCapped() => Assert.AreEqual(6, PointsCalculator.Calculate(_rewards, true, false, 0, 0, 0, 500f).Chase);

        [Test]
        public void Points_ChaseShorterThanAStepEarnsNothing() => Assert.AreEqual(0, PointsCalculator.Calculate(_rewards, true, false, 0, 0, 0, 9.9f).Chase);

        [Test]
        public void Ledger_SameRoundPaysItsTotalOnce()
        {
            var ledger = new RoundPointsLedger();

            Assert.AreEqual(30, ledger.TakeOwed(1, 30));
            Assert.AreEqual(0, ledger.TakeOwed(1, 30));
        }

        [Test]
        public void Ledger_LateStatsPayOnlyTheDifference()
        {
            var ledger = new RoundPointsLedger();

            Assert.AreEqual(30, ledger.TakeOwed(1, 30));
            Assert.AreEqual(5, ledger.TakeOwed(1, 35));
            Assert.AreEqual(0, ledger.TakeOwed(1, 10));
            Assert.AreEqual(35, ledger.AwardedPoints);
        }

        [Test]
        public void Ledger_NextRoundPaysAgain()
        {
            var ledger = new RoundPointsLedger();
            ledger.TakeOwed(1, 30);

            Assert.AreEqual(20, ledger.TakeOwed(2, 20));
        }

        [Test]
        public void Purchase_NotEnoughPoints_IsRefused()
        {
            var profile = new CosmeticProfile { Points = GoldPrice - 1 };

            Assert.AreEqual(PurchaseResult.NotEnoughPoints, profile.CheckPurchase(_goldWeapon));
        }

        [Test]
        public void Purchase_AlreadyOwned_IsRefused()
        {
            var profile = new CosmeticProfile { Points = GoldPrice * 2 };
            profile.OwnedItemIds.Add(GoldWeaponId);

            Assert.AreEqual(PurchaseResult.AlreadyOwned, profile.CheckPurchase(_goldWeapon));
        }

        [Test]
        public void Purchase_DefaultIsAlwaysOwned()
        {
            var profile = new CosmeticProfile();

            Assert.IsTrue(profile.IsOwned(_defaultWeapon));
            Assert.AreEqual(PurchaseResult.AlreadyOwned, profile.CheckPurchase(_defaultWeapon));
        }

        [Test]
        public void Service_BuyDeductsAndSaves()
        {
            var service = new CosmeticProfileService(_catalog);
            service.AddPoints(GoldPrice + 5);

            Assert.IsTrue(service.TryBuy(_goldWeapon));

            var reloaded = new CosmeticProfileService(_catalog);
            Assert.AreEqual(5, reloaded.Points);
            Assert.IsTrue(reloaded.IsOwned(_goldWeapon));
        }

        [Test]
        public void Service_BuyWithTooFewPoints_ChangesNothing()
        {
            var service = new CosmeticProfileService(_catalog);
            service.AddPoints(CapPrice - 1);

            Assert.IsFalse(service.TryBuy(_cap));
            Assert.AreEqual(CapPrice - 1, service.Points);
            Assert.IsFalse(service.IsOwned(_cap));
        }

        [Test]
        public void Service_EquipIsSavedAndRaisesLoadoutChange()
        {
            var service = new CosmeticProfileService(_catalog);
            service.AddPoints(CapPrice);
            service.TryBuy(_cap);
            int loadoutChanges = 0;
            service.OnLoadoutChanged += () => loadoutChanges++;

            Assert.IsTrue(service.TryEquip(_cap));

            Assert.AreEqual(1, loadoutChanges);
            Assert.AreSame(_cap, new CosmeticProfileService(_catalog).GetEquipped(CosmeticSlot.RunnerOutfit));
        }

        [Test]
        public void Service_EquipNotOwned_IsRefused()
        {
            var service = new CosmeticProfileService(_catalog);

            Assert.IsFalse(service.TryEquip(_goldWeapon));
            Assert.AreSame(_defaultWeapon, service.GetEquipped(CosmeticSlot.CatcherWeapon));
        }

        [Test]
        public void Equipped_NothingSaved_FallsBackToDefault() =>
            Assert.AreSame(_defaultWeapon, _catalog.ResolveEquipped(new CosmeticProfile(), CosmeticSlot.CatcherWeapon));

        [Test]
        public void Equipped_UnknownId_FallsBackToDefault()
        {
            var profile = new CosmeticProfile { EquippedCatcherWeaponId = 999 };

            Assert.AreSame(_defaultWeapon, _catalog.ResolveEquipped(profile, CosmeticSlot.CatcherWeapon));
        }

        [Test]
        public void Equipped_NotOwned_FallsBackToDefault()
        {
            var profile = new CosmeticProfile { EquippedCatcherWeaponId = GoldWeaponId };

            Assert.AreSame(_defaultWeapon, _catalog.ResolveEquipped(profile, CosmeticSlot.CatcherWeapon));
        }

        [Test]
        public void Equipped_IdFromAnotherSlot_FallsBackToDefault()
        {
            var profile = new CosmeticProfile { EquippedCatcherWeaponId = CapId };
            profile.OwnedItemIds.Add(CapId);

            Assert.AreSame(_defaultWeapon, _catalog.ResolveEquipped(profile, CosmeticSlot.CatcherWeapon));
        }

        [Test]
        public void Save_RoundTripKeepsEverything()
        {
            var profile = new CosmeticProfile { Points = 42, EquippedRunnerOutfitId = CapId };
            profile.OwnedItemIds.Add(CapId);

            var loaded = CosmeticProfile.FromJson(profile.ToJson());

            Assert.AreEqual(42, loaded.Points);
            CollectionAssert.AreEqual(new[] { CapId }, loaded.OwnedItemIds);
            Assert.AreEqual(CapId, loaded.EquippedRunnerOutfitId);
        }

        [Test]
        public void Save_MissingFieldsKeepDefaults()
        {
            var loaded = CosmeticProfile.FromJson("{\"Points\":7}");

            Assert.AreEqual(7, loaded.Points);
            Assert.IsNotNull(loaded.OwnedItemIds);
            Assert.AreEqual(0, loaded.OwnedItemIds.Count);
            Assert.AreEqual(CosmeticProfile.NoItem, loaded.EquippedCatcherWeaponId);
            Assert.AreEqual(CosmeticProfile.NoItem, loaded.EquippedCatcherOutfitId);
            Assert.AreEqual(CosmeticProfile.NoItem, loaded.EquippedRunnerOutfitId);
        }

        [Test]
        public void Save_UnreadableSave_StartsFresh()
        {
            PlayerPrefs.SetString(TestSaveKey, "not json");

            Assert.AreEqual(0, new CosmeticProfileService(_catalog).Points);
        }

        [Test]
        public void Loadout_ServerDropsIdsTheSlotDoesNotHave()
        {
            var loadout = new CosmeticLoadout { CatcherWeaponId = GoldWeaponId, CatcherOutfitId = 999, RunnerOutfitId = GoldWeaponId };

            var validated = loadout.ValidatedBy(_catalog);

            Assert.AreEqual(GoldWeaponId, validated.CatcherWeaponId);
            Assert.AreEqual(CosmeticProfile.NoItem, validated.CatcherOutfitId);
            Assert.AreEqual(CosmeticProfile.NoItem, validated.RunnerOutfitId);
        }

        private T Create<T>() where T : ScriptableObject
        {
            var instance = ScriptableObject.CreateInstance<T>();
            _created.Add(instance);
            return instance;
        }

        private CosmeticItem CreateItem(int id, CosmeticSlot slot, int price, bool isDefault)
        {
            var item = Create<CosmeticItem>();
            var serialized = new SerializedObject(item);
            serialized.FindProperty("<Id>k__BackingField").intValue = id;
            serialized.FindProperty("<Slot>k__BackingField").enumValueIndex = (int)slot;
            serialized.FindProperty("<Price>k__BackingField").intValue = price;
            serialized.FindProperty("<IsDefault>k__BackingField").boolValue = isDefault;
            serialized.ApplyModifiedPropertiesWithoutUndo();
            return item;
        }
    }
}
