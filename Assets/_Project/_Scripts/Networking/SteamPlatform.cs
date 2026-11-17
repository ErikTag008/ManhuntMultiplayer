using Cysharp.Threading.Tasks;
using Steamworks;
using Steamworks.Data;
using System;
using System.Threading;

namespace Project.Assets._Project._Scripts.Networking
{
    // Owns the Steam client for the app's lifetime in Steam mode: init once, pump callbacks every frame, shut down on quit.
    // Nothing else may init or shut down SteamClient, so lobbies and invites survive leaving a session.
    public class SteamPlatform : IDisposable
    {
        private readonly ConnectionSettings _settings;

        // the friend's lobby id when they asked to join through the overlay or friends list
        public event Action<ulong> OnLobbyJoinRequested;

        private CancellationTokenSource _callbacksCTS;
        private bool _isReady;
        private ulong _localSteamId;
        private string _localName;
        private string _failureReason;
        private ulong _pendingLobbyId;
        private Lobby? _currentLobby;

        public SteamPlatform(ConnectionSettings settings)
        {
            _settings = settings;
            if (_settings.ResolvedMode != ConnectionMode.Steam) return;

            Initialize();
        }

        public bool IsReady => _isReady;
        public ulong LocalSteamId => _localSteamId;
        public string LocalName => _localName;
        // Why Steam isn't ready, for the menu to show; null when it is (or when not in Steam mode)
        public string FailureReason => _failureReason;
        // The Steam lobby this player is in, kept by SteamConnectionService; SteamLobbyDirectory updates the hosted one's data
        public Lobby? CurrentLobby => _currentLobby;

        public void SetCurrentLobby(Lobby? lobby) => _currentLobby = lobby;

        // The lobby from the "+connect_lobby" launch argument, handed out once
        public bool TryTakePendingLobbyId(out ulong lobbyId)
        {
            lobbyId = _pendingLobbyId;
            _pendingLobbyId = 0;
            return lobbyId != 0;
        }

        private void Initialize()
        {
            try
            {
                // asyncCallbacks off: PumpCallbacks runs them on the main thread
                if (!SteamClient.IsValid) SteamClient.Init(_settings.SteamAppId, false);
            }
            catch (Exception exception)
            {
                _failureReason = _settings.SteamNotRunningReason;
                EUtils.Logger.LogWarning($"[SteamPlatform] Steam could not start: {exception.Message}");
                return;
            }

            _isReady = true;
            _localSteamId = SteamClient.SteamId.Value;
            _localName = SteamClient.Name;
            SteamNetworkingUtils.InitRelayNetworkAccess();
            SteamFriends.OnGameLobbyJoinRequested += HandleGameLobbyJoinRequested;
            if (SteamLobbyId.TryFindInLaunchArgs(Environment.GetCommandLineArgs(), out var launchLobbyId)) _pendingLobbyId = launchLobbyId;

            _callbacksCTS = new();
            PumpCallbacks(_callbacksCTS.Token).Forget();
            EUtils.Logger.Log($"[SteamPlatform] Steam ready as {_localName} ({_localSteamId}).");
        }

        private async UniTaskVoid PumpCallbacks(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                // a throwing handler must not stop the pump, or Steam goes quiet for the rest of the app
                try
                {
                    SteamClient.RunCallbacks();
                }
                catch (Exception exception)
                {
                    EUtils.Logger.LogError($"[SteamPlatform] A Steam callback failed: {exception}");
                }
                // EarlyUpdate like the original transport, so connect/disconnect events reach Netcode before its own update
                await UniTask.Yield(PlayerLoopTiming.EarlyUpdate, token);
            }
        }

        // only the main menu listens, so a request that arrives during a session is dropped instead of leaving it
        private void HandleGameLobbyJoinRequested(Lobby lobby, SteamId friendId)
        {
            if (OnLobbyJoinRequested == null)
            {
                EUtils.Logger.Log($"[SteamPlatform] Ignored the request to join lobby {lobby.Id.Value}: already in a session.");
                return;
            }

            OnLobbyJoinRequested.Invoke(lobby.Id.Value);
        }

        private void Shutdown()
        {
            if (!_isReady) return;

            _isReady = false;
            _currentLobby = null;
            _callbacksCTS?.Cancel();
            _callbacksCTS?.Dispose();
            _callbacksCTS = null;
            SteamFriends.OnGameLobbyJoinRequested -= HandleGameLobbyJoinRequested;
            SteamClient.Shutdown();
            EUtils.Logger.Log("[SteamPlatform] Steam shut down.");
        }

        // Reflex disposes the project container on Application.quitting
        public void Dispose() => Shutdown();
    }
}
