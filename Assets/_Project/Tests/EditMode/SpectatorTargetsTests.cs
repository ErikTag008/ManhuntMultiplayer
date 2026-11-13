using NUnit.Framework;
using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;

namespace Project.Assets._Project.Tests.EditMode
{
    public class SpectatorTargetsTests
    {
        private static readonly List<ulong> Ids = new() { 1, 3, 5 };

        private static ulong Pick(IReadOnlyList<ulong> ids, ulong? currentId, bool isForward)
        {
            Assert.IsTrue(SpectatorTargets.TryPick(ids, currentId, isForward, out ulong id));
            return id;
        }

        [Test]
        public void NoCandidates_PicksNothing() =>
            Assert.IsFalse(SpectatorTargets.TryPick(new List<ulong>(), 1, true, out _));

        [Test]
        public void NoCurrent_ForwardPicksFirst_BackwardPicksLast()
        {
            Assert.AreEqual(1, Pick(Ids, null, true));
            Assert.AreEqual(5, Pick(Ids, null, false));
        }

        [Test]
        public void ListedCurrent_StepsToNeighbour()
        {
            Assert.AreEqual(5, Pick(Ids, 3, true));
            Assert.AreEqual(1, Pick(Ids, 3, false));
        }

        [Test]
        public void ListedCurrent_WrapsAtEnds()
        {
            Assert.AreEqual(1, Pick(Ids, 5, true));
            Assert.AreEqual(5, Pick(Ids, 1, false));
        }

        [Test]
        public void UnlistedCurrent_StepsFromItsSortedPlace()
        {
            Assert.AreEqual(3, Pick(Ids, 2, true));
            Assert.AreEqual(1, Pick(Ids, 2, false));
            Assert.AreEqual(1, Pick(Ids, 6, true));
            Assert.AreEqual(5, Pick(Ids, 0, false));
        }

        [Test]
        public void SingleCandidate_IsAlwaysPicked()
        {
            var ids = new List<ulong> { 4 };
            Assert.AreEqual(4, Pick(ids, 4, true));
            Assert.AreEqual(4, Pick(ids, 7, false));
        }
    }
}
