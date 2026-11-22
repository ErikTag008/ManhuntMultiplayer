using Project.Assets._Project._Scripts.Player;
using System.Collections.Generic;

namespace Project.Assets._Project._Scripts.Managers
{
    // Decides the round winner from the players' sessions; None means the round goes on.
    // A practice round started without catchers (solo testing): only the timer ends it, and nobody wins.
    public interface IWinConditionEvaluator
    {
        RoundResult Evaluate(IReadOnlyList<PlayerSession> sessions, bool isTimeUp, bool isPracticeRound);
    }

    public enum RoundResult
    {
        None,
        CatchersWin,
        RunnersWin,
        PracticeOver
    }
}
