using System;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Player
{
    // The lobby map vote: the map with the most votes wins, a tie is drawn at random among the tied maps,
    // and with no valid votes the host's map stays. Votes for maps that aren't playable are ignored, and an unplayable
    // host map falls back to the first playable one.
    public static class MapVoteTally
    {
        public static int CountVotes(IReadOnlyList<PlayerSession> sessions, int mapIndex)
        {
            int voteCount = 0;
            foreach (var session in sessions)
            {
                if (session.MapVote == mapIndex) voteCount++;
            }

            return voteCount;
        }

        // pickIndex(count) returns a value in [0, count); the buffer holds the tied maps and is reused by the caller
        public static int PickMap(IReadOnlyList<PlayerSession> sessions, int mapCount, int fallbackMapIndex, Predicate<int> isPlayable,
            Func<int, int> pickIndex, List<int> tiedMapBuffer)
        {
            tiedMapBuffer.Clear();
            int mostVotes = 0;
            for (int mapIndex = 0; mapIndex < mapCount; mapIndex++)
            {
                if (!isPlayable(mapIndex)) continue;

                int voteCount = CountVotes(sessions, mapIndex);
                if (voteCount == 0 || voteCount < mostVotes) continue;

                if (voteCount > mostVotes)
                {
                    mostVotes = voteCount;
                    tiedMapBuffer.Clear();
                }

                tiedMapBuffer.Add(mapIndex);
            }

            return tiedMapBuffer.Count switch
            {
                0 => PickFallback(mapCount, fallbackMapIndex, isPlayable),
                1 => tiedMapBuffer[0],
                _ => tiedMapBuffer[Math.Clamp(pickIndex(tiedMapBuffer.Count), 0, tiedMapBuffer.Count - 1)]
            };
        }

        // with nothing playable the host's map stays, as before
        private static int PickFallback(int mapCount, int fallbackMapIndex, Predicate<int> isPlayable)
        {
            if (isPlayable(fallbackMapIndex)) return fallbackMapIndex;

            for (int mapIndex = 0; mapIndex < mapCount; mapIndex++)
            {
                if (isPlayable(mapIndex)) return mapIndex;
            }

            return fallbackMapIndex;
        }
    }
}
