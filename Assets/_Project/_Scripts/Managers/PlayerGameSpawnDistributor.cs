using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    public class PlayerGameSpawnDistributor : MonoBehaviour, ISpawnDistributor
    {
        [SerializeField] private Transform[] _waitingRoomSpawns;
        [SerializeField] private Transform[] _gameRoomSpawns;

        

        public async UniTask DistributePlayersToSpawns(List<PlayerController> players)
        {
            Debug.Log("Distributing players to spawns...");
            var waitingSpawns = _waitingRoomSpawns.OrderBy(_ => Random.value).ToList();
            var gameSpawns = _gameRoomSpawns.OrderBy(_ => Random.value).ToList();

            int waitingIndex = 0;
            int gameIndex = 0;

            foreach (var player in players)
            {
                Transform spawn;
               
                if (player.Team == Team.Catcher)
                {
                    if (waitingIndex >= waitingSpawns.Count)
                    {
                        Debug.LogError("Not enough waiting room spawn points!");
                        return;
                    }
                    Debug.Log($"Spawning player {player.OwnerClientId} (Catcher) at waiting room spawn point {waitingIndex}");
                    spawn = waitingSpawns[waitingIndex++];
                }
                else
                {
                    if (gameIndex >= gameSpawns.Count)
                    {
                        Debug.LogError("Not enough game room spawn points!");
                        return;
                    }

                    Debug.Log($"Spawning player {player.OwnerClientId} (Runner) at game room spawn point {gameIndex}");
                    spawn = gameSpawns[gameIndex++];
                }

                player.TeleportRpc(spawn.position, spawn.rotation);
                await UniTask.Yield();
            }
        }

    }
}
