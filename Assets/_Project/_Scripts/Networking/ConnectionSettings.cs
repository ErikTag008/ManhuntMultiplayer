using UnityEngine;

namespace Project.Assets._Project._Scripts.Networking
{
    [CreateAssetMenu(fileName = "ConnectionSettings", menuName = "ScriptableObjects/ConnectionSettings", order = 1)]
    public class ConnectionSettings : ScriptableObject
    {
        [field: SerializeField] public string Address { get; private set; } = "127.0.0.1";
        [field: SerializeField] public ushort Port { get; private set; } = 7777;
        [field: SerializeField] public string ServerListenAddress { get; private set; } = "127.0.0.1";
        [field: SerializeField] public float ConnectTimeoutInSeconds { get; private set; } = 10f;
        // Unused: LobbyConfigData owns the default visibility now; kept so the asset's value isn't lost
        [field: SerializeField] public LobbyVisibility DefaultLobbyVisibility { get; private set; } = LobbyVisibility.FriendsOnly;

        [field: SerializeField] public string LobbyFolderName { get; private set; } = "Lobbies";
        [field: SerializeField, Min(0.1f)] public float AdvertHeartbeatInSeconds { get; private set; } = 2f;
        // Adverts not rewritten for this long belong to a host that crashed
        [field: SerializeField, Min(0.1f)] public float AdvertStaleAgeInSeconds { get; private set; } = 8f;
        [field: SerializeField] public string LocalRegionLabel { get; private set; } = "Local";

        [field: SerializeField] public string LobbyFullReason { get; private set; } = "Lobby is full";
        [field: SerializeField] public string HostFailedReason { get; private set; } = "Could not create the lobby";
        [field: SerializeField] public string JoinFailedReason { get; private set; } = "Could not join the lobby";
        // {0} is the timeout in seconds
        [field: SerializeField] public string JoinTimedOutReasonFormat { get; private set; } = "Timed out after {0}s";
    }
}
