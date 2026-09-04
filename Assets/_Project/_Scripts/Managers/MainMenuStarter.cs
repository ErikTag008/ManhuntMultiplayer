using Alchemy.Inspector;
using Assets._Project._Scripts.SceneReference;
using Cysharp.Threading.Tasks;
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
        [SerializeField, AssetsOnly] private NetworkObject _gameSystemsPrefab;
        private void Start()
        {
            _sceneLifecycleManager.InitializeScene(SceneType.MainMenu);
            _uiManager.OnHostStart += HandleHostStart;
            _uiManager.OnClientStart += HandleClientStart;
        }
        private void HandleClientStart()
        {
            NetworkManager.Singleton.StartClient();
            _serverStarterUI.ToggleServerStarterUI(false);
            //UnloadMainMenu().Forget();
        }

        private void HandleHostStart()
        {
            NetworkManager.Singleton.StartHost();
            SpawnGameSystems();
            _serverStarterUI.ToggleServerStarterUI(false);
            UnloadMainMenu().Forget();
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
