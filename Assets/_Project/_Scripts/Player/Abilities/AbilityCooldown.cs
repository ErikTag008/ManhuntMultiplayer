using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Abilities
{
    // Cooldown maths on server time, shared by the owner's check and the server's
    public static class AbilityCooldown
    {
        public static float RemainingInSeconds(double now, double endTime) => Mathf.Max(0f, (float)(endTime - now));

        // the owner's estimate of server time can run slightly ahead, so an honest use may arrive a little early
        public static bool IsAcceptedByServer(double now, double endTime, float toleranceInSeconds) => now + toleranceInSeconds >= endTime;
    }
}
