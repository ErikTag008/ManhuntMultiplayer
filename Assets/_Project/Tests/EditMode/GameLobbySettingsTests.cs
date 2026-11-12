using NUnit.Framework;
using Project.Assets._Project._Scripts.Managers;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class GameLobbySettingsTests
    {
        private GameLobbySettings _settings;

        [SetUp]
        public void SetUp() => _settings = ScriptableObject.CreateInstance<GameLobbySettings>();

        [TearDown]
        public void TearDown() => Object.DestroyImmediate(_settings);

        [TestCase(2, 1)]
        [TestCase(4, 1)]
        [TestCase(6, 1)]
        [TestCase(7, 2)]
        [TestCase(10, 2)]
        public void CatcherCount_FollowsPlayerCount(int playerCount, int expectedCatchers)
        {
            Assert.AreEqual(expectedCatchers, _settings.GetCatcherCount(playerCount));
        }

        [TestCase(0)]
        [TestCase(1)]
        public void CatcherCount_IsZeroWithoutRoomForARunner(int playerCount)
        {
            Assert.AreEqual(0, _settings.GetCatcherCount(playerCount));
        }

        [Test]
        public void CatcherCount_NeverExceedsMax()
        {
            Assert.LessOrEqual(_settings.GetCatcherCount(_settings.MaxConnectedPlayers * 10), _settings.MaxCatcherPlayers);
        }
    }
}
