using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Project.Assets._Project._Scripts.Managers
{
    public interface IGameStateMachine
    {
        GameState CurrentState { get; }
        // None until a round has finished
        RoundResult LastRoundResult { get; }
        event Action<GameState, GameState> OnStateChanged;
        event Action<RoundResult> OnLastRoundResultChanged;

        void StartGameLoop();
        void StopGameLoop();
        void RequestGameStart();
    }
}
