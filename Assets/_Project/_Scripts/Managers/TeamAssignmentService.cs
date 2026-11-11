using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    public class TeamAssignmentService : ITeamAssignmentService
    {
        private readonly GameSystemsRegistry _gameSystemsRegistry;
        private readonly GameLobbySettings _settings;
        private HashSet<ulong> _catcherIds;

        public TeamAssignmentService(GameSystemsRegistry gameSystemsRegistry, GameLobbySettings settings)
        {
            _gameSystemsRegistry = gameSystemsRegistry;
            _settings = settings;
        }

        public void AssignTeams()
        {
            var playerRegistry = _gameSystemsRegistry.PlayerRegistry;
            if (playerRegistry == null)
            {
                EUtils.Logger.LogError("[TeamAssignmentService] PlayerRegistry is not registered. Cannot assign teams.");
                return;
            }

            var players = playerRegistry.GetPlayers();
            EUtils.Logger.Log($"Assigning teams for {players.Count} players");

            var shuffled = players.OrderBy(_ => UnityEngine.Random.value).ToList();
            int catcherCount = Mathf.Min(_settings.MaxCatcherPlayers, shuffled.Count - 1);

            _catcherIds = shuffled.Take(catcherCount).Select(p => p.OwnerClientId).ToHashSet();

            foreach (var player in players)
            {
                var team = _catcherIds.Contains(player.OwnerClientId) ? Team.Catcher : Team.Runner;
                player.SetTeam(team);

                playerRegistry.AddPlayerInfo(new PlayerInfo { ClientId = player.OwnerClientId, Team = team });
                EUtils.Logger.Log($"Player {player.OwnerClientId} -> {team}");
            }
        }

        public Team GetPlayerTeam(ulong clientId)
        {
            if (_catcherIds == null) return Team.None;
            return _catcherIds.Contains(clientId) ? Team.Catcher : Team.Runner;
        }
    }
}
