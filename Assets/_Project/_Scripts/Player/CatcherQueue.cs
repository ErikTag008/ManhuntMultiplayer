using System;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Player
{
    // Catcher rotation: the players whose catcher turn was longest ago (or who never had one) go first
    public static class CatcherQueue
    {
        private static readonly Comparison<PlayerSession> QueueComparison = CompareQueuePosition;

        // Fills a caller-owned list with the next catcherCount players, front of the queue first
        public static void CopyNextCatchers(IReadOnlyList<PlayerSession> sessions, int catcherCount, List<PlayerSession> result)
        {
            result.Clear();
            if (catcherCount <= 0) return;

            foreach (var session in sessions) result.Add(session);
            result.Sort(QueueComparison);

            if (result.Count > catcherCount) result.RemoveRange(catcherCount, result.Count - catcherCount);
        }

        // client id breaks ties so every instance shows the same order
        private static int CompareQueuePosition(PlayerSession a, PlayerSession b)
        {
            int byOrder = a.CatcherQueueOrder.CompareTo(b.CatcherQueueOrder);
            return byOrder != 0 ? byOrder : a.ClientId.CompareTo(b.ClientId);
        }
    }
}
