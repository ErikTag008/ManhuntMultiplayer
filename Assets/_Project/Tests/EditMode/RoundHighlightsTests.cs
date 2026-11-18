using NUnit.Framework;
using Project.Assets._Project._Scripts.Managers;
using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;

namespace Project.Assets._Project.Tests.EditMode
{
    public class RoundHighlightsTests
    {
        private readonly List<PlayerSession> _leaders = new();

        private static PlayerSession Session(ulong clientId, int catches, float longestChaseInSeconds = 0f) =>
            new() { ClientId = clientId, Catches = catches, LongestChaseInSeconds = longestChaseInSeconds };

        [Test]
        public void PicksTheHighestValue()
        {
            var sessions = new List<PlayerSession> { Session(0, 1), Session(1, 3), Session(2, 2) };

            float bestValue = RoundHighlights.CopyLeaders(sessions, session => session.Catches, _leaders);

            Assert.AreEqual(3f, bestValue);
            Assert.AreEqual(1, _leaders.Count);
            Assert.AreEqual(1ul, _leaders[0].ClientId);
        }

        [Test]
        public void TiedPlayersShareIt()
        {
            var sessions = new List<PlayerSession> { Session(0, 2), Session(1, 1), Session(2, 2) };

            RoundHighlights.CopyLeaders(sessions, session => session.Catches, _leaders);

            Assert.AreEqual(2, _leaders.Count);
            Assert.AreEqual(0ul, _leaders[0].ClientId);
            Assert.AreEqual(2ul, _leaders[1].ClientId);
        }

        [Test]
        public void NobodyScored_LeavesItOut()
        {
            var sessions = new List<PlayerSession> { Session(0, 0), Session(1, 0) };

            float bestValue = RoundHighlights.CopyLeaders(sessions, session => session.Catches, _leaders);

            Assert.AreEqual(0f, bestValue);
            Assert.AreEqual(0, _leaders.Count);
        }

        [Test]
        public void LaterHigherValue_ReplacesEarlierLeaders()
        {
            var sessions = new List<PlayerSession> { Session(0, 0, 4f), Session(1, 0, 4f), Session(2, 0, 12.5f) };

            float bestValue = RoundHighlights.CopyLeaders(sessions, session => session.LongestChaseInSeconds, _leaders);

            Assert.AreEqual(12.5f, bestValue);
            Assert.AreEqual(1, _leaders.Count);
            Assert.AreEqual(2ul, _leaders[0].ClientId);
        }

        [Test]
        public void ClearsTheBufferFirst()
        {
            _leaders.Add(Session(9, 9));

            RoundHighlights.CopyLeaders(new List<PlayerSession>(), session => session.Catches, _leaders);

            Assert.AreEqual(0, _leaders.Count);
        }
    }
}
