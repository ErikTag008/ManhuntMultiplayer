using NUnit.Framework;
using Project.Assets._Project._Scripts.Player;
using Project.Assets._Project._Scripts.Player.Abilities;
using System;
using UnityEditor;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class AbilityTests
    {
        private DashAbilityData _dash;
        private DoubleJumpAbilityData _doubleJump;
        private AbilityCatalog _catalog;

        [SetUp]
        public void SetUp()
        {
            _dash = ScriptableObject.CreateInstance<DashAbilityData>();
            _doubleJump = ScriptableObject.CreateInstance<DoubleJumpAbilityData>();
            SetBackingField(_dash, "Id", 1);
            SetBackingField(_doubleJump, "Id", 2);

            _catalog = ScriptableObject.CreateInstance<AbilityCatalog>();
            _catalog.Abilities.Add(_dash);
            _catalog.Abilities.Add(_doubleJump);
            var serializedCatalog = new SerializedObject(_catalog);
            serializedCatalog.FindProperty("<DefaultAbility>k__BackingField").objectReferenceValue = _dash;
            serializedCatalog.ApplyModifiedPropertiesWithoutUndo();
        }

        [TearDown]
        public void TearDown()
        {
            UnityEngine.Object.DestroyImmediate(_catalog);
            UnityEngine.Object.DestroyImmediate(_dash);
            UnityEngine.Object.DestroyImmediate(_doubleJump);
        }

        [Test]
        public void Catalog_ResolvesPickById() => Assert.AreSame(_doubleJump, _catalog.Resolve(2));

        [Test]
        public void Catalog_NoPickOrUnknownId_FallsBackToDefault()
        {
            Assert.AreSame(_dash, _catalog.Resolve(PlayerSession.NoAbility));
            Assert.AreSame(_dash, _catalog.Resolve(99));
        }

        [Test]
        public void Cooldown_RemainingNeverNegative()
        {
            Assert.AreEqual(5f, AbilityCooldown.RemainingInSeconds(10.0, 15.0), 1e-4f);
            Assert.AreEqual(0f, AbilityCooldown.RemainingInSeconds(20.0, 15.0));
        }

        [Test]
        public void Cooldown_ServerAcceptsWithinToleranceOnly()
        {
            Assert.IsTrue(AbilityCooldown.IsAcceptedByServer(14.8, 15.0, 0.25f));
            Assert.IsFalse(AbilityCooldown.IsAcceptedByServer(14.0, 15.0, 0.25f));
            Assert.IsTrue(AbilityCooldown.IsAcceptedByServer(16.0, 15.0, 0f));
        }

        [Test]
        public void DoubleJump_OnTheGround_LeavesTheNormalJumpAlone()
        {
            var movement = new FakeMovement { CanGroundJump = true };

            Assert.IsFalse(_doubleJump.TryActivate(movement));
            Assert.AreEqual(0, movement.AirJumpCount);
        }

        [Test]
        public void DoubleJump_NextToAWall_LeavesTheWallJumpAlone()
        {
            var movement = new FakeMovement { CanGroundJump = false, CanKickOffWall = true };

            Assert.IsFalse(_doubleJump.TryActivate(movement));
            Assert.AreEqual(0, movement.AirJumpCount);
        }

        [Test]
        public void DoubleJump_InTheAir_JumpsAgain()
        {
            var movement = new FakeMovement { CanGroundJump = false };

            Assert.IsTrue(_doubleJump.TryActivate(movement));
            Assert.AreEqual(1, movement.AirJumpCount);
        }

        [Test]
        public void Dash_UsesItsSpeed()
        {
            SetBackingField(_dash, "DashSpeed", 30f);
            SetBackingField(_dash, "DashDurationInSeconds", 0.4f);
            var movement = new FakeMovement();

            Assert.IsTrue(_dash.TryActivate(movement));
            Assert.AreEqual(30f, movement.LastDashSpeed);
            Assert.AreEqual(0.4f, movement.LastDashDuration);
        }

        // The ability hears the jump press before movement does; the same press must not also be buffered as a landing jump
        [Test]
        public void AirJump_SamePressReachingMovement_IsNotBufferedAgain()
        {
            var body = new GameObject("AirJumpBufferTest");
            var stats = ScriptableObject.CreateInstance<PlayerStats>();
            try
            {
                var movement = new PlayerMovement(body.AddComponent<Rigidbody>(), stats, null, null, null, null, null);
                var lastJumpPressedTime = typeof(PlayerMovement).GetField("_lastJumpPressedTime", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

                movement.AirJump(1f);
                movement.HandleJump(true);

                Assert.AreEqual(float.NegativeInfinity, (float)lastJumpPressedTime.GetValue(movement));
            }
            finally
            {
                UnityEngine.Object.DestroyImmediate(body);
                UnityEngine.Object.DestroyImmediate(stats);
            }
        }

        private static void SetBackingField(UnityEngine.Object target, string property, object value)
        {
            var serialized = new SerializedObject(target);
            var field = serialized.FindProperty($"<{property}>k__BackingField");
            if (value is int intValue) field.intValue = intValue;
            else field.floatValue = (float)value;
            serialized.ApplyModifiedPropertiesWithoutUndo();
        }

        private class FakeMovement : IPlayerMovement
        {
            public bool CanGroundJump;
            public bool CanKickOffWall;
            public int AirJumpCount;
            public float LastDashSpeed;
            public float LastDashDuration;

            public event Action<float> ModelRotationChanged { add { } remove { } }
            public event Action<Quaternion> CameraFollowerRotationChanged { add { } remove { } }

            public bool CanJumpFromGround() => CanGroundJump;
            public bool CanWallJump() => CanKickOffWall;
            public void ToggleParkour(bool isEnabled) { }
            public void ToggleCrouchHeld(bool isHeld) { }
            public void AirJump(float jumpForceMultiplier) => AirJumpCount++;
            public void Dash(float speed, float durationInSeconds)
            {
                LastDashSpeed = speed;
                LastDashDuration = durationInSeconds;
            }
            public void ToggleMovement(bool isEnabled) { }
            public void HandleJump(bool isButtonDown = true) { }
            public void HandleFixedMovement(Vector2 moveDirection) { }
            public void HandleRotation() { }
            public bool IsGrounded() => CanGroundJump;
            public void DrawGizmos() { }
            public void ChangeCamera(Camera camera) { }
            public void ChangeStats(IMovementStats stats) { }
            public void ChangeModel(Transform model) { }
            public void ChangeCameraFollower(Transform cameraFollower) { }
        }
    }
}
