using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    public class PlayerRegistry : NetworkBehaviour, IPlayerRegistry
    {
        [SerializeField] private List<PlayerController> _players = new();
        [SerializeField] private NetworkList<PlayerInfo> _playerInfos = new();
        private NetworkVariable<int> _playerCount = new();

        public int PlayerCount => _playerCount.Value;
        public List<PlayerController> GetPlayers() => _players;

        public void AddPlayerInfo(PlayerInfo info)
        {
            if (!IsServer) return;
            _playerInfos.Add(info);
        }

        public void RegisterPlayer(PlayerController player)
        {
            if (!IsServer) return;
            if (_players.Contains(player)) return;

            _players.Add(player);

            if (player.IsSpawned)
            {
                _playerCount.Value = _players.Count;
            }
            else
            {
                UpdatePlayerCountDelayed().Forget();
            }
            Debug.Log($"Registered player {player.OwnerClientId}. Total: {_players.Count}");
        }

        private async UniTaskVoid UpdatePlayerCountDelayed()
        {
            await UniTask.Yield();
            _playerCount.Value = _players.Count;
        }

        public NetworkList<PlayerInfo> PlayerInfos => _playerInfos;
        public NetworkVariable<int> PlayerCountVariable => _playerCount;
    }
}
