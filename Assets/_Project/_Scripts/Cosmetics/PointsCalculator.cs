using UnityEngine;

namespace Project.Assets._Project._Scripts.Cosmetics
{
    // Turns a round's result and stats into points; a player who sat the round out (no team) earns nothing
    public static class PointsCalculator
    {
        public static RoundPoints Calculate(PointRewards rewards, bool hasPlayed, bool isWinner, int catches, int rescues, int stationsCompleted, float longestChaseInSeconds)
        {
            if (!hasPlayed) return default;

            return new RoundPoints(
                rewards.PointsPerRound,
                isWinner ? rewards.WinBonus : 0,
                Mathf.Max(0, catches) * rewards.PointsPerCatch,
                Mathf.Max(0, rescues) * rewards.PointsPerRescue,
                Mathf.Max(0, stationsCompleted) * rewards.PointsPerStation,
                GetChasePoints(rewards, longestChaseInSeconds));
        }

        private static int GetChasePoints(PointRewards rewards, float longestChaseInSeconds)
        {
            if (rewards.ChaseStepInSeconds <= 0f || longestChaseInSeconds <= 0f) return 0;

            int steps = Mathf.FloorToInt(longestChaseInSeconds / rewards.ChaseStepInSeconds);
            return Mathf.Min(steps * rewards.PointsPerChaseStep, rewards.MaxChasePoints);
        }
    }
}
