using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    // Fixed game loop rules; the per-match options (round length, hide time, max players, map) live in LobbyConfig
    [CreateAssetMenu(fileName = "GameLobbySettings", menuName = "ScriptableObjects/GameLobbySettings", order = 0)]
    public class GameLobbySettings : ScriptableObject
    {
        [field: SerializeField] public int MinRequiredPlayers { get; private set; } = 2;
        // hard cap, above any max players a host can pick
        [field: SerializeField] public int MaxConnectedPlayers { get; private set; } = 10;
        [field: SerializeField] public int MaxCatcherPlayers { get; private set; } = 2;
        [field: SerializeField, Min(1)] public int PlayersPerCatcher { get; private set; } = 6;
        [field: SerializeField] public float MaxWaitForPlayersTimeInSeconds { get; private set; } = 60f;
        [field: SerializeField] public float GameStartWaitTimeInSeconds { get; private set; } = 15f;
        [field: SerializeField] public float ResultsDurationInSeconds { get; private set; } = 15f;
        // round stats: a chase is an up catcher close to an up runner with a clear line between their eyes
        [field: SerializeField] public float ChaseRangeInMeters { get; private set; } = 15f;
        [field: SerializeField] public float ChaseLostAfterSeconds { get; private set; } = 3f;
        [field: SerializeField] public float MinChaseDurationInSeconds { get; private set; } = 3f;
        [field: SerializeField] public float ChaseSightHeightInMeters { get; private set; } = 1.5f;
        [field: SerializeField] public LayerMask ChaseSightBlockers { get; private set; } = ~0;

        // One catcher for every PlayersPerCatcher players (rounded up, so the second joins at 7), always leaving at least one runner
        public int GetCatcherCount(int playerCount)
        {
            int maxCatchers = Mathf.Min(MaxCatcherPlayers, playerCount - 1);
            if (maxCatchers <= 0) return 0;

            return Mathf.Clamp(Mathf.CeilToInt((float)playerCount / PlayersPerCatcher), 1, maxCatchers);
        }
    }
}
