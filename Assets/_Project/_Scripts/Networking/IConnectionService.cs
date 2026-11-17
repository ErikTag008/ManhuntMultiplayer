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
        // True while in a session whose friends can be invited through the platform (Steam)
        bool CanInviteFriends { get; }

        // Raised when an established session ends (host stopped, kicked, connection lost); payload is the reason
        event Action<string> OnDisconnected;

        UniTask<bool> Host(LobbyConfig config, CancellationToken token);
        // Local: an address, optionally with ":port" (ConnectionTarget); without one the default port is used.
        // Steam: a lobby id in decimal (SteamLobbyId).
        UniTask<bool> Join(string target, CancellationToken token);
        // Host only: the lobby changed its config after hosting (e.g. max players)
        void UpdateHostedLobby(LobbyConfig config);
        void Leave();
        // Host only: the name a client connected with; false when it sent none (local sessions)
        bool TryGetPlayerName(ulong clientId, out string name);
        // Opens the platform's invite dialog for this session; does nothing when CanInviteFriends is false
        void OpenInviteDialog();
    }
}
