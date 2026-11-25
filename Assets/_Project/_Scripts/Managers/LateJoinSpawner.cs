using KBCore.Refs;
using Project.Assets._Project._Scripts.Player;
using Reflex.Attributes;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    // Server only: a client who connects while a round runs gets their player in the map as a spectator outside both teams.
    // The lobby's PlayerSpawner handles everyone else, and moves the spectator to a lobby spawn once the round ends.
    public class LateJoinSpawner : NetworkBehaviour
    {
        [Inject] private readonly GameSystemsRegistry _gameSystemsRegistry;
        [SerializeField, Self] private GameStateMachine _gameStateMachine;
        [SerializeField, Self] private PlayerRegistry _playerRegistry;
        [SerializeField] private NetworkObject _playerPrefab;

        private bool _isListening;

        private void OnValidate() => this.ValidateRefs();

        // GameManager injects GameSystems in its own OnNetworkSpawn, so the injected registry is only certain to be set here
        protected override void OnNetworkPostSpawn()
        {
            if (!IsServer) return;

            NetworkManager.OnClientConnectedCallback += HandleClientConnected;
            _isListening = true;
        }

        private void HandleClientConnected(ulong clientId)
        {
            if (!RoundProgress.IsInProgress(_gameStateMachine.CurrentState)) return;
            if (!NetworkManager.ConnectedClients.TryGetValue(clientId, out var client) || client.PlayerObject != null) return;

            var spawn = _gameSystemsRegistry.SpawnDistributor?.GetSpectatorSpawn();
            if (spawn == null) EUtils.Logger.LogWarning($"[LateJoinSpawner] No spectator spawn in this map; client {clientId} starts at the origin.");

            var player = spawn != null
                ? Instantiate(_playerPrefab, spawn.position, spawn.rotation)
                : Instantiate(_playerPrefab);
            player.SpawnAsPlayerObject(clientId, destroyWithScene: false);

            if (!player.TryGetComponent(out PlayerController playerController))
            {
                EUtils.Logger.LogError($"[LateJoinSpawner] {_playerPrefab.name} has no PlayerController; client {clientId} isn't registered.");
                return;
            }

            _playerRegistry.RegisterSpectator(playerController);
            EUtils.Logger.Log($"[LateJoinSpawner] Client {clientId} joined during {_gameStateMachine.CurrentState} and watches the round.");
        }

        private void StopListening()
        {
            if (!_isListening) return;

            _isListening = false;
            if (NetworkManager != null) NetworkManager.OnClientConnectedCallback -= HandleClientConnected;
        }

        public override void OnNetworkDespawn() => StopListening();

        public override void OnDestroy()
        {
            StopListening();
            base.OnDestroy();
        }
    }
}
