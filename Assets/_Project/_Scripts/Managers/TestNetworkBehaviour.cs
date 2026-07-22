using Alchemy.Inspector;
using Unity.Netcode;

namespace Project.Assets._Project._Scripts.Managers
{
    public class TestNetworkBehaviour : NetworkBehaviour
    {
        [ReadOnly]
        public string Test = "Hello";
    }
}
