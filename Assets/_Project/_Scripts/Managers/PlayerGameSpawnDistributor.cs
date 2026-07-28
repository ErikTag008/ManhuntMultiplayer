using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    public class PlayerGameSpawnDistributor : Singleton<PlayerGameSpawnDistributor>
    {
        [SerializeField] private Transform[] _waitingRoomSpawns;
        [SerializeField] private Transform[] _gameRoomSpawns;

        public void DistributePlayersToSpawns(List<PlayerController> players)
        {
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

                    spawn = waitingSpawns[waitingIndex++];
                }
                else
                {
                    if (gameIndex >= gameSpawns.Count)
                    {
                        Debug.LogError("Not enough game room spawn points!");
                        return;
                    }

                    spawn = gameSpawns[gameIndex++];
                }

                player.transform.SetPositionAndRotation(spawn.position, spawn.rotation);
            }
        }

    }
}
