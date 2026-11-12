using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using System.Collections.Generic;
using System.Threading;
using Unity.Netcode;
using UnityEngine.SceneManagement;

namespace Project.Assets._Project._Scripts.Managers
{
    public class NetworkCoordinator : NetworkBehaviour, INetworkCoordinator
    {
        private GameSystemsRegistry _gameSystemsRegistry;

        [Inject]
        private void RegisterInGameSystems(GameSystemsRegistry gameSystemsRegistry)
        {
            _gameSystemsRegistry = gameSystemsRegistry;
            _gameSystemsRegistry.Register(this);
        }

        // Single mode: spawned objects with DestroyWithScene = false (GameSystems, players) survive the switch
        public async UniTask LoadNetworkScene(string sceneName, CancellationToken token)
        {
            var sceneManager = NetworkManager != null ? NetworkManager.SceneManager : null;
            if (sceneManager == null)
            {
                EUtils.Logger.LogError("[NetworkCoordinator] NetworkManager or its SceneManager is missing!");
                return;
            }

            var loadCompleted = new UniTaskCompletionSource();
            void HandleLoadEventCompleted(string loadedSceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
            {
                if (loadedSceneName != sceneName) return;

                if (clientsTimedOut.Count > 0)
                {
                    EUtils.Logger.LogWarning($"[NetworkCoordinator] Clients timed out loading {sceneName}: {string.Join(", ", clientsTimedOut)}");
                }
                loadCompleted.TrySetResult();
            }

            sceneManager.OnLoadEventCompleted += HandleLoadEventCompleted;
            try
            {
                var status = sceneManager.LoadScene(sceneName, LoadSceneMode.Single);
                if (status != SceneEventProgressStatus.Started)
                {
                    EUtils.Logger.LogError($"[NetworkCoordinator] Failed to load {sceneName}: {status}");
                    return;
                }

                await loadCompleted.Task.AttachExternalCancellation(token);
            }
            finally
            {
                sceneManager.OnLoadEventCompleted -= HandleLoadEventCompleted;
            }
        }

        public override void OnDestroy()
        {
            _gameSystemsRegistry?.Unregister(this);
            base.OnDestroy();
        }
    }
}
