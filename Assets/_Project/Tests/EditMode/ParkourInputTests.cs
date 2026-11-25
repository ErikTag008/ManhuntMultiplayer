using NUnit.Framework;
using Project.Assets._Project._Scripts.Player;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class ParkourInputTests
    {
        // the wall is to the east, so its normal points west, back at the player
        private static readonly Vector3 WallNormal = Vector3.left;

        private ParkourSettings _settings;

        [SetUp]
        public void SetUp() => _settings = new ParkourSettings();

        [Test]
        public void Mantle_JumpPressed_ClimbsWithoutForwardInput()
        {
            Assert.IsTrue(ParkourInput.AllowsMantle(Vector2.zero, true, _settings));
        }

        [Test]
        public void Mantle_NoPress_NeedsForwardInput()
        {
            Assert.IsFalse(ParkourInput.AllowsMantle(Vector2.zero, false, _settings));
            Assert.IsTrue(ParkourInput.AllowsMantle(Vector2.up, false, _settings));
        }

        [Test]
        public void WallJump_PushingIntoTheWall_IsBlocked()
        {
            Assert.IsFalse(ParkourInput.AllowsWallJump(Vector3.right, WallNormal, _settings));
        }

        [Test]
        public void WallJump_NoInputAlongOrAway_IsAllowed()
        {
            Assert.IsTrue(ParkourInput.AllowsWallJump(Vector3.zero, WallNormal, _settings));
            Assert.IsTrue(ParkourInput.AllowsWallJump(Vector3.forward, WallNormal, _settings));
            Assert.IsTrue(ParkourInput.AllowsWallJump(Vector3.left, WallNormal, _settings));
        }

        [Test]
        public void WallJump_DiagonalIntoTheWall_IsBlocked()
        {
            Vector3 diagonal = (Vector3.right + Vector3.forward).normalized;
            Assert.IsFalse(ParkourInput.AllowsWallJump(diagonal, WallNormal, _settings));
        }

        [Test]
        public void MantleKickOff_OnlyWhenHoldingBack()
        {
            Assert.IsTrue(ParkourInput.AllowsMantleKickOff(Vector2.down, _settings));
            Assert.IsFalse(ParkourInput.AllowsMantleKickOff(Vector2.zero, _settings));
            Assert.IsFalse(ParkourInput.AllowsMantleKickOff(Vector2.up, _settings));
            Assert.IsFalse(ParkourInput.AllowsMantleKickOff(Vector2.right, _settings));
        }
    }
}
