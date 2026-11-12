using Cysharp.Threading.Tasks;
using System.Threading;

namespace Project.Assets._Project._Scripts.Managers
{
    public interface INetworkCoordinator
    {
        // Replaces the current scene for every connected client; completes once all clients loaded it or timed out
        UniTask LoadNetworkScene(string sceneName, CancellationToken token);
    }
}
