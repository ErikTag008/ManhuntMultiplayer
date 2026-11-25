using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // Which parkour move the move input asks for. A jump press near a ledge climbs; a wall jump needs the input
    // to not push into the wall; during a climb only holding back lets go of the ledge.
    public static class ParkourInput
    {
        public static bool AllowsMantle(Vector2 moveInput, bool isJumpPressed, ParkourSettings settings) =>
            isJumpPressed || moveInput.y >= settings.MantleMinForwardInput;

        // worldMoveInput is the camera-relative input on the ground plane, its length the stick strength
        public static bool AllowsWallJump(Vector3 worldMoveInput, Vector3 wallNormal, ParkourSettings settings) =>
            Vector3.Dot(worldMoveInput, -wallNormal) <= settings.WallJumpMaxIntoWallInput;

        public static bool AllowsMantleKickOff(Vector2 moveInput, ParkourSettings settings) =>
            -moveInput.y >= settings.MantleKickOffMinBackInput;
    }
}
