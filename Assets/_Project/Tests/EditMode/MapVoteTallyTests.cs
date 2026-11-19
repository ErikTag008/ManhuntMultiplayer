using NUnit.Framework;
using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;

namespace Project.Assets._Project.Tests.EditMode
{
    public class MapVoteTallyTests
    {
        private const int MapCount = 3;
        private const int HostMapIndex = 2;

        private readonly List<int> _tiedMapBuffer = new();

        private static PlayerSession Session(ulong clientId, int mapVote) => new() { ClientId = clientId, MapVote = mapVote };

        private int Pick(List<PlayerSession> sessions, int pickedTieSlot = 0) =>
            MapVoteTally.PickMap(sessions, MapCount, HostMapIndex, _ => pickedTieSlot, _tiedMapBuffer);

        [Test]
        public void MostVotes_Wins()
        {
            var sessions = new List<PlayerSession> { Session(0, 1), Session(1, 1), Session(2, 0) };

            Assert.AreEqual(1, Pick(sessions));
            Assert.AreEqual(2, MapVoteTally.CountVotes(sessions, 1));
        }

        [Test]
        public void NoVotes_KeepsHostMap()
        {
            var sessions = new List<PlayerSession> { Session(0, PlayerSession.NoMapVote), Session(1, PlayerSession.NoMapVote) };
            Assert.AreEqual(HostMapIndex, Pick(sessions));
        }

        [Test]
        public void NoPlayers_KeepsHostMap() => Assert.AreEqual(HostMapIndex, Pick(new List<PlayerSession>()));

        [Test]
        public void Tie_PicksAmongTiedMapsOnly()
        {
            var sessions = new List<PlayerSession> { Session(0, 0), Session(1, 2), Session(2, PlayerSession.NoMapVote) };

            Assert.AreEqual(0, Pick(sessions, 0));
            Assert.AreEqual(2, Pick(sessions, 1));
            CollectionAssert.AreEqual(new[] { 0, 2 }, _tiedMapBuffer);
        }

        [Test]
        public void OutOfRangeVotes_AreIgnored()
        {
            var sessions = new List<PlayerSession> { Session(0, MapCount), Session(1, MapCount), Session(2, 0) };
            Assert.AreEqual(0, Pick(sessions));
        }

        [Test]
        public void PickerOutOfRange_IsClamped()
        {
            var sessions = new List<PlayerSession> { Session(0, 0), Session(1, 1) };
            Assert.AreEqual(1, Pick(sessions, MapCount));
        }
    }
}
