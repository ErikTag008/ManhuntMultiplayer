using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private NetworkObject _playerPrefab;
        [SerializeField] private Transform[] _spawnPoints;
        private IPlayerRegistry _playerRegistry;
        private readonly HashSet<ulong> _spawnedClients = new();


        private void Start()
        {
            if (!NetworkManager.Singleton)
                return;

            if (!NetworkManager.Singleton.IsServer)
                return;

            NetworkManager.Singleton.OnClientConnectedCallback += SpawnPlayer;

            SpawnExistingPlayers();
        }

        private void OnDestroy()
        {
            if (NetworkManager.Singleton)
            {
                NetworkManager.Singleton.OnClientConnectedCallback -= SpawnPlayer;
            }
        }

        private void SpawnExistingPlayers()
        {
            foreach (var client in NetworkManager.Singleton.ConnectedClientsList)
            {
                SpawnPlayer(client.ClientId);
            }
        }

        public void SpawnPlayer(ulong clientId)
        {
            EUtils.Logger.Log($"Spawning player for client {clientId}");
            if (!NetworkManager.Singleton.IsServer)
                return;

            if (_spawnedClients.Contains(clientId))
                return;
            EUtils.Logger.LogColorized("Trying to spawn" + clientId, "Yellow");
            _spawnedClients.Add(clientId);

            var spawnPoint = _spawnPoints[clientId % (ulong)_spawnPoints.Length];

            var player = Instantiate(
                _playerPrefab,
                spawnPoint.position,
                spawnPoint.rotation);

            player.SpawnAsPlayerObject(clientId);

            var playerController = player.GetComponent<PlayerController>();

            // Resolve the registry dynamically instead of relying on injection
            _playerRegistry ??= FindAnyObjectByType<PlayerRegistry>();

            if (_playerRegistry != null)
            {
                _playerRegistry.RegisterPlayer(playerController);
            }
            else
            {
                EUtils.Logger.LogError("[PlayerSpawner] IPlayerRegistry not found in scene! Cannot register player.");
            }
            EUtils.Logger.Log($"Spawned OwnerClientId = {player.OwnerClientId}");
        }
    }
}
