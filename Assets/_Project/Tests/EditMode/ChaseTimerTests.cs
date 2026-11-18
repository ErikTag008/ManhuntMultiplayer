using NUnit.Framework;
using Project.Assets._Project._Scripts.Managers;

namespace Project.Assets._Project.Tests.EditMode
{
    public class ChaseTimerTests
    {
        private const float LostAfterSeconds = 3f;

        [Test]
        public void ContactStartsAChase()
        {
            var timer = new ChaseTimer();

            bool hasEnded = timer.Update(true, 10.0, LostAfterSeconds, out _);

            Assert.IsFalse(hasEnded);
            Assert.IsTrue(timer.IsActive);
        }

        [Test]
        public void ShortGap_KeepsTheChaseGoing()
        {
            var timer = new ChaseTimer();
            timer.Update(true, 10.0, LostAfterSeconds, out _);

            bool hasEnded = timer.Update(false, 12.0, LostAfterSeconds, out _);

            Assert.IsFalse(hasEnded);
            Assert.IsTrue(timer.IsActive);
        }

        [Test]
        public void LostContact_EndsWithTimeUpToLastContact()
        {
            var timer = new ChaseTimer();
            timer.Update(true, 10.0, LostAfterSeconds, out _);
            timer.Update(true, 18.0, LostAfterSeconds, out _);

            bool hasEnded = timer.Update(false, 21.0, LostAfterSeconds, out float durationInSeconds);

            Assert.IsTrue(hasEnded);
            Assert.AreEqual(8f, durationInSeconds, 0.001f);
            Assert.IsFalse(timer.IsActive);
        }

        [Test]
        public void NoContact_NeverEnds()
        {
            var timer = new ChaseTimer();

            bool hasEnded = timer.Update(false, 50.0, LostAfterSeconds, out _);

            Assert.IsFalse(hasEnded);
        }

        [Test]
        public void TryEnd_EndsARunningChase()
        {
            var timer = new ChaseTimer();
            timer.Update(true, 5.0, LostAfterSeconds, out _);
            timer.Update(true, 9.5, LostAfterSeconds, out _);

            bool hasEnded = timer.TryEnd(out float durationInSeconds);

            Assert.IsTrue(hasEnded);
            Assert.AreEqual(4.5f, durationInSeconds, 0.001f);
            Assert.IsFalse(timer.TryEnd(out _));
        }

        [Test]
        public void ContactAfterAnEndedChase_StartsANewOne()
        {
            var timer = new ChaseTimer();
            timer.Update(true, 0.0, LostAfterSeconds, out _);
            timer.Update(false, 10.0, LostAfterSeconds, out _);
            timer.Update(true, 20.0, LostAfterSeconds, out _);

            timer.TryEnd(out float durationInSeconds);

            Assert.AreEqual(0f, durationInSeconds, 0.001f);
        }
    }
}
