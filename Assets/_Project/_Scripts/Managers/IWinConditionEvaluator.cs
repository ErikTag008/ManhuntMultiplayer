using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Managers
{
    // Decides the round winner from the players' sessions; None means the round goes on
    public interface IWinConditionEvaluator
    {
        RoundResult Evaluate(IReadOnlyList<PlayerSession> sessions, bool isTimeUp);
    }

    public enum RoundResult
    {
        None,
        CatchersWin,
        RunnersWin
    }
}
