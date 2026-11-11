using System.Collections.Generic;
using Unity.Netcode;

namespace Project.Assets._Project._Scripts.Player
{
    public interface IPlayerRegistry
    {
        void RegisterPlayer(PlayerController player);
        void AddPlayerInfo(PlayerInfo info);
        int PlayerCount { get; }
        List<PlayerController> GetPlayers();
        NetworkList<PlayerInfo> PlayerInfos { get; }
        NetworkVariable<int> PlayerCountVariable { get; }
    }
}