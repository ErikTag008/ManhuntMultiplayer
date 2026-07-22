using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    [CreateAssetMenu(fileName = "GameLobbySettings", menuName = "ScriptableObjects/GameLobbySettings", order = 0)]
    public class GameLobbySettings : ScriptableObject
    {
        [field: SerializeField] public int MinimumRequiredPlayers { get; private set; } = 2;
        [field: SerializeField] public int MaximumConnectePlayers { get; private set; } = 10;
        [field: SerializeField] public int MaximumCatcherPlayers { get; private set; } = 2;
        [field: SerializeField] public float MaxWaitForPlayersTimeInSeconds { get; private set; } = 60f;
        [field: SerializeField] public float GameStartWaitTimeInSeconds { get; private set; } = 15f;
        [field: SerializeField] public float GameDurationInSeconds { get; private set; } = 120f;
        [field: SerializeField] public float ResultsDurationInSeconds { get; private set; } = 15f;
    }
}
