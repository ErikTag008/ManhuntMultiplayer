using Project.Assets._Project._Scripts.Player;
using Reflex.Attributes;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    public class PlayerSpawner : MonoBehaviour
    {
        [Inject] private readonly GameSystemsRegistry _gameSystemsRegistry;
        [SerializeField] private NetworkObject _playerPrefab;
        [SerializeField] private Transform[] _spawnPoints;
        private readonly HashSet<ulong> _spawnedClients = new();
        // spawn point index per client, so two players never share a point (client ids keep growing as players rejoin)
        private readonly Dictionary<ulong, int> _spawnPointIndexByClient = new();


        private void Start()
        {
            if (!NetworkManager.Singleton)
                return;

            if (!NetworkManager.Singleton.IsServer)
                return;

            NetworkManager.Singleton.OnClientConnectedCallback += SpawnPlayer;
            NetworkManager.Singleton.OnClientDisconnectCallback += HandleClientDisconnected;

            SpawnExistingPlayers();
        }

        private void OnDestroy()
        {
            if (NetworkManager.Singleton)
            {
                NetworkManager.Singleton.OnClientConnectedCallback -= SpawnPlayer;
                NetworkManager.Singleton.OnClientDisconnectCallback -= HandleClientDisconnected;
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

            var spawnPoint = ClaimSpawnPoint(clientId);

            // Players persist across Single-mode scene loads; returning from a round only moves them back
            if (TryGetExistingPlayer(clientId, out var existingPlayer))
            {
                existingPlayer.TeleportRpc(spawnPoint.position, spawnPoint.rotation);
                return;
            }

            var player = Instantiate(
                _playerPrefab,
                spawnPoint.position,
                spawnPoint.rotation);

            player.SpawnAsPlayerObject(clientId, destroyWithScene: false);

            var playerController = player.GetComponent<PlayerController>();

            var playerRegistry = _gameSystemsRegistry.PlayerRegistry;

            if (playerRegistry != null)
            {
                playerRegistry.RegisterPlayer(playerController);
            }
            else
            {
                EUtils.Logger.LogError("[PlayerSpawner] IPlayerRegistry not found in scene! Cannot register player.");
            }
            EUtils.Logger.Log($"Spawned OwnerClientId = {player.OwnerClientId}");
        }

        private Transform ClaimSpawnPoint(ulong clientId)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                if (_spawnPointIndexByClient.ContainsValue(i)) continue;

                _spawnPointIndexByClient[clientId] = i;
                return _spawnPoints[i];
            }

            EUtils.Logger.LogWarning($"[PlayerSpawner] No free spawn point for client {clientId}; add more spawn points to the lobby.");
            return _spawnPoints[clientId % (ulong)_spawnPoints.Length];
        }

        private void HandleClientDisconnected(ulong clientId)
        {
            _spawnedClients.Remove(clientId);
            _spawnPointIndexByClient.Remove(clientId);
        }

        private static bool TryGetExistingPlayer(ulong clientId, out PlayerController player)
        {
            player = null;
            if (!NetworkManager.Singleton.ConnectedClients.TryGetValue(clientId, out var client)) return false;
            if (client.PlayerObject == null) return false;

            return client.PlayerObject.TryGetComponent(out player);
        }
    }
}
