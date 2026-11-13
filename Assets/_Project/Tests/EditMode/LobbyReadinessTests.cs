using NUnit.Framework;
using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;

namespace Project.Assets._Project.Tests.EditMode
{
    public class LobbyReadinessTests
    {
        private const int MinRequiredPlayers = 3;

        private static PlayerSession Session(ulong clientId, bool isReady) => new() { ClientId = clientId, IsReady = isReady };

        [Test]
        public void EveryoneReady_EnoughPlayers_CanStart()
        {
            var sessions = new List<PlayerSession> { Session(0, true), Session(1, true), Session(2, true) };
            Assert.IsTrue(LobbyReadiness.CanStart(sessions, MinRequiredPlayers));
        }

        [Test]
        public void OneNotReady_CannotStart()
        {
            var sessions = new List<PlayerSession> { Session(0, true), Session(1, false), Session(2, true) };

            Assert.IsFalse(LobbyReadiness.CanStart(sessions, MinRequiredPlayers));
            Assert.AreEqual(2, LobbyReadiness.CountReady(sessions));
        }

        [Test]
        public void EveryoneReady_TooFewPlayers_CannotStart()
        {
            var sessions = new List<PlayerSession> { Session(0, true), Session(1, true) };
            Assert.IsFalse(LobbyReadiness.CanStart(sessions, MinRequiredPlayers));
        }

        [Test]
        public void NoPlayers_CannotStart() =>
            Assert.IsFalse(LobbyReadiness.CanStart(new List<PlayerSession>(), MinRequiredPlayers));
    }
}
