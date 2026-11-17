using NUnit.Framework;
using Project.Assets._Project._Scripts.Networking;

namespace Project.Assets._Project.Tests.EditMode
{
    public class SteamLobbyIdTests
    {
        private const ulong LobbyId = 109775241234567890;

        [TestCase("109775241234567890")]
        [TestCase("  109775241234567890 ")]
        public void Decimal_Parses(string text)
        {
            Assert.IsTrue(SteamLobbyId.TryParse(text, out var lobbyId));
            Assert.AreEqual(LobbyId, lobbyId);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("0")]
        [TestCase("-5")]
        [TestCase("12ab")]
        [TestCase("127.0.0.1:7777")]
        [TestCase("99999999999999999999999")]
        public void Invalid_IsRejected(string text)
        {
            Assert.IsFalse(SteamLobbyId.TryParse(text, out _));
        }

        [Test]
        public void Format_RoundTrips()
        {
            Assert.IsTrue(SteamLobbyId.TryParse(SteamLobbyId.Format(LobbyId), out var lobbyId));
            Assert.AreEqual(LobbyId, lobbyId);
        }

        [Test]
        public void LaunchArgs_FindConnectLobby()
        {
            var args = new[] { "Game.exe", "-screen-fullscreen", "0", "+connect_lobby", "109775241234567890" };
            Assert.IsTrue(SteamLobbyId.TryFindInLaunchArgs(args, out var lobbyId));
            Assert.AreEqual(LobbyId, lobbyId);
        }

        [Test]
        public void LaunchArgs_WithoutConnectLobby_FindNothing()
        {
            Assert.IsFalse(SteamLobbyId.TryFindInLaunchArgs(new[] { "Game.exe", "-batchmode" }, out _));
            Assert.IsFalse(SteamLobbyId.TryFindInLaunchArgs(null, out _));
        }

        [Test]
        public void LaunchArgs_ConnectLobbyWithoutId_FindNothing()
        {
            Assert.IsFalse(SteamLobbyId.TryFindInLaunchArgs(new[] { "Game.exe", "+connect_lobby" }, out _));
            Assert.IsFalse(SteamLobbyId.TryFindInLaunchArgs(new[] { "Game.exe", "+connect_lobby", "abc" }, out _));
        }
    }
}
