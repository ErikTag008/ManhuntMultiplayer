using NUnit.Framework;
using Project.Assets._Project._Scripts.Managers;
using System.Collections.Generic;

namespace Project.Assets._Project.Tests.EditMode
{
    public class MapReadyTrackerTests
    {
        private MapReadyTracker _tracker;
        private readonly List<ulong> _missing = new();

        [SetUp]
        public void SetUp()
        {
            _tracker = new MapReadyTracker();
            _tracker.Expect(1);
            _tracker.Expect(2);
        }

        [Test]
        public void AllReady_Complete()
        {
            _tracker.TryReport(1, MapLoadResult.Ready);
            _tracker.TryReport(2, MapLoadResult.Ready);
            _tracker.CopyMissing(_missing);

            Assert.IsTrue(_tracker.IsComplete);
            Assert.IsEmpty(_missing);
        }

        [Test]
        public void Failure_CountsAsAnswer()
        {
            _tracker.TryReport(1, MapLoadResult.Ready);
            _tracker.TryReport(2, MapLoadResult.Missing);

            Assert.IsTrue(_tracker.IsComplete);
            Assert.IsTrue(_tracker.TryGetResult(2, out var result));
            Assert.AreEqual(MapLoadResult.Missing, result);
        }

        [Test]
        public void NotReported_ListedAsMissing()
        {
            _tracker.Expect(3);
            _tracker.TryReport(1, MapLoadResult.Ready);
            _tracker.CopyMissing(_missing);

            Assert.IsFalse(_tracker.IsComplete);
            CollectionAssert.AreEquivalent(new ulong[] { 2, 3 }, _missing);
        }

        [Test]
        public void DuplicateReport_Ignored()
        {
            Assert.IsTrue(_tracker.TryReport(1, MapLoadResult.Ready));
            Assert.IsFalse(_tracker.TryReport(1, MapLoadResult.Failed));
            _tracker.TryGetResult(1, out var result);

            Assert.AreEqual(MapLoadResult.Ready, result);
        }

        [Test]
        public void UnknownClient_KeptButDoesNotComplete()
        {
            Assert.IsTrue(_tracker.TryReport(9, MapLoadResult.Ready));
            _tracker.TryReport(1, MapLoadResult.Ready);
            _tracker.CopyMissing(_missing);

            Assert.IsFalse(_tracker.IsComplete);
            CollectionAssert.AreEquivalent(new ulong[] { 2 }, _missing);
            Assert.IsTrue(_tracker.TryGetResult(9, out _));
        }

        [Test]
        public void ClientLeft_NoLongerWaitedFor()
        {
            _tracker.TryReport(1, MapLoadResult.Ready);
            _tracker.Forget(2);

            Assert.IsTrue(_tracker.IsComplete);
        }

        [Test]
        public void NothingExpected_Complete() => Assert.IsTrue(new MapReadyTracker().IsComplete);
    }
}
