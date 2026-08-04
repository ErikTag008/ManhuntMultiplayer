using Project.Assets._Project._Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI
{
    [RequireComponent(typeof(Canvas))]
    public class ServerStarterUI : MonoBehaviour
    {
        [field: SerializeField] public Button StartHostButton { get; private set; }
        [field: SerializeField] public Button StartClientButton { get; private set; }
        private Canvas _serverStarterCanvas;
        private void Awake()
        {
            _serverStarterCanvas = GetComponent<Canvas>();            
        }
        private void Start()
        {

            StartHostButton.onClick.AddListener(UIManager.Instance.RaiseHostStart);
            StartClientButton.onClick.AddListener(UIManager.Instance.RaiseClientStart);
        }


        private void OnDestroy()
        {
            StartHostButton.onClick.RemoveListener(UIManager.Instance.RaiseHostStart);
            StartClientButton.onClick.RemoveListener(UIManager.Instance.RaiseClientStart);
        }

        public void ToggleServerStarterUI(bool enabled)
        {
            _serverStarterCanvas.enabled = enabled;
        }
    }
}
