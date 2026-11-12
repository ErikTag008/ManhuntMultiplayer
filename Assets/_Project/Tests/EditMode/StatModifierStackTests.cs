using NUnit.Framework;
using Project.Assets._Project._Scripts.Player;

namespace Project.Assets._Project.Tests.EditMode
{
    public class StatModifierStackTests
    {
        private const float BaseSpeed = 10f;
        private const float Tolerance = 0.0001f;

        private float _now;
        private StatModifierStack _stack;

        [SetUp]
        public void SetUp()
        {
            _now = 0f;
            _stack = new StatModifierStack(() => _now);
        }

        [Test]
        public void Apply_WithoutModifiers_ReturnsBaseValue()
        {
            Assert.AreEqual(BaseSpeed, _stack.Apply(ModifiableStat.MaxMoveSpeed, BaseSpeed), Tolerance);
        }

        [Test]
        public void Apply_AddsBeforeMultiplying()
        {
            _stack.Add(new StatModifier(ModifiableStat.MaxMoveSpeed, StatModifierKind.Multiply, 0.5f));
            _stack.Add(new StatModifier(ModifiableStat.MaxMoveSpeed, StatModifierKind.Add, 2f));

            Assert.AreEqual((BaseSpeed + 2f) * 0.5f, _stack.Apply(ModifiableStat.MaxMoveSpeed, BaseSpeed), Tolerance);
        }

        [Test]
        public void Apply_MultipliesStackedMultipliers()
        {
            _stack.Add(new StatModifier(ModifiableStat.MaxMoveSpeed, StatModifierKind.Multiply, 0.5f));
            _stack.Add(new StatModifier(ModifiableStat.MaxMoveSpeed, StatModifierKind.Multiply, 1.5f));

            Assert.AreEqual(BaseSpeed * 0.75f, _stack.Apply(ModifiableStat.MaxMoveSpeed, BaseSpeed), Tolerance);
        }

        [Test]
        public void Apply_IgnoresModifiersForOtherStats()
        {
            _stack.Add(new StatModifier(ModifiableStat.JumpForce, StatModifierKind.Multiply, 2f));

            Assert.AreEqual(BaseSpeed, _stack.Apply(ModifiableStat.MaxMoveSpeed, BaseSpeed), Tolerance);
        }

        [Test]
        public void Apply_NeverReturnsBelowZero()
        {
            _stack.Add(new StatModifier(ModifiableStat.MaxMoveSpeed, StatModifierKind.Add, -2f * BaseSpeed));

            Assert.AreEqual(0f, _stack.Apply(ModifiableStat.MaxMoveSpeed, BaseSpeed), Tolerance);
        }

        [Test]
        public void TimedModifier_StopsApplyingWhenExpired()
        {
            _stack.Add(new StatModifier(ModifiableStat.MaxMoveSpeed, StatModifierKind.Multiply, 2f), 5f);

            _now = 4.9f;
            Assert.AreEqual(BaseSpeed * 2f, _stack.Apply(ModifiableStat.MaxMoveSpeed, BaseSpeed), Tolerance);

            _now = 5f;
            Assert.AreEqual(BaseSpeed, _stack.Apply(ModifiableStat.MaxMoveSpeed, BaseSpeed), Tolerance);
        }

        [Test]
        public void ExpiredModifiers_ArePrunedOnNextAdd()
        {
            _stack.Add(new StatModifier(ModifiableStat.MaxMoveSpeed, StatModifierKind.Multiply, 2f), 1f);
            _now = 2f;

            _stack.Add(new StatModifier(ModifiableStat.JumpForce, StatModifierKind.Multiply, 2f));

            Assert.AreEqual(1, _stack.Count);
        }

        [Test]
        public void Remove_RemovesOneEntryOfTheSameModifier()
        {
            var slow = new StatModifier(ModifiableStat.MaxMoveSpeed, StatModifierKind.Multiply, 0.5f);
            _stack.Add(slow);
            _stack.Add(slow);

            Assert.IsTrue(_stack.Remove(slow));
            Assert.AreEqual(BaseSpeed * 0.5f, _stack.Apply(ModifiableStat.MaxMoveSpeed, BaseSpeed), Tolerance);
        }

        [Test]
        public void Remove_UnknownModifier_ReturnsFalse()
        {
            Assert.IsFalse(_stack.Remove(new StatModifier(ModifiableStat.MaxMoveSpeed, StatModifierKind.Add, 1f)));
        }

        [Test]
        public void Clear_RemovesEverything()
        {
            _stack.Add(new StatModifier(ModifiableStat.MaxMoveSpeed, StatModifierKind.Multiply, 2f));
            _stack.Clear();

            Assert.AreEqual(0, _stack.Count);
            Assert.AreEqual(BaseSpeed, _stack.Apply(ModifiableStat.MaxMoveSpeed, BaseSpeed), Tolerance);
        }
    }
}
