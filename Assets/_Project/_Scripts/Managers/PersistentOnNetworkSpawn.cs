using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    public class PersistentOnNetworkSpawn : NetworkBehaviour
    {
        public override void OnNetworkSpawn()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
