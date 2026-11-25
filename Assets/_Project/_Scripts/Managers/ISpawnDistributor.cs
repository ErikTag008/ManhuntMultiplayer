using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    public interface ISpawnDistributor
    {
        UniTask DistributePlayersToSpawns(List<PlayerController> players);
        // A player who joined the catchers mid-round starts from a catcher spawn
        void SendToCatcherSpawn(PlayerController player);
        // where a player who joined a running round to watch it appears (a runner spawn); null when the map has none
        Transform GetSpectatorSpawn();
    }
}
