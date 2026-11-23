using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.UI.HUD;
using System;

namespace Project.Assets._Project._Scripts.Managers
{
    // Queues friends' lobby invites for the in-game popup and follows an accepted one: from the main menu it joins at once;
    // inside a session it leaves first, and the main menu joins the invited lobby when it loads
    public class LobbyInviteHandler : IDisposable
    {
        private readonly SteamPlatform _steamPlatform;
        private readonly IncomingInviteState _inviteState;
        private readonly IConnectionService _connectionService;

        public LobbyInviteHandler(SteamPlatform steamPlatform, IncomingInviteState inviteState, IConnectionService connectionService)
        {
            _steamPlatform = steamPlatform;
            _inviteState = inviteState;
            _connectionService = connectionService;
            _steamPlatform.OnLobbyInviteReceived += _inviteState.Add;
            _inviteState.OnAccepted += HandleAccepted;
        }

        private void HandleAccepted(LobbyInvite invite)
        {
            _steamPlatform.RequestLobbyJoin(invite.LobbyId);
            if (_connectionService.IsConnected) _connectionService.Leave();
        }

        public void Dispose()
        {
            _steamPlatform.OnLobbyInviteReceived -= _inviteState.Add;
            _inviteState.OnAccepted -= HandleAccepted;
        }
    }
}
