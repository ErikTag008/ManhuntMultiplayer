using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Player
{
    // Project-scoped list of the catchers ghosts have pinged, with when each ping runs out on this instance's clock.
    // Filled on every instance by PlayerGhost; a ping only lasts for the hunt it was made in.
    public class GhostPingDirectory
    {
        private readonly List<ulong> _catcherIds = new();
        private readonly List<float> _expiryTimes = new();

        // may still hold expired pings until RemoveExpired runs
        public IReadOnlyList<ulong> CatcherIds => _catcherIds;

        public GhostPingDirectory(HuntPhase huntPhase)
        {
            huntPhase.OnChanged += HandleHuntChanged;
        }

        // a new ping on an already pinged catcher restarts its time
        public void Add(ulong catcherId, float expiryTime)
        {
            int index = _catcherIds.IndexOf(catcherId);
            if (index >= 0)
            {
                _expiryTimes[index] = expiryTime;
                return;
            }

            _catcherIds.Add(catcherId);
            _expiryTimes.Add(expiryTime);
        }

        public bool IsPinged(ulong catcherId, float now)
        {
            int index = _catcherIds.IndexOf(catcherId);
            return index >= 0 && now < _expiryTimes[index];
        }

        public void RemoveExpired(float now)
        {
            for (int i = _catcherIds.Count - 1; i >= 0; i--)
            {
                if (now < _expiryTimes[i]) continue;

                _catcherIds.RemoveAt(i);
                _expiryTimes.RemoveAt(i);
            }
        }

        public void Clear()
        {
            _catcherIds.Clear();
            _expiryTimes.Clear();
        }

        // the hunt starting or ending both leave no ping from before standing
        private void HandleHuntChanged(bool _) => Clear();
    }
}
