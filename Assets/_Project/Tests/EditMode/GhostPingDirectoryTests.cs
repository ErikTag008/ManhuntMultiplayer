using NUnit.Framework;
using Project.Assets._Project._Scripts.Player;

namespace Project.Assets._Project.Tests.EditMode
{
    public class GhostPingDirectoryTests
    {
        [Test]
        public void IsPinged_BeforeExpiry_TrueAndAfter_False()
        {
            var pings = new GhostPingDirectory(new HuntPhase());
            pings.Add(3, 10f);

            Assert.IsTrue(pings.IsPinged(3, 9f));
            Assert.IsFalse(pings.IsPinged(3, 10f));
            Assert.IsFalse(pings.IsPinged(4, 9f));
        }

        [Test]
        public void Add_SameCatcherAgain_RestartsExpiryWithoutDuplicate()
        {
            var pings = new GhostPingDirectory(new HuntPhase());
            pings.Add(3, 10f);
            pings.Add(3, 20f);

            Assert.AreEqual(1, pings.CatcherIds.Count);
            Assert.IsTrue(pings.IsPinged(3, 15f));
        }

        [Test]
        public void RemoveExpired_KeepsOnlyActivePings()
        {
            var pings = new GhostPingDirectory(new HuntPhase());
            pings.Add(1, 5f);
            pings.Add(2, 15f);

            pings.RemoveExpired(10f);

            Assert.AreEqual(1, pings.CatcherIds.Count);
            Assert.AreEqual(2ul, pings.CatcherIds[0]);
        }

        [Test]
        public void HuntPhaseChange_ClearsPings()
        {
            var huntPhase = new HuntPhase();
            var pings = new GhostPingDirectory(huntPhase);
            huntPhase.Toggle(true);
            pings.Add(1, 5f);

            huntPhase.Toggle(false);

            Assert.AreEqual(0, pings.CatcherIds.Count);
        }
    }
}
