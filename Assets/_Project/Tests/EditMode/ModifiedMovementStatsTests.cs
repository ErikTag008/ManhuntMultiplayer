using NUnit.Framework;
using Project.Assets._Project._Scripts.Player;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class ModifiedMovementStatsTests
    {
        private const float Tolerance = 0.0001f;

        private PlayerStats _baseStats;
        private PlayerStats _otherStats;
        private StatModifierStack _stack;
        private ModifiedMovementStats _movementStats;

        [SetUp]
        public void SetUp()
        {
            _baseStats = ScriptableObject.CreateInstance<PlayerStats>();
            _otherStats = ScriptableObject.CreateInstance<PlayerStats>();
            _stack = new StatModifierStack(() => 0f);
            _movementStats = new ModifiedMovementStats(_baseStats, _stack);
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_baseStats);
            Object.DestroyImmediate(_otherStats);
        }

        [Test]
        public void ModifiableStats_ApplyTheStack()
        {
            _stack.Add(new StatModifier(ModifiableStat.MaxMoveSpeed, StatModifierKind.Multiply, 0.5f));
            _stack.Add(new StatModifier(ModifiableStat.JumpForce, StatModifierKind.Add, 3f));

            Assert.AreEqual(_baseStats.MaxMoveSpeed * 0.5f, _movementStats.MaxMoveSpeed, Tolerance);
            Assert.AreEqual(_baseStats.JumpForce + 3f, _movementStats.JumpForce, Tolerance);
            Assert.AreEqual(_baseStats.GroundAcceleration, _movementStats.GroundAcceleration, Tolerance);
        }

        [Test]
        public void OtherStats_PassThroughUnchanged()
        {
            _stack.Add(new StatModifier(ModifiableStat.MaxMoveSpeed, StatModifierKind.Multiply, 0f));

            Assert.AreEqual(_baseStats.CoyoteTime, _movementStats.CoyoteTime, Tolerance);
            Assert.AreEqual(_baseStats.HorizontalDamping, _movementStats.HorizontalDamping, Tolerance);
            Assert.AreEqual(_baseStats.GroundCheckLayers.value, _movementStats.GroundCheckLayers.value);
        }

        [Test]
        public void ChangeBaseStats_KeepsModifiersOnTheNewBase()
        {
            const float OtherBaseSpeed = 7f;
            var serializedOther = new UnityEditor.SerializedObject(_otherStats);
            serializedOther.FindProperty("<MaxMoveSpeed>k__BackingField").floatValue = OtherBaseSpeed;
            serializedOther.ApplyModifiedPropertiesWithoutUndo();
            Assume.That(_otherStats.MaxMoveSpeed, Is.Not.EqualTo(_baseStats.MaxMoveSpeed));
            _stack.Add(new StatModifier(ModifiableStat.MaxMoveSpeed, StatModifierKind.Add, 1f));

            _movementStats.ChangeBaseStats(_otherStats);

            Assert.AreEqual(OtherBaseSpeed + 1f, _movementStats.MaxMoveSpeed, Tolerance);
        }

        [Test]
        public void ChangeBaseStats_IgnoresNull()
        {
            _movementStats.ChangeBaseStats(null);

            Assert.AreEqual(_baseStats.MaxMoveSpeed, _movementStats.MaxMoveSpeed, Tolerance);
        }
    }
}
