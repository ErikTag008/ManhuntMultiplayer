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
        [field: SerializeField] public LobbyVisibility DefaultLobbyVisibility { get; private set; } = LobbyVisibility.FriendsOnly;
    }
}
