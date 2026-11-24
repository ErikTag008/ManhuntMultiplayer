using NUnit.Framework;
using Project.Assets._Project._Scripts.Managers;
using Project.Assets._Project._Scripts.Networking;

namespace Project.Assets._Project.Tests.EditMode
{
    public class JoinAdmissionTests
    {
        private const int MaxPlayers = 4;

        [Test]
        public void OpenLobby_WithFreeSlot_LetsTheClientIn()
        {
            Assert.AreEqual(JoinRejection.None, JoinAdmission.Evaluate(false, false, true, MaxPlayers - 1, MaxPlayers));
        }

        [Test]
        public void OpenLobby_WithoutFreeSlot_IsFull()
        {
            Assert.AreEqual(JoinRejection.LobbyFull, JoinAdmission.Evaluate(false, false, true, MaxPlayers, MaxPlayers));
        }

        [Test]
        public void RoundRunning_RejectsEvenWithFreeSlots()
        {
            Assert.AreEqual(JoinRejection.RoundInProgress, JoinAdmission.Evaluate(false, false, false, 0, MaxPlayers));
        }

        [Test]
        public void RoundRunning_FullLobby_ReportsTheRound()
        {
            Assert.AreEqual(JoinRejection.RoundInProgress, JoinAdmission.Evaluate(false, false, false, MaxPlayers, MaxPlayers));
        }

        [Test]
        public void HostClient_AlwaysGetsIn()
        {
            Assert.AreEqual(JoinRejection.None, JoinAdmission.Evaluate(true, false, false, MaxPlayers, MaxPlayers));
        }

        [Test]
        public void KickedPlayer_IsTurnedAwayFromAnOpenLobby()
        {
            Assert.AreEqual(JoinRejection.Kicked, JoinAdmission.Evaluate(false, true, true, 0, MaxPlayers));
        }

        [Test]
        public void KickedPlayer_DuringARound_ReportsTheKick()
        {
            Assert.AreEqual(JoinRejection.Kicked, JoinAdmission.Evaluate(false, true, false, MaxPlayers, MaxPlayers));
        }

        [Test]
        public void HostClient_IsNeverKicked()
        {
            Assert.AreEqual(JoinRejection.None, JoinAdmission.Evaluate(true, true, true, 0, MaxPlayers));
        }

        [TestCase(GameState.Lobby, false)]
        [TestCase(GameState.WaitingForPlayers, false)]
        [TestCase(GameState.Countdown, false)]
        [TestCase(GameState.AssigningTeams, true)]
        [TestCase(GameState.LoadingGameplay, true)]
        [TestCase(GameState.WaitForRunnerHide, true)]
        [TestCase(GameState.Playing, true)]
        [TestCase(GameState.DeterminingWinner, true)]
        [TestCase(GameState.Results, true)]
        public void RoundProgress_MatchesTheGameState(GameState state, bool isInProgress)
        {
            Assert.AreEqual(isInProgress, RoundProgress.IsInProgress(state));
        }
    }
}
