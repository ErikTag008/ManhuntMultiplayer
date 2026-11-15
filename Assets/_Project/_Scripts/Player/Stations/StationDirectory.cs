using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Stations
{
    // Project-scoped list of the stations spawned on this instance; filled on clients too. Each Station adds and removes itself.
    public class StationDirectory
    {
        private readonly List<Station> _stations = new();

        // the station and the seconds it actually took off the round
        public event Action<Station, float> OnStationCompleted;

        // index it rather than foreach, so per-frame loops don't box an enumerator
        public IReadOnlyList<Station> Stations => _stations;
        public int TotalCount => _stations.Count;

        public int CompletedCount
        {
            get
            {
                int count = 0;
                for (int i = 0; i < _stations.Count; i++)
                {
                    if (_stations[i].IsCompleted) count++;
                }

                return count;
            }
        }

        public void Add(Station station)
        {
            if (!_stations.Contains(station)) _stations.Add(station);
        }

        public void Remove(Station station) => _stations.Remove(station);

        public void NotifyCompleted(Station station, float appliedCutInSeconds) => OnStationCompleted?.Invoke(station, appliedCutInSeconds);

        // The nearest station that can be worked right now with this position in its range
        public bool TryGetWorkableInRange(Vector3 position, out Station station)
        {
            station = null;
            float closestSqrDistance = float.MaxValue;
            for (int i = 0; i < _stations.Count; i++)
            {
                var candidate = _stations[i];
                if (!candidate.IsWorkable || !candidate.IsInRange(position)) continue;

                float sqrDistance = (candidate.transform.position - position).sqrMagnitude;
                if (sqrDistance >= closestSqrDistance) continue;

                closestSqrDistance = sqrDistance;
                station = candidate;
            }

            return station != null;
        }
    }
}
