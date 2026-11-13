using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Player
{
    // Whether a lobby can start: enough players, and every one of them has readied up
    public static class LobbyReadiness
    {
        public static int CountReady(IReadOnlyList<PlayerSession> sessions)
        {
            int readyCount = 0;
            foreach (var session in sessions)
            {
                if (session.IsReady) readyCount++;
            }

            return readyCount;
        }

        public static bool CanStart(IReadOnlyList<PlayerSession> sessions, int minRequiredPlayers) =>
            sessions.Count >= minRequiredPlayers && CountReady(sessions) == sessions.Count;
    }
}
