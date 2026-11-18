using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    // Server only: times each runner's chases during the hunt and records the longest one in their session
    public class ChaseTracker
    {
        private readonly GameLobbySettings _settings;
        private readonly IPlayerRegistry _playerRegistry;
        private readonly Dictionary<ulong, ChaseTimer> _timers = new();
        private readonly List<ulong> _clientIdBuffer = new();

        public ChaseTracker(GameLobbySettings settings, IPlayerRegistry playerRegistry)
        {
            _settings = settings;
            _playerRegistry = playerRegistry;
        }

        public void Tick(List<PlayerController> players, double now)
        {
            foreach (var runner in players)
            {
                if (runner == null || runner.Team != Team.Runner) continue;

                _timers.TryGetValue(runner.OwnerClientId, out var timer);
                bool isInContact = runner.LifeState.IsUp && IsAnyCatcherInContact(runner, players);
                if (timer.Update(isInContact, now, _settings.ChaseLostAfterSeconds, out float durationInSeconds)) Record(runner.OwnerClientId, durationInSeconds);
                _timers[runner.OwnerClientId] = timer;
            }
        }

        // a chase still running when the hunt ends counts up to its last contact
        public void EndAll()
        {
            _clientIdBuffer.Clear();
            _clientIdBuffer.AddRange(_timers.Keys);
            foreach (ulong clientId in _clientIdBuffer)
            {
                var timer = _timers[clientId];
                if (timer.TryEnd(out float durationInSeconds)) Record(clientId, durationInSeconds);
            }

            _timers.Clear();
        }

        private void Record(ulong clientId, float durationInSeconds)
        {
            if (durationInSeconds < _settings.MinChaseDurationInSeconds) return;
            _playerRegistry.RecordChase(clientId, durationInSeconds);
        }

        private bool IsAnyCatcherInContact(PlayerController runner, List<PlayerController> players)
        {
            foreach (var catcher in players)
            {
                if (catcher == null || catcher.Team != Team.Catcher || !catcher.LifeState.IsUp) continue;
                if (IsInContact(catcher, runner)) return true;
            }

            return false;
        }

        // the ray starts inside the catcher's own collider, so the first thing it can hit is a wall or the runner
        private bool IsInContact(PlayerController catcher, PlayerController runner)
        {
            Vector3 sightOffset = Vector3.up * _settings.ChaseSightHeightInMeters;
            Vector3 from = catcher.transform.position + sightOffset;
            Vector3 toRunner = runner.transform.position + sightOffset - from;
            float distance = toRunner.magnitude;
            if (distance > _settings.ChaseRangeInMeters) return false;
            if (!Physics.Raycast(from, toRunner, out RaycastHit hit, distance, _settings.ChaseSightBlockers, QueryTriggerInteraction.Ignore)) return true;

            return hit.transform.IsChildOf(runner.transform);
        }
    }
}
