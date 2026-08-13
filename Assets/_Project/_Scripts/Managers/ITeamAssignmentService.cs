using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Managers
{
    public interface ITeamAssignmentService
    {
        void AssignTeams();
        Team GetPlayerTeam(ulong clientId);
    }
}
