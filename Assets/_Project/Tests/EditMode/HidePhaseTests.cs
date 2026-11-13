using NUnit.Framework;
using Project.Assets._Project._Scripts.Player;

namespace Project.Assets._Project.Tests.EditMode
{
    public class HidePhaseTests
    {
        [Test]
        public void StartsInactive() => Assert.IsFalse(new HidePhase().IsActive);

        [Test]
        public void Toggle_RaisesOnlyOnChange()
        {
            var hidePhase = new HidePhase();
            int raisedCount = 0;
            bool lastValue = false;
            hidePhase.OnChanged += isActive =>
            {
                raisedCount++;
                lastValue = isActive;
            };

            hidePhase.Toggle(true);
            hidePhase.Toggle(true);
            Assert.AreEqual(1, raisedCount);
            Assert.IsTrue(lastValue);
            Assert.IsTrue(hidePhase.IsActive);

            hidePhase.Toggle(false);
            Assert.AreEqual(2, raisedCount);
            Assert.IsFalse(hidePhase.IsActive);
        }
    }
}
