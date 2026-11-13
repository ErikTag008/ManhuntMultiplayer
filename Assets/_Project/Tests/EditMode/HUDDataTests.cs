using NUnit.Framework;
using Project.Assets._Project._Scripts;
using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;

namespace Project.Assets._Project.Tests.EditMode
{
    public class HUDDataTests
    {
        private static PlayerSession Session(ulong clientId, Team team, LifeState lifeState) =>
            new() { ClientId = clientId, Team = team, LifeState = lifeState };

        [Test]
        public void RunnerCounts_CountsOnlyRunnersByLifeState()
        {
            var sessions = new List<PlayerSession>
            {
                Session(0, Team.Catcher, LifeState.Up),
                Session(1, Team.Runner, LifeState.Up),
                Session(2, Team.Runner, LifeState.Up),
                Session(3, Team.Runner, LifeState.Knocked),
                Session(4, Team.Runner, LifeState.Eliminated),
                Session(5, Team.None, LifeState.Up)
            };

            var counts = RunnerCounts.From(sessions);

            Assert.AreEqual(2, counts.Up);
            Assert.AreEqual(1, counts.Knocked);
            Assert.AreEqual(1, counts.Eliminated);
        }

        [Test]
        public void RunnerCounts_NoSessions_AllZero()
        {
            var counts = RunnerCounts.From(new List<PlayerSession>());
            Assert.AreEqual(0, counts.Up + counts.Knocked + counts.Eliminated);
        }

        [TestCase(25f, "0:25")]
        [TestCase(90f, "1:30")]
        [TestCase(4.2f, "0:05")]
        [TestCase(0f, "0:00")]
        [TestCase(-3f, "0:00")]
        [TestCase(600f, "10:00")]
        public void MinutesSeconds_FormatsAndRoundsUp(float seconds, string expected) =>
            Assert.AreEqual(expected, EUtils.Format.MinutesSeconds(seconds));
    }
}
