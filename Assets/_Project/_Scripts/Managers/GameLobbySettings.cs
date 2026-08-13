using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    [CreateAssetMenu(fileName = "GameLobbySettings", menuName = "ScriptableObjects/GameLobbySettings", order = 0)]
    public class GameLobbySettings : ScriptableObject
    {
        [field: SerializeField] public int MinRequiredPlayers { get; private set; } = 2;
        [field: SerializeField] public int MaxConnectedPlayers { get; private set; } = 10;
        [field: SerializeField] public int MaxCatcherPlayers { get; private set; } = 2;
        [field: SerializeField] public float MaxWaitForPlayersTimeInSeconds { get; private set; } = 60f;
        [field: SerializeField] public float GameStartWaitTimeInSeconds { get; private set; } = 15f;
        [field: SerializeField] public float RunnersHideWaitTime { get; private set; } = 15f;
        [field: SerializeField] public float GameDurationInSeconds { get; private set; } = 120f;
        [field: SerializeField] public float ResultsDurationInSeconds { get; private set; } = 15f;
    }
    }
