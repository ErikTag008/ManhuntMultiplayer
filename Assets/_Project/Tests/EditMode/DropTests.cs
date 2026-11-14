using NUnit.Framework;
using Project.Assets._Project._Scripts.Player.Drops;
using UnityEditor;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class DropTests
    {
        [Test]
        public void WeightedPick_ZeroAndNegativeWeights_AreNeverPicked()
        {
            var weights = new[] { 0f, 2f, -1f, 0f };

            Assert.IsTrue(WeightedPick.TryPickIndex(weights, 0f, out int first));
            Assert.IsTrue(WeightedPick.TryPickIndex(weights, 0.5f, out int middle));
            Assert.IsTrue(WeightedPick.TryPickIndex(weights, 1f, out int last));
            Assert.AreEqual(1, first);
            Assert.AreEqual(1, middle);
            Assert.AreEqual(1, last);
        }

        [Test]
        public void WeightedPick_EmptyOrAllZero_ReturnsFalse()
        {
            Assert.IsFalse(WeightedPick.TryPickIndex(new float[0], 0.5f, out int emptyIndex));
            Assert.IsFalse(WeightedPick.TryPickIndex(new[] { 0f, -2f }, 0.5f, out int zeroIndex));
            Assert.IsFalse(WeightedPick.TryPickIndex(null, 0.5f, out int nullIndex));
            Assert.AreEqual(-1, emptyIndex);
            Assert.AreEqual(-1, zeroIndex);
            Assert.AreEqual(-1, nullIndex);
        }

        [Test]
        public void WeightedPick_RandomValue_MapsOntoWeightRanges()
        {
            // ranges: [0, 0.25) -> 0, [0.25, 1) -> 1
            var weights = new[] { 1f, 3f };

            WeightedPick.TryPickIndex(weights, 0f, out int atStart);
            WeightedPick.TryPickIndex(weights, 0.24f, out int belowBoundary);
            WeightedPick.TryPickIndex(weights, 0.25f, out int atBoundary);
            WeightedPick.TryPickIndex(weights, 1f, out int atEnd);

            Assert.AreEqual(0, atStart);
            Assert.AreEqual(0, belowBoundary);
            Assert.AreEqual(1, atBoundary);
            Assert.AreEqual(1, atEnd);
        }

        [Test]
        public void WeightedPick_RandomValueOfOne_PicksLastWeightedEntry()
        {
            var weights = new[] { 1f, 1f, 0f };

            Assert.IsTrue(WeightedPick.TryPickIndex(weights, 1f, out int index));
            Assert.AreEqual(1, index);
        }

        [Test]
        public void DropEffectData_Has_MatchesAnySetStatus()
        {
            var effect = ScriptableObject.CreateInstance<DropEffectData>();
            var serializedEffect = new SerializedObject(effect);
            serializedEffect.FindProperty("<Statuses>k__BackingField").intValue = (int)(DropStatus.Invisible | DropStatus.Shielded);
            serializedEffect.ApplyModifiedPropertiesWithoutUndo();

            Assert.IsTrue(effect.Has(DropStatus.Invisible));
            Assert.IsTrue(effect.Has(DropStatus.Shielded));
            Assert.IsFalse(effect.Has(DropStatus.Revealed));
            Assert.IsFalse(effect.Has(DropStatus.None));

            Object.DestroyImmediate(effect);
        }
    }
}
