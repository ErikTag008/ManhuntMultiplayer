using Cysharp.Threading.Tasks;
using System;
using System.Threading;

namespace Project.Assets._Project._Scripts.Networking
{
    public interface IConnectionService
    {
        bool IsConnected { get; }

        // Raised when an established session ends (host stopped, kicked, connection lost); payload is the reason
        event Action<string> OnDisconnected;

        UniTask<bool> Host(LobbyVisibility visibility, CancellationToken token);
        UniTask<bool> Join(string target, CancellationToken token);
        void Leave();
    }
}
