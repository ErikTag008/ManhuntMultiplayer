using NUnit.Framework;
using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class ParkourProbeTests
    {
        private const float BodyRadius = 0.5f;
        private const float StandingHeight = 2f;
        private const float MaxGroundAngle = 30f;
        // far from anything an open scene might hold
        private static readonly Vector3 Origin = new(5000f, 5000f, 5000f);

        private readonly List<GameObject> _created = new();
        private ParkourSettings _settings;
        private LayerMask _layers;

        [SetUp]
        public void SetUp()
        {
            _settings = new ParkourSettings();
            _layers = LayerMask.GetMask("Default");
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var created in _created) Object.DestroyImmediate(created);
            _created.Clear();
        }

        [Test]
        public void Wall_TouchingTheSide_IsFoundWithANormalPointingAway()
        {
            // a wall face 0.6 m east of the feet: inside the 0.5 body + 0.35 check distance
            CreateBox(Origin + new Vector3(1.6f, 1f, 0f), new Vector3(2f, 4f, 4f));

            Assert.IsTrue(ParkourProbe.TryFindWall(Origin, BodyRadius, _settings, _layers, out Vector3 normal));
            Assert.Greater(Vector3.Dot(normal, Vector3.left), 0.99f);
        }

        [Test]
        public void Wall_OutOfReach_IsNotFound()
        {
            CreateBox(Origin + new Vector3(3f, 1f, 0f), new Vector3(2f, 4f, 4f));

            Assert.IsFalse(ParkourProbe.TryFindWall(Origin, BodyRadius, _settings, _layers, out _));
        }

        [Test]
        public void Ledge_AtChestHeight_GivesALandingOnTop()
        {
            // a 1.5 m high block whose face is 0.7 m ahead
            CreateBox(Origin + new Vector3(0f, 0.75f, 2.7f), new Vector3(4f, 1.5f, 4f));

            Assert.IsTrue(ParkourProbe.TryFindLedge(Origin, Vector3.forward, BodyRadius, StandingHeight, MaxGroundAngle, _settings, _layers, out Vector3 landing));
            Assert.AreEqual(Origin.y + 1.5f + _settings.SurfaceClearance, landing.y, 0.01f);
            Assert.Greater(landing.z, Origin.z + 0.7f);
        }

        [Test]
        public void Ledge_TooHigh_IsNotClimbable()
        {
            CreateBox(Origin + new Vector3(0f, 2f, 2.7f), new Vector3(4f, 4f, 4f));

            Assert.IsFalse(ParkourProbe.TryFindLedge(Origin, Vector3.forward, BodyRadius, StandingHeight, MaxGroundAngle, _settings, _layers, out _));
        }

        [Test]
        public void Ledge_BelowStepHeight_IsNotClimbable()
        {
            CreateBox(Origin + new Vector3(0f, 0.25f, 2.7f), new Vector3(4f, 0.5f, 4f));

            Assert.IsFalse(ParkourProbe.TryFindLedge(Origin, Vector3.forward, BodyRadius, StandingHeight, MaxGroundAngle, _settings, _layers, out _));
        }

        [Test]
        public void Ledge_UnderALowCeiling_IsNotClimbable()
        {
            CreateBox(Origin + new Vector3(0f, 0.75f, 2.7f), new Vector3(4f, 1.5f, 4f));
            // a slab 1 m above the ledge top leaves no room to stand
            CreateBox(Origin + new Vector3(0f, 2.75f, 2.7f), new Vector3(4f, 0.5f, 4f));

            Assert.IsFalse(ParkourProbe.TryFindLedge(Origin, Vector3.forward, BodyRadius, StandingHeight, MaxGroundAngle, _settings, _layers, out _));
        }

        private void CreateBox(Vector3 center, Vector3 size)
        {
            var box = GameObject.CreatePrimitive(PrimitiveType.Cube);
            box.transform.position = center;
            box.transform.localScale = size;
            _created.Add(box);
            Physics.SyncTransforms();
        }
    }
}
