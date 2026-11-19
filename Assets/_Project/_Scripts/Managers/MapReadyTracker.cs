using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Managers
{
    // Server bookkeeping for a bundle map load: the clients the server waits for and what each one reported.
    // A client's first report counts. Reports from clients nobody waits for (late joiners) are still kept.
    public class MapReadyTracker
    {
        private readonly HashSet<ulong> _expectedClientIds = new();
        private readonly Dictionary<ulong, MapLoadResult> _results = new();

        // a failed report counts as an answer; the caller disconnects that client
        public bool IsComplete
        {
            get
            {
                foreach (ulong clientId in _expectedClientIds)
                {
                    if (!_results.ContainsKey(clientId)) return false;
                }

                return true;
            }
        }

        public void Expect(ulong clientId) => _expectedClientIds.Add(clientId);

        // a client that left is neither waited for nor kept
        public void Forget(ulong clientId)
        {
            _expectedClientIds.Remove(clientId);
            _results.Remove(clientId);
        }

        // false for a repeated report, which is ignored
        public bool TryReport(ulong clientId, MapLoadResult result) => _results.TryAdd(clientId, result);

        public bool TryGetResult(ulong clientId, out MapLoadResult result) => _results.TryGetValue(clientId, out result);

        // the expected clients that haven't reported yet
        public void CopyMissing(List<ulong> results)
        {
            results.Clear();
            foreach (ulong clientId in _expectedClientIds)
            {
                if (!_results.ContainsKey(clientId)) results.Add(clientId);
            }
        }
    }

    public enum MapLoadResult
    {
        Ready,
        // no map with that id in the local library
        Missing,
        // the map is there, but not the same file as the host's
        Different,
        // the map broke a rule of the map SDK
        Invalid,
        // the bundle or its prefab couldn't be loaded
        Failed
    }
}
