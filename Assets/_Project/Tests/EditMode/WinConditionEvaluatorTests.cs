using NUnit.Framework;
using Project.Assets._Project._Scripts.Managers;
using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;

namespace Project.Assets._Project.Tests.EditMode
{
    public class WinConditionEvaluatorTests
    {
        private readonly WinConditionEvaluator _evaluator = new();

        private static PlayerSession Session(ulong clientId, Team team, LifeState lifeState) =>
            new() { ClientId = clientId, Team = team, LifeState = lifeState };

        [Test]
        public void RunnerStanding_BeforeTimeUp_RoundContinues()
        {
            var sessions = new List<PlayerSession>
            {
                Session(0, Team.Catcher, LifeState.Up),
                Session(1, Team.Runner, LifeState.Up),
                Session(2, Team.Runner, LifeState.Knocked)
            };

            Assert.AreEqual(RoundResult.None, _evaluator.Evaluate(sessions, false));
        }

        [Test]
        public void RunnerStanding_WhenTimeUp_RunnersWin()
        {
            var sessions = new List<PlayerSession>
            {
                Session(0, Team.Catcher, LifeState.Up),
                Session(1, Team.Runner, LifeState.Up)
            };

            Assert.AreEqual(RoundResult.RunnersWin, _evaluator.Evaluate(sessions, true));
        }

        [Test]
        public void NoRunnerStanding_CatchersWinBeforeTimeUp()
        {
            var sessions = new List<PlayerSession>
            {
                Session(0, Team.Catcher, LifeState.Up),
                Session(1, Team.Runner, LifeState.Knocked),
                Session(2, Team.Runner, LifeState.Eliminated)
            };

            Assert.AreEqual(RoundResult.CatchersWin, _evaluator.Evaluate(sessions, false));
        }

        [Test]
        public void NoRunnerStanding_WhenTimeUp_CatchersStillWin()
        {
            var sessions = new List<PlayerSession>
            {
                Session(0, Team.Catcher, LifeState.Up),
                Session(1, Team.Runner, LifeState.Knocked)
            };

            Assert.AreEqual(RoundResult.CatchersWin, _evaluator.Evaluate(sessions, true));
        }

        [Test]
        public void AllRunnersLeft_CatchersWin()
        {
            var sessions = new List<PlayerSession> { Session(0, Team.Catcher, LifeState.Up) };

            Assert.AreEqual(RoundResult.CatchersWin, _evaluator.Evaluate(sessions, false));
        }

        [Test]
        public void AllCatchersLeft_RunnersWin()
        {
            var sessions = new List<PlayerSession> { Session(1, Team.Runner, LifeState.Up) };

            Assert.AreEqual(RoundResult.RunnersWin, _evaluator.Evaluate(sessions, false));
        }

        [Test]
        public void PlayersWithoutTeam_AreIgnored()
        {
            var sessions = new List<PlayerSession>
            {
                Session(0, Team.Catcher, LifeState.Up),
                Session(1, Team.Runner, LifeState.Up),
                Session(2, Team.None, LifeState.Knocked)
            };

            Assert.AreEqual(RoundResult.None, _evaluator.Evaluate(sessions, false));
        }
    }
}
