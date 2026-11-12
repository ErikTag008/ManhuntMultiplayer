using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;

namespace Project.Assets._Project._Scripts.Managers
{
    public class TeamAssignmentService : ITeamAssignmentService
    {
        private readonly GameSystemsRegistry _gameSystemsRegistry;
        private readonly GameLobbySettings _settings;

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
            int catcherCount = _settings.GetCatcherCount(shuffled.Count);

            var catcherIds = shuffled.Take(catcherCount).Select(p => p.OwnerClientId).ToHashSet();

            // the session list in PlayerRegistry is the only place the team lives
            foreach (var player in players)
            {
                var team = catcherIds.Contains(player.OwnerClientId) ? Team.Catcher : Team.Runner;
                playerRegistry.SetTeam(player.OwnerClientId, team);
                EUtils.Logger.Log($"Player {player.OwnerClientId} -> {team}");
            }
        }
    }
}
