using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Networking
{
    // NetworkManager moves itself to DontDestroyOnLoad, so reloading the main menu would add a second one.
    // Runs before NetworkManager so the duplicate is deactivated before its Awake/OnEnable ever run.
    [DefaultExecutionOrder(RunBeforeNetworkManager)]
    [RequireComponent(typeof(NetworkManager))]
    public class NetworkManagerDuplicateGuard : MonoBehaviour
    {
        private const int RunBeforeNetworkManager = -1000;

        private void Awake()
        {
            if (NetworkManager.Singleton != null && NetworkManager.Singleton.gameObject != gameObject)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
