using Project.Assets._Project._Scripts.Managers;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI
{
    [RequireComponent(typeof(Canvas))]
    public class ServerStarterUI : MonoBehaviour
    {
        [field: SerializeField] public Button StartHostButton { get; private set; }
        [field: SerializeField] public Button StartClientButton { get; private set; }
        [Inject] private readonly IUIManager _uiManager;
        private Canvas _serverStarterCanvas;
        private void Awake()
        {
            _serverStarterCanvas = GetComponent<Canvas>();            
        }
        private void Start()
        {

            StartHostButton.onClick.AddListener(_uiManager.RaiseHostStart);
            StartClientButton.onClick.AddListener(_uiManager.RaiseClientStart);
        }


        private void OnDestroy()
        {
            StartHostButton.onClick.RemoveListener(_uiManager.RaiseHostStart);
            StartClientButton.onClick.RemoveListener(_uiManager.RaiseClientStart);
        }

        public void ToggleServerStarterUI(bool enabled)
        {
            _serverStarterCanvas.enabled = enabled;
        }
    }
}
