using NUnit.Framework;
using Project.Assets._Project._Scripts.Player;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class RunnerStatsTests
    {
        private const float BaseValue = 10f;

        private RunnerStats _runnerStats;
        private StatModifierStack _stack;

        [SetUp]
        public void SetUp()
        {
            _runnerStats = ScriptableObject.CreateInstance<RunnerStats>();
            _stack = new StatModifierStack(() => 0f);
        }

        [TearDown]
        public void TearDown() => Object.DestroyImmediate(_runnerStats);

        [Test]
        public void BleedOutDuration_DefaultsToPositive()
        {
            Assert.Greater(_runnerStats.BleedOutDurationInSeconds, 0f);
        }

        [Test]
        public void RescueTuning_DefaultsToPositive()
        {
            Assert.Greater(_runnerStats.RescueDurationInSeconds, 0f);
            Assert.Greater(_runnerStats.RescueRange, 0f);
            Assert.Greater(_runnerStats.ReviveInvulnerabilityDurationInSeconds, 0f);
        }

        [Test]
        public void RescueDuration_IsShorterThanBleedOut()
        {
            Assert.Less(_runnerStats.RescueDurationInSeconds, _runnerStats.BleedOutDurationInSeconds);
        }

        [Test]
        public void KnockedModifiers_SlowMovementWithoutStoppingIt()
        {
            foreach (var modifier in _runnerStats.KnockedModifiers) _stack.Add(modifier);

            float crawlSpeed = _stack.Apply(ModifiableStat.MaxMoveSpeed, BaseValue);
            Assert.Greater(crawlSpeed, 0f);
            Assert.Less(crawlSpeed, BaseValue);
        }

        [Test]
        public void KnockedModifiers_DisableJumping()
        {
            foreach (var modifier in _runnerStats.KnockedModifiers) _stack.Add(modifier);

            Assert.AreEqual(0f, _stack.Apply(ModifiableStat.JumpForce, BaseValue));
        }

        [Test]
        public void KnockedModifiers_RemovedRestoreBaseStats()
        {
            foreach (var modifier in _runnerStats.KnockedModifiers) _stack.Add(modifier);
            foreach (var modifier in _runnerStats.KnockedModifiers) _stack.Remove(modifier);

            Assert.AreEqual(0, _stack.Count);
            Assert.AreEqual(BaseValue, _stack.Apply(ModifiableStat.MaxMoveSpeed, BaseValue));
        }
    }
}
