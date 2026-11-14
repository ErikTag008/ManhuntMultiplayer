using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Player.Drops
{
    public static class WeightedPick
    {
        // random01 in [0, 1] (Random.value includes 1) maps onto the summed weights; zero and negative weights never win
        public static bool TryPickIndex(IReadOnlyList<float> weights, float random01, out int index)
        {
            index = -1;
            if (weights == null) return false;

            float total = 0f;
            int lastPickable = -1;
            for (int i = 0; i < weights.Count; i++)
            {
                if (weights[i] <= 0f) continue;

                total += weights[i];
                lastPickable = i;
            }

            if (lastPickable < 0) return false;

            float target = random01 * total;
            float cumulative = 0f;
            for (int i = 0; i < weights.Count; i++)
            {
                if (weights[i] <= 0f) continue;

                cumulative += weights[i];
                if (target < cumulative)
                {
                    index = i;
                    return true;
                }
            }

            // random01 of 1 (or float rounding at the very top) lands on the last weighted entry
            index = lastPickable;
            return true;
        }
    }
}
