using NUnit.Framework;
using Project.Assets._Project._Scripts;
using Project.Assets._Project._Scripts.Player;
using Project.Assets._Project._Scripts.SceneFlow;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class MapBoundsTests
    {
        private static readonly Bounds Box = new(Vector3.zero, new Vector3(10f, 10f, 10f));

        [Test]
        public void Inside_ChangesNothing()
        {
            Vector3 velocity = new(3f, -2f, 1f);
            bool hasChanged = MapBounds.TryClamp(Box, Vector3.one, velocity, out Vector3 position, out Vector3 clampedVelocity);

            Assert.IsFalse(hasChanged);
            Assert.AreEqual(Vector3.one, position);
            Assert.AreEqual(velocity, clampedVelocity);
        }

        [Test]
        public void Outside_PulledBackToTheFace()
        {
            MapBounds.TryClamp(Box, new Vector3(8f, 0f, -9f), Vector3.zero, out Vector3 position, out _);
            Assert.AreEqual(new Vector3(5f, 0f, -5f), position);
        }

        [Test]
        public void OnFace_StopsOnlyTheOutwardSpeed()
        {
            bool hasChanged = MapBounds.TryClamp(Box, new Vector3(5f, 0f, 0f), new Vector3(4f, 2f, -3f), out _, out Vector3 velocity);

            Assert.IsTrue(hasChanged);
            Assert.AreEqual(new Vector3(0f, 2f, -3f), velocity);
        }

        [Test]
        public void OnFace_MovingInwardKeepsSpeed()
        {
            Vector3 inward = new(-4f, 0f, 0f);
            bool hasChanged = MapBounds.TryClamp(Box, new Vector3(5f, 0f, 0f), inward, out _, out Vector3 velocity);

            Assert.IsFalse(hasChanged);
            Assert.AreEqual(inward, velocity);
        }

        [Test]
        public void ShouldBeGhost_EliminatedClassicRunnerInHunt_True() =>
            Assert.IsTrue(PlayerGhost.ShouldBeGhost(Eliminated(Team.Runner), GameMode.Classic, false, true));

        [Test]
        public void ShouldBeGhost_EliminatedAfterHunt_StaysSpectator() =>
            Assert.IsFalse(PlayerGhost.ShouldBeGhost(Eliminated(Team.Runner), GameMode.Classic, false, false));

        [Test]
        public void ShouldBeGhost_AlreadyGhostAfterHunt_StaysGhost() =>
            Assert.IsTrue(PlayerGhost.ShouldBeGhost(Eliminated(Team.Runner), GameMode.Classic, true, false));

        [Test]
        public void ShouldBeGhost_InfectionOrCatcher_False()
        {
            Assert.IsFalse(PlayerGhost.ShouldBeGhost(Eliminated(Team.Runner), GameMode.Infection, false, true));
            Assert.IsFalse(PlayerGhost.ShouldBeGhost(Eliminated(Team.Catcher), GameMode.Classic, false, true));
        }

        [Test]
        public void ShouldBeGhost_SittingOutJoiner_TrueInEveryModeAndPhase()
        {
            Assert.IsTrue(PlayerGhost.ShouldBeGhost(Eliminated(Team.None), GameMode.Classic, false, false));
            Assert.IsTrue(PlayerGhost.ShouldBeGhost(Eliminated(Team.None), GameMode.Infection, false, true));
        }

        // the lobby reset sets Team.None and Up together, so nobody in the lobby counts as sitting out
        [Test]
        public void ShouldBeGhost_LobbyPlayer_False() =>
            Assert.IsFalse(PlayerGhost.ShouldBeGhost(new PlayerSession { Team = Team.None, LifeState = LifeState.Up }, GameMode.Classic, true, false));

        [Test]
        public void ShouldBeGhost_StandingRunnerInHunt_False() =>
            Assert.IsFalse(PlayerGhost.ShouldBeGhost(new PlayerSession { Team = Team.Runner, LifeState = LifeState.Up }, GameMode.Classic, false, true));

        private static PlayerSession Eliminated(Team team) => new() { Team = team, LifeState = LifeState.Eliminated };
    }
}
