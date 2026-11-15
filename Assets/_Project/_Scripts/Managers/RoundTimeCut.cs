using System;

namespace Project.Assets._Project._Scripts.Managers
{
    public static class RoundTimeCut
    {
        // A cut never extends the round and never takes it below the minimum; a round already under it is left alone
        public static double GetRemainingAfterCut(double remainingInSeconds, double cutInSeconds, double minRemainingInSeconds)
        {
            if (cutInSeconds <= 0 || remainingInSeconds <= minRemainingInSeconds) return remainingInSeconds;

            return Math.Max(minRemainingInSeconds, remainingInSeconds - cutInSeconds);
        }
    }
}
