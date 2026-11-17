using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Managers
{
    public class TeamAssignmentService : ITeamAssignmentService
    {
        private readonly GameSystemsRegistry _gameSystemsRegistry;
        private readonly GameLobbySettings _settings;
        private readonly List<PlayerSession> _sessionBuffer = new();
        private readonly List<PlayerSession> _catcherBuffer = new();

        public TeamAssignmentService(GameSystemsRegistry gameSystemsRegistry, GameLobbySettings settings)
        {
            _gameSystemsRegistry = gameSystemsRegistry;
            _settings = settings;
        }

        // Catchers come from the front of the rotation queue, then go to its back; players infected later keep their place
        public void AssignTeams()
        {
            var playerRegistry = _gameSystemsRegistry.PlayerRegistry;
            if (playerRegistry == null)
            {
                EUtils.Logger.LogError("[TeamAssignmentService] PlayerRegistry is not registered. Cannot assign teams.");
                return;
            }

            playerRegistry.CopySessionsTo(_sessionBuffer);
            EUtils.Logger.Log($"Assigning teams for {_sessionBuffer.Count} players");

            CatcherQueue.CopyNextCatchers(_sessionBuffer, _settings.GetCatcherCount(_sessionBuffer.Count), _catcherBuffer);

            // the session list in PlayerRegistry is the only place the team lives
            foreach (var session in _sessionBuffer)
            {
                var team = IsCatcher(session.ClientId) ? Team.Catcher : Team.Runner;
                playerRegistry.SetTeam(session.ClientId, team);
                if (team == Team.Catcher) playerRegistry.MoveToBackOfCatcherQueue(session.ClientId);
                EUtils.Logger.Log($"Player {session.ClientId} -> {team}");
            }
        }

        private bool IsCatcher(ulong clientId)
        {
            foreach (var catcher in _catcherBuffer)
            {
                if (catcher.ClientId == clientId) return true;
            }
            return false;
        }
    }
}
