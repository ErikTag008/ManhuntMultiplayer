using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Networking
{
    public interface IConnectionService
    {
        bool IsConnected { get; }
        // True while this instance hosts a session and approves who joins it
        bool IsHosting { get; }
        // True when TryKick also keeps the player out of this hosted session (Steam knows who they are; Local only disconnects)
        bool CanBlockRejoin { get; }
        // Host only: players in the session plus approved ones still connecting; 0 when not hosting
        int TakenSlotCount { get; }
        // Why the last Host or Join failed (e.g. "Lobby is full"); null after a success
        string LastFailureReason { get; }
        // True while in a session whose friends can be invited through the platform (Steam)
        bool CanInviteFriends { get; }
        // A short code others can type to join this session (Steam: SteamLobbyId.FormatCode); null when there is none
        string JoinCode { get; }
        // True when the local player's platform status hides this game from friends (Steam: Invisible), so they can't
        // find the session in their friends list and need the join code
        bool IsHiddenFromFriends { get; }

        // Raised when an established session ends (host stopped, kicked, connection lost); payload is the reason
        event Action<string> OnDisconnected;

        UniTask<bool> Host(LobbyConfig config, CancellationToken token);
        // Local: an address, optionally with ":port" (ConnectionTarget); without one the default port is used.
        // Steam: a lobby id in decimal or a join code (SteamLobbyId).
        UniTask<bool> Join(string target, CancellationToken token);
        // Host only: the lobby changed its config after hosting (e.g. max players)
        void UpdateHostedLobby(LobbyConfig config);
        // Host only: while closed, connecting clients are turned away with ConnectionSettings.RoundStartingReason
        void ToggleJoinsOpen(bool isOpen);
        void Leave();
        // Host only: disconnects a connected client and turns them away if they try to rejoin before the host stops hosting;
        // false for the host itself or a client that isn't connected
        bool TryKick(ulong clientId);
        // Host only: the name a client connected with; false when it sent none (local sessions)
        bool TryGetPlayerName(ulong clientId, out string name);
        // Opens the platform's invite dialog for this session; false when CanInviteFriends is false or the dialog can't open
        // (Steam: the overlay isn't hooked)
        bool TryOpenInviteDialog();
        // Online friends who aren't in this session yet, sorted by InvitableFriend.CompareForInvite; empty when CanInviteFriends is false
        void GetInvitableFriends(List<InvitableFriend> results);
        // Sends an invite to this session without the platform overlay; false when it couldn't be sent
        bool TryInviteFriend(ulong friendId);
        // The friend's platform profile picture as a new texture the caller owns; null when there is none (FriendAvatarCache keeps them)
        UniTask<Texture2D> LoadFriendAvatar(ulong friendId, CancellationToken token);
    }
}
