using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.SceneFlow;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Assets._Project._Scripts.Managers
{
    // Sends the local player back to the offline main menu whenever their session ends and keeps the reason for the menu to show
    public class SessionEndHandler : IDisposable
    {
        private readonly IConnectionService _connectionService;
        private readonly GameScenes _gameScenes;

        private string _lastDisconnectReason;

        public SessionEndHandler(IConnectionService connectionService, GameScenes gameScenes)
        {
            _connectionService = connectionService;
            _gameScenes = gameScenes;
            _connectionService.OnDisconnected += HandleDisconnected;
        }

        public string LastDisconnectReason => _lastDisconnectReason;

        public void ClearDisconnectReason() => _lastDisconnectReason = null;

        private void HandleDisconnected(string reason)
        {
            _lastDisconnectReason = reason;
            ReturnToMainMenu(Application.exitCancellationToken).Forget();
        }

        // Netcode also shuts down while the app quits or Play Mode stops, before the exit token is cancelled;
        // one frame later those cases are no longer playing (or never get the frame), so no scene is loaded then
        private async UniTaskVoid ReturnToMainMenu(CancellationToken token)
        {
            await UniTask.Yield(token);
            if (!Application.isPlaying) return;

            await SceneManager.LoadSceneAsync(_gameScenes.MainMenuSceneName, LoadSceneMode.Single);
        }

        public void Dispose() => _connectionService.OnDisconnected -= HandleDisconnected;
    }
}
