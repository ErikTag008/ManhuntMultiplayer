using Alchemy.Inspector;
using Assets._Project._Scripts.SceneReference;
using Cysharp.Threading.Tasks;
using Project.Assets._Project._Scripts.Networking;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.UI;
using Reflex.Attributes;
using System.Threading;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Assets._Project._Scripts.Managers
{
    public class MainMenuStarter : MonoBehaviour
    {
        [Inject] private readonly ServerStarterUI _serverStarterUI;
        [Inject] private readonly SceneLifecycleManager _sceneLifecycleManager;
        [Inject] private readonly IUIManager _uiManager;
        [Inject] private readonly GameScenes _gameScenes;
        [Inject] private readonly IConnectionService _connectionService;
        [Inject] private readonly ConnectionSettings _connectionSettings;
        [SerializeField, AssetsOnly] private NetworkObject _gameSystemsPrefab;
        private void Start()
        {
            _sceneLifecycleManager.InitializeScene(SceneType.MainMenu);
            _uiManager.OnHostStart += HandleHostStart;
            _uiManager.OnClientStart += HandleClientStart;
        }
        // App-lifetime token: a successful join unloads this scene during Netcode's scene sync
        private void HandleClientStart() => JoinSession(Application.exitCancellationToken).Forget();

        private void HandleHostStart() => HostSession(Application.exitCancellationToken).Forget();

        private async UniTaskVoid HostSession(CancellationToken token)
        {
            _serverStarterUI.ToggleServerStarterUI(false);
            var isHosting = await _connectionService.Host(_connectionSettings.DefaultLobbyVisibility, token);
            if (this == null) return;

            if (!isHosting)
            {
                _serverStarterUI.ToggleServerStarterUI(true);
                return;
            }

            SpawnGameSystems();
            UnloadMainMenu().Forget();
        }

        private async UniTaskVoid JoinSession(CancellationToken token)
        {
            _serverStarterUI.ToggleServerStarterUI(false);
            if (!await _connectionService.Join(_connectionSettings.Address, token))
            {
                if (this == null) return;
                _serverStarterUI.ToggleServerStarterUI(true);
            }
        }

        private async UniTaskVoid UnloadMainMenu()
        {
            await UniTask.WaitUntil(() => SceneManager.GetActiveScene().name != _gameScenes.MainMenuSceneName);

            var scene = SceneManager.GetSceneByName(_gameScenes.MainMenuSceneName);

            if (!scene.IsValid())
            {
                EUtils.Logger.LogWarning($"Scene '{_gameScenes.MainMenuSceneName}' is no longer valid.");
                return;
            }

            if (!scene.isLoaded)
            {
                EUtils.Logger.LogWarning($"Scene '{_gameScenes.MainMenuSceneName}' is already unloaded.");
                return;
            }

            await SceneManager.UnloadSceneAsync(scene);
        }

        private void SpawnGameSystems()
        {
            if (!NetworkManager.Singleton.IsServer) return;
            NetworkManager.Singleton.SpawnManager.InstantiateAndSpawn(_gameSystemsPrefab);
        }
        

        private void OnDestroy()
        {
            _uiManager.OnHostStart -= HandleHostStart;
            _uiManager.OnClientStart -= HandleClientStart;
        }
    }
}
