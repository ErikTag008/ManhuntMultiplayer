using NUnit.Framework;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class PlayerCollisionTests
    {
        // Player is the lobby model's layer; Runner and Catcher are the team models' layers
        private static readonly string[] PlayerLayerNames = { "Player", "Runner", "Catcher" };
        private const string GroundLayerName = "Default";

        // Each machine sees the other players as kinematic copies that lag behind, so overlapping player bodies
        // pushed each other at depenetration speed until they fell off the map. Players pass through each other.
        [Test]
        public void PlayerLayers_DoNotCollideWithEachOther()
        {
            foreach (string first in PlayerLayerNames)
            {
                foreach (string second in PlayerLayerNames)
                {
                    Assert.IsTrue(Physics.GetIgnoreLayerCollision(Layer(first), Layer(second)), $"{first} still collides with {second}.");
                }
            }
        }

        [Test]
        public void PlayerLayers_StillCollideWithTheGround()
        {
            foreach (string name in PlayerLayerNames)
            {
                Assert.IsFalse(Physics.GetIgnoreLayerCollision(Layer(name), Layer(GroundLayerName)), $"{name} falls through the ground.");
            }
        }

        private static int Layer(string name)
        {
            int layer = LayerMask.NameToLayer(name);
            Assert.GreaterOrEqual(layer, 0, $"The {name} layer is missing.");
            return layer;
        }
    }
}
