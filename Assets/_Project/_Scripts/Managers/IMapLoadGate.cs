using Cysharp.Threading.Tasks;
using System.Threading;

namespace Project.Assets._Project._Scripts.Managers
{
    // Server: holds a round back after its scene loaded until the map is ready everywhere; false means the round can't start.
    // Only maps placed at runtime (bundle maps) register one.
    public interface IMapLoadGate
    {
        UniTask<bool> WaitUntilReady(CancellationToken token);
    }
}
