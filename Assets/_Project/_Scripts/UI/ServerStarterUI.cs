using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI
{
    public class ServerStarterUI : MonoBehaviour
    {
        [field: SerializeField] public Button StartHostButton { get; private set; }
        [field: SerializeField] public Button StartClientButton { get; private set; }
    }
}
