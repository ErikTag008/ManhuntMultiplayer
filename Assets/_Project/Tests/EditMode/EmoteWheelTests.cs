using NUnit.Framework;
using Project.Assets._Project._Scripts.UI.HUD;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class EmoteWheelTests
    {
        private const float DeadZone = 0.35f;

        private static EmoteWheelOption[] Options(int count)
        {
            var options = new EmoteWheelOption[count];
            for (int i = 0; i < count; i++)
            {
                options[i] = new EmoteWheelOption($"Emote {i}", null);
            }

            return options;
        }

        [Test]
        public void PickSlice_FourSlices_UpRightDownLeftClockwise()
        {
            Assert.AreEqual(0, EmoteWheelState.PickSlice(Vector2.up, 4, DeadZone));
            Assert.AreEqual(1, EmoteWheelState.PickSlice(Vector2.right, 4, DeadZone));
            Assert.AreEqual(2, EmoteWheelState.PickSlice(Vector2.down, 4, DeadZone));
            Assert.AreEqual(3, EmoteWheelState.PickSlice(Vector2.left, 4, DeadZone));
        }

        [Test]
        public void PickSlice_SliceZeroIsCentredOnUp()
        {
            Assert.AreEqual(0, EmoteWheelState.PickSlice(new Vector2(-0.5f, 1f), 4, DeadZone));
            Assert.AreEqual(0, EmoteWheelState.PickSlice(new Vector2(0.5f, 1f), 4, DeadZone));
        }

        [Test]
        public void PickSlice_InsideDeadZoneOrNoSlices_PicksNothing()
        {
            Assert.AreEqual(EmoteWheelState.NoSelection, EmoteWheelState.PickSlice(Vector2.up * 0.1f, 4, DeadZone));
            Assert.AreEqual(EmoteWheelState.NoSelection, EmoteWheelState.PickSlice(Vector2.up, 0, DeadZone));
        }

        [Test]
        public void SliceDirection_MatchesPickSlice()
        {
            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(i, EmoteWheelState.PickSlice(EmoteWheelState.SliceDirection(i, 6), 6, DeadZone));
            }
        }

        [Test]
        public void Close_ReturnsLastAimedSlice_AndCentreKeepsIt()
        {
            var state = new EmoteWheelState();
            state.Open(Options(4));
            state.Aim(Vector2.right, DeadZone);
            state.Aim(Vector2.zero, DeadZone);

            Assert.AreEqual(1, state.Close());
            Assert.IsFalse(state.IsOpen);
        }

        [Test]
        public void Close_WithoutAiming_PicksNothing()
        {
            var state = new EmoteWheelState();
            state.Open(Options(4));

            Assert.AreEqual(EmoteWheelState.NoSelection, state.Close());
            Assert.AreEqual(EmoteWheelState.NoSelection, state.Close());
        }
    }
}
