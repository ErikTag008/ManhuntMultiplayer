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
        [SerializeField, AssetsOnly] private NetworkObject _gameManager;
        [SerializeField, SceneReference] private string _mainMenuScene;
        [Inject] private ServerStarterUI _serverStarterUI;
        [Inject] private readonly SceneLifecycleManager _sceneLifecycleManager;
        [Inject] private readonly UIManager _uiManager;
        private readonly CancellationTokenSource _unloadCTS = new();

        private Scene _currentScene;

        private void Start()
        {
            _sceneLifecycleManager.InitializeScene(SceneType.MainMenu);
            _mainMenuScene = System.IO.Path.GetFileNameWithoutExtension(_mainMenuScene);
            _currentScene = SceneManager.GetActiveScene();
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
            SpawnGameManager();
            _serverStarterUI.ToggleServerStarterUI(false);
            UnloadMainMenu().Forget();
        }

        private async UniTaskVoid UnloadMainMenu()
        {
            await UniTask.WaitUntil(() => SceneManager.GetActiveScene().name != _mainMenuScene);

            var scene = SceneManager.GetSceneByName(_mainMenuScene);

            if (!scene.IsValid())
            {
                Debug.LogWarning($"Scene '{_mainMenuScene}' is no longer valid.");
                return;
            }

            if (!scene.isLoaded)
            {
                Debug.LogWarning($"Scene '{_mainMenuScene}' is already unloaded.");
                return;
            }

            await SceneManager.UnloadSceneAsync(scene);
        }


        private void SpawnGameManager()
        {
            if (!NetworkManager.Singleton.IsServer)
                return;

            NetworkManager.Singleton.SpawnManager.InstantiateAndSpawn(_gameManager);
        }

        private void OnDestroy()
        {
            _uiManager.OnHostStart -= HandleHostStart;
            _uiManager.OnClientStart -= HandleClientStart;
        }
    }
}
