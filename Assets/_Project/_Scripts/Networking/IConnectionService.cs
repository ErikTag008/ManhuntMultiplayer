using Cysharp.Threading.Tasks;
using System;
using System.Threading;

namespace Project.Assets._Project._Scripts.Networking
{
    public interface IConnectionService
    {
        bool IsConnected { get; }
        // Host only: players in the session plus approved ones still connecting; 0 when not hosting
        int TakenSlotCount { get; }
        // Why the last Host or Join failed (e.g. "Lobby is full"); null after a success
        string LastFailureReason { get; }

        // Raised when an established session ends (host stopped, kicked, connection lost); payload is the reason
        event Action<string> OnDisconnected;

        UniTask<bool> Host(LobbyConfig config, CancellationToken token);
        // target is an address, optionally with ":port" (ConnectionTarget); without one the default port is used
        UniTask<bool> Join(string target, CancellationToken token);
        // Host only: the lobby changed its config after hosting (e.g. max players)
        void UpdateHostedLobby(LobbyConfig config);
        void Leave();
    }
}
