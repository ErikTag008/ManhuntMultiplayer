using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Managers
{
    // Manhunt rules: catchers win once no runner is standing (knocked runners have nobody left to rescue them),
    // runners win if at least one is standing when time runs out, or if every catcher has left
    public class WinConditionEvaluator : IWinConditionEvaluator
    {
        public RoundResult Evaluate(IReadOnlyList<PlayerSession> sessions, bool isTimeUp)
        {
            int catcherCount = 0;
            int standingRunnerCount = 0;

            foreach (var session in sessions)
            {
                if (session.Team == Team.Catcher) catcherCount++;
                if (session.Team == Team.Runner && session.LifeState == LifeState.Up) standingRunnerCount++;
            }

            if (catcherCount == 0) return RoundResult.RunnersWin;
            if (standingRunnerCount == 0) return RoundResult.CatchersWin;
            return isTimeUp ? RoundResult.RunnersWin : RoundResult.None;
        }
    }
}
