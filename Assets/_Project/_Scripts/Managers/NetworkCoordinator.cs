using Cysharp.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

namespace Project.Assets._Project._Scripts.Managers
{
    public class NetworkCoordinator : NetworkBehaviour, INetworkCoordinator
    {
        public async UniTask<Scene> LoadNetworkScene(string sceneNameToLoad, CancellationToken token, LoadSceneMode loadSceneMode = LoadSceneMode.Additive, bool setActiveScene = true)
        {
            var loadedScene = SceneManager.GetSceneByName(sceneNameToLoad);
            if (NetworkManager.Singleton == null || NetworkManager.Singleton.SceneManager == null)
            {
                EUtils.Logger.LogError("[NetworkCoordinator] NetworkManager or SceneManager is missing!");
                return loadedScene;
            }
            if (loadedScene.isLoaded)
            {
                if (setActiveScene) SceneManager.SetActiveScene(loadedScene);
                EUtils.Logger.LogWarning($"The Scene you tried to load is already Loaded");
                return loadedScene;
            }
            var status = NetworkManager.Singleton.SceneManager.LoadScene(sceneNameToLoad, loadSceneMode);

            if (status != SceneEventProgressStatus.Started)
            {
                EUtils.Logger.LogError($"Failed to load {sceneNameToLoad} scene");
                return loadedScene;
            }

            await UniTask.WaitUntil(() => SceneManager.GetSceneByName(sceneNameToLoad).isLoaded, cancellationToken: token);

            loadedScene = SceneManager.GetSceneByName(sceneNameToLoad);

            if (setActiveScene) SceneManager.SetActiveScene(loadedScene);

            return loadedScene;
        }

        public async UniTask<Scene> UnloadNetworkScene(string sceneNameToUnload, CancellationToken token)
        {
            var unloadedScene = SceneManager.GetSceneByName(sceneNameToUnload);
            if (NetworkManager.Singleton == null || NetworkManager.Singleton.SceneManager == null)
            {
                EUtils.Logger.LogError("[NetworkCoordinator] NetworkManager or SceneManager is missing!");
                return unloadedScene;
            }
            if (unloadedScene.IsValid())
            {
                var status = NetworkManager.Singleton.SceneManager.UnloadScene(unloadedScene);
                if (status != SceneEventProgressStatus.Started)
                {
                    EUtils.Logger.LogError($"Failed to unload scene: {unloadedScene.name}");
                    return unloadedScene;
                }
                await UniTask.WaitUntil(() => !unloadedScene.isLoaded, cancellationToken: token);
            }
            else
            {
                await UniTask.Yield(cancellationToken: token);
            }
            return unloadedScene;
        }

        public async UniTask LoadLobby(string lobbyScene, CancellationToken token)
        {
            await LoadNetworkScene(lobbyScene, token);
        }

        public async UniTask ReturnToLobby(string lobbyScene, string gameScene, CancellationToken token)
        {
            await LoadNetworkScene(lobbyScene, token);
            await UnloadNetworkScene(gameScene, token);
        }

        public async UniTask LoadGameplayScene(string gameScene, string lobbyScene, CancellationToken token)
        {
            await LoadNetworkScene(gameScene, token);
            await UnloadNetworkScene(lobbyScene, token);
        }
    }
}
