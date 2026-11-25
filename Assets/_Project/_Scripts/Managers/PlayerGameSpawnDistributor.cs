using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.Player;
using Reflex.Attributes;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    public class PlayerGameSpawnDistributor : MonoBehaviour, ISpawnDistributor
    {
        [SerializeField] private Transform[] _waitingRoomSpawns;
        [SerializeField] private Transform[] _gameRoomSpawns;

        // the registry's list shrinks when someone leaves, and the loop below yields between players;
        // one distribution per round (GameStateMachine), so two never share the buffer
        private readonly List<PlayerController> _playerBuffer = new();
        private GameSystemsRegistry _gameSystemsRegistry;

        [Inject]
        private void RegisterInGameSystems(GameSystemsRegistry gameSystemsRegistry)
        {
            _gameSystemsRegistry = gameSystemsRegistry;
            _gameSystemsRegistry.Register(this);
        }

        

        public async UniTask DistributePlayersToSpawns(List<PlayerController> players)
        {
            EUtils.Logger.Log("Distributing players to spawns...");
            var waitingSpawns = _waitingRoomSpawns.OrderBy(_ => Random.value).ToList();
            var gameSpawns = _gameRoomSpawns.OrderBy(_ => Random.value).ToList();

            int waitingIndex = 0;
            int gameIndex = 0;
            _playerBuffer.Clear();
            _playerBuffer.AddRange(players);

            foreach (var player in _playerBuffer)
            {
                if (player == null || !player.IsSpawned) continue;

                Transform spawn;
               
                if (player.Team == Team.Catcher)
                {
                    if (waitingIndex >= waitingSpawns.Count)
                    {
                        EUtils.Logger.LogError("Not enough waiting room spawn points!");
                        return;
                    }
                    EUtils.Logger.Log($"Spawning player {player.OwnerClientId} (Catcher) at waiting room spawn point {waitingIndex}");
                    spawn = waitingSpawns[waitingIndex++];
                }
                else
                {
                    if (gameIndex >= gameSpawns.Count)
                    {
                        EUtils.Logger.LogError("Not enough game room spawn points!");
                        return;
                    }

                    EUtils.Logger.Log($"Spawning player {player.OwnerClientId} (Runner) at game room spawn point {gameIndex}");
                    spawn = gameSpawns[gameIndex++];
                }

                player.TeleportRpc(spawn.position, spawn.rotation);
                await UniTask.Yield();
            }
        }

        // for maps that bring their own spawns (bundle maps); catchers use the waiting room, runners the game room
        public void SetSpawns(Transform[] catcherSpawns, Transform[] runnerSpawns)
        {
            _waitingRoomSpawns = catcherSpawns;
            _gameRoomSpawns = runnerSpawns;
        }

        public void SendToCatcherSpawn(PlayerController player)
        {
            if (_waitingRoomSpawns.Length == 0)
            {
                EUtils.Logger.LogError("No waiting room spawn points!");
                return;
            }

            var spawn = _waitingRoomSpawns[Random.Range(0, _waitingRoomSpawns.Length)];
            player.TeleportRpc(spawn.position, spawn.rotation);
        }

        public Transform GetSpectatorSpawn() => _gameRoomSpawns.Length > 0 ? _gameRoomSpawns[Random.Range(0, _gameRoomSpawns.Length)] : null;

        private void OnDestroy() => _gameSystemsRegistry?.Unregister(this);
    }
}
