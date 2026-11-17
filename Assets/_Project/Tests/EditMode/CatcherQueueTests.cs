using NUnit.Framework;
using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;

namespace Project.Assets._Project.Tests.EditMode
{
    public class CatcherQueueTests
    {
        private readonly List<PlayerSession> _result = new();

        private static PlayerSession Session(ulong clientId, int queueOrder) => new() { ClientId = clientId, CatcherQueueOrder = queueOrder };

        [Test]
        public void PicksLowestQueueOrderFirst()
        {
            var sessions = new List<PlayerSession> { Session(0, 4), Session(1, 2), Session(2, 3) };

            CatcherQueue.CopyNextCatchers(sessions, 1, _result);

            Assert.AreEqual(1, _result.Count);
            Assert.AreEqual(1ul, _result[0].ClientId);
        }

        [Test]
        public void PicksSeveralInQueueOrder()
        {
            var sessions = new List<PlayerSession> { Session(0, 9), Session(1, 5), Session(2, 1), Session(3, 7) };

            CatcherQueue.CopyNextCatchers(sessions, 2, _result);

            Assert.AreEqual(2, _result.Count);
            Assert.AreEqual(2ul, _result[0].ClientId);
            Assert.AreEqual(1ul, _result[1].ClientId);
        }

        [Test]
        public void SameOrder_ClientIdBreaksTie()
        {
            var sessions = new List<PlayerSession> { Session(5, 1), Session(3, 1) };

            CatcherQueue.CopyNextCatchers(sessions, 1, _result);

            Assert.AreEqual(3ul, _result[0].ClientId);
        }

        [Test]
        public void ZeroCatchers_EmptyResult()
        {
            var sessions = new List<PlayerSession> { Session(0, 1) };
            _result.Add(Session(9, 9));

            CatcherQueue.CopyNextCatchers(sessions, 0, _result);

            Assert.AreEqual(0, _result.Count);
        }

        [Test]
        public void MoreCatchersThanPlayers_ReturnsEveryone()
        {
            var sessions = new List<PlayerSession> { Session(0, 2), Session(1, 1) };

            CatcherQueue.CopyNextCatchers(sessions, 5, _result);

            Assert.AreEqual(2, _result.Count);
        }

        [Test]
        public void RotationOverRounds_EveryoneTakesATurn()
        {
            var sessions = new List<PlayerSession> { Session(0, 1), Session(1, 2), Session(2, 3) };
            int lastOrder = 3;
            var picked = new List<ulong>();

            for (int round = 0; round < sessions.Count; round++)
            {
                CatcherQueue.CopyNextCatchers(sessions, 1, _result);
                ulong catcherId = _result[0].ClientId;
                picked.Add(catcherId);

                int index = sessions.FindIndex(s => s.ClientId == catcherId);
                var session = sessions[index];
                session.CatcherQueueOrder = ++lastOrder;
                sessions[index] = session;
            }

            CollectionAssert.AreEqual(new List<ulong> { 0, 1, 2 }, picked);
        }
    }
}
