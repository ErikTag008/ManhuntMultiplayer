using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Project.Assets._Project._Scripts.Managers
{
    public interface IGameStateMachine
    {
        GameState CurrentState { get; }
        event Action<GameState, GameState> OnStateChanged;

        void StartGameLoop();
        void StopGameLoop();
        void RequestGameStart();
    }
}
