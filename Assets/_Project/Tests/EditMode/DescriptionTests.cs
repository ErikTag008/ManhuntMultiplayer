using NUnit.Framework;
using Project.Assets._Project._Scripts.Player.Abilities;
using Project.Assets._Project._Scripts.Player.Drops;
using Project.Assets._Project._Scripts.UI.HUD;
using UnityEditor;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class DescriptionTests
    {
        [Test]
        public void DropEffectData_FormatDescription_FillsInTheDuration()
        {
            var effect = ScriptableObject.CreateInstance<DropEffectData>();
            var serializedEffect = new SerializedObject(effect);
            serializedEffect.FindProperty("<Description>k__BackingField").stringValue = "Run faster for {0:0} s";
            serializedEffect.FindProperty("<DurationInSeconds>k__BackingField").floatValue = 7.6f;
            serializedEffect.ApplyModifiedPropertiesWithoutUndo();

            Assert.AreEqual("Run faster for 8 s", effect.FormatDescription());

            Object.DestroyImmediate(effect);
        }

        [Test]
        public void AbilityData_FormatDescription_FillsInTheActiveDuration()
        {
            var ability = ScriptableObject.CreateInstance<SixthSenseAbilityData>();
            var serializedAbility = new SerializedObject(ability);
            serializedAbility.FindProperty("<Description>k__BackingField").stringValue = "See every catcher for {0:0} s";
            serializedAbility.FindProperty("<ActiveDurationInSeconds>k__BackingField").floatValue = 4f;
            serializedAbility.ApplyModifiedPropertiesWithoutUndo();

            Assert.AreEqual("See every catcher for 4 s", ability.FormatDescription());

            Object.DestroyImmediate(ability);
        }

        [Test]
        public void DropCatalogEffects_AllHaveAFormattableDescription()
        {
            foreach (var catalog in LoadAll<DropCatalog>())
            {
                foreach (var effect in catalog.Effects)
                {
                    if (effect == null) continue;

                    Assert.IsFalse(string.IsNullOrWhiteSpace(effect.Description), $"{effect.name} has no description");
                    Assert.DoesNotThrow(() => effect.FormatDescription(), effect.name);
                }
            }
        }

        [Test]
        public void AbilityCatalogAbilities_AllHaveAFormattableDescription()
        {
            foreach (var catalog in LoadAll<AbilityCatalog>())
            {
                foreach (var ability in catalog.Abilities)
                {
                    if (ability == null) continue;

                    Assert.IsFalse(string.IsNullOrWhiteSpace(ability.Description), $"{ability.name} has no description");
                    Assert.DoesNotThrow(() => ability.FormatDescription(), ability.name);
                }
            }
        }

        [Test]
        public void GameHUDState_NotifyDropTaken_PassesNameDescriptionAndGoodness()
        {
            var state = new GameHUDState();
            string takenName = null;
            string takenDescription = null;
            bool takenIsGood = true;
            state.OnDropTaken += (effectName, description, isGood) =>
            {
                takenName = effectName;
                takenDescription = description;
                takenIsGood = isGood;
            };

            state.NotifyDropTaken("Revealed", "Catchers see you through walls for 8 s", false);

            Assert.AreEqual("Revealed", takenName);
            Assert.AreEqual("Catchers see you through walls for 8 s", takenDescription);
            Assert.IsFalse(takenIsGood);
        }

        [Test]
        public void GameHUDState_SetSpectating_RaisesOnlyOnChange()
        {
            var state = new GameHUDState();
            int raisedCount = 0;
            state.OnSpectatingChanged += () => raisedCount++;

            state.SetSpectating(true);
            state.SetSpectating(true);
            state.SetSpectating(false);

            Assert.AreEqual(2, raisedCount);
            Assert.IsFalse(state.IsSpectating);
        }

        private static T[] LoadAll<T>() where T : Object
        {
            string[] guids = AssetDatabase.FindAssets($"t:{typeof(T).Name}");
            var assets = new T[guids.Length];
            for (int i = 0; i < guids.Length; i++) assets[i] = AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guids[i]));
            return assets;
        }
    }
}
