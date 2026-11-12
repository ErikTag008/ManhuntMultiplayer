using Alchemy.Inspector;
using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.UI;
using Reflex.Attributes;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    public class MainMenuStarter : MonoBehaviour
    {
        [Inject] private readonly ServerStarterUI _serverStarterUI;
        [Inject] private readonly SceneLifecycleManager _sceneLifecycleManager;
        [Inject] private readonly IUIManager _uiManager;
        [Inject] private readonly IConnectionService _connectionService;
        [Inject] private readonly ConnectionSettings _connectionSettings;
        [Inject] private readonly SessionEndHandler _sessionEndHandler;
        [SerializeField, AssetsOnly] private NetworkObject _gameSystemsPrefab;

        private void Start()
        {
            _sceneLifecycleManager.InitializeScene(SceneType.MainMenu);
            _serverStarterUI.ShowDisconnectReason(_sessionEndHandler.LastDisconnectReason);
            _uiManager.OnHostStart += HandleHostStart;
            _uiManager.OnClientStart += HandleClientStart;
        }

        // App-lifetime token: a successful join replaces this scene during Netcode's scene sync
        private void HandleClientStart() => JoinSession(Application.exitCancellationToken).Forget();

        private void HandleHostStart() => HostSession(Application.exitCancellationToken).Forget();

        private async UniTaskVoid HostSession(CancellationToken token)
        {
            ClearDisconnectReason();
            _serverStarterUI.ToggleServerStarterUI(false);
            var isHosting = await _connectionService.Host(_connectionSettings.DefaultLobbyVisibility, token);
            if (this == null) return;

            if (!isHosting)
            {
                _serverStarterUI.ToggleServerStarterUI(true);
                return;
            }

            // the game loop on GameSystems loads the lobby in Single mode, which replaces this scene
            SpawnGameSystems();
        }

        private async UniTaskVoid JoinSession(CancellationToken token)
        {
            ClearDisconnectReason();
            _serverStarterUI.ToggleServerStarterUI(false);
            if (!await _connectionService.Join(_connectionSettings.Address, token))
            {
                if (this == null) return;
                _serverStarterUI.ToggleServerStarterUI(true);
            }
        }

        private void ClearDisconnectReason()
        {
            _sessionEndHandler.ClearDisconnectReason();
            _serverStarterUI.ShowDisconnectReason(null);
        }

        // destroyWithScene: false keeps GameSystems alive across Single-mode scene loads
        private void SpawnGameSystems()
        {
            if (!NetworkManager.Singleton.IsServer) return;
            NetworkManager.Singleton.SpawnManager.InstantiateAndSpawn(_gameSystemsPrefab, destroyWithScene: false);
        }

        private void OnDestroy()
        {
            _uiManager.OnHostStart -= HandleHostStart;
            _uiManager.OnClientStart -= HandleClientStart;
        }
    }
}
