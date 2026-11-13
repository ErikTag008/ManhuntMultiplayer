using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Player
{
    // Picks the next or previous spectator target from ids sorted ascending, wrapping around at the ends.
    // A current id that is no longer in the list steps from the place it would sort into.
    public static class SpectatorTargets
    {
        public static bool TryPick(IReadOnlyList<ulong> sortedIds, ulong? currentId, bool isForward, out ulong id)
        {
            id = default;
            int count = sortedIds.Count;
            if (count == 0) return false;

            if (!currentId.HasValue)
            {
                id = isForward ? sortedIds[0] : sortedIds[count - 1];
                return true;
            }

            // first index whose id is at or above the current one
            int index = 0;
            while (index < count && sortedIds[index] < currentId.Value) index++;

            bool isListed = index < count && sortedIds[index] == currentId.Value;
            int pickedIndex = isForward
                ? (isListed ? index + 1 : index)
                : index - 1;
            id = sortedIds[(pickedIndex % count + count) % count];
            return true;
        }
    }
}
