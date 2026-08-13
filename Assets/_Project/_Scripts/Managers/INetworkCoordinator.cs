using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using System.Threading;

namespace Project.Assets._Project._Scripts.Managers
{
    public interface INetworkCoordinator
    {
        UniTask<Scene> LoadNetworkScene(string sceneNameToLoad, CancellationToken token, LoadSceneMode loadSceneMode = LoadSceneMode.Additive, bool setActiveScene = true);
        UniTask<Scene> UnloadNetworkScene(string sceneNameToUnload, CancellationToken token);
        UniTask LoadLobby(string lobbyScene, CancellationToken token);
        UniTask ReturnToLobby(string lobbyScene, string gameScene, CancellationToken token);
        UniTask LoadGameplayScene(string gameScene, string lobbyScene, CancellationToken token);
    }
}
