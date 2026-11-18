using Project.Assets._Project._Scripts.Player;
using System;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Managers
{
    // Picks the leaders of one round stat for the results screen; everyone tied on the top value shares it
    public static class RoundHighlights
    {
        // Returns the top value; the buffer stays empty when nobody scored
        public static float CopyLeaders(List<PlayerSession> sessions, Func<PlayerSession, float> getValue, List<PlayerSession> leaders)
        {
            leaders.Clear();
            float bestValue = 0f;
            foreach (var session in sessions)
            {
                float value = getValue(session);
                if (value <= 0f || value < bestValue) continue;

                if (value > bestValue) leaders.Clear();
                bestValue = value;
                leaders.Add(session);
            }

            return bestValue;
        }
    }
}
