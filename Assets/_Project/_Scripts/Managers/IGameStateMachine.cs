using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.Player;

namespace Project.Assets._Project._Scripts.Managers
{
    // TryCutRoundTime comes from IRoundTimer, so player-side systems can shorten the round without the Managers assembly
    public interface IGameStateMachine : IRoundTimer
    {
        GameState CurrentState { get; }
        // None until a round has finished
        RoundResult LastRoundResult { get; }
        event Action<GameState, GameState> OnStateChanged;
        event Action<RoundResult> OnLastRoundResultChanged;

        void StartGameLoop();
        void StopGameLoop();
        void RequestGameStart();
        // Server only: ends the running round without a winner and loads the lobby for everyone
        bool TryReturnToLobby();
    }
}
