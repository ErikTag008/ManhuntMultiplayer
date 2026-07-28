using Alchemy.Inspector;
using Project.Assets._Project._Scripts.CameraUtils;
using Project.Assets._Project._Scripts.Player;
using Reflex.Attributes;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    public class PlayerSpawner : MonoBehaviour, ISceneInitialized
    {
        [SerializeField] private NetworkObject _playerPrefab;
        [SerializeField] private Transform[] _spawnPoints;
        [Inject] private readonly SceneLifecycleManager _sceneLifecycleManager;
        private readonly HashSet<ulong> _spawnedClients = new();


        private void Awake()
        {
            _sceneLifecycleManager.Register(this);
        }

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

        public void InitializeSceneReferences(SceneType scene)
        {
            if (scene == SceneType.Lobby)
            {
                GameManager.Instance?.SetActiveSpawner(this);
            }
        }

        public void ClearSceneReferences(SceneType scene)
        {
        }


        public void SpawnPlayer(ulong clientId)
        {
            Debug.Log($"Spawning player for client {clientId}");
            if (!NetworkManager.Singleton.IsServer)
                return;

            if (_spawnedClients.Contains(clientId))
                return;
            print(EUtils.Logger.Colorize("Trying to spawn" + clientId, "Yellow"));
            _spawnedClients.Add(clientId);

            var spawnPoint = _spawnPoints[clientId % (ulong)_spawnPoints.Length];

            var player = Instantiate(
                _playerPrefab,
                spawnPoint.position,
                spawnPoint.rotation);

            player.SpawnAsPlayerObject(clientId);

            var playerController = player.GetComponent<PlayerController>();
            GameManager.Instance?.RegisterPlayer(playerController);
            Debug.Log($"Spawned OwnerClientId = {player.OwnerClientId}");
        }
    }
}
