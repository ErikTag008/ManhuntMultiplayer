using Reflex.Attributes;
using TMPro;
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
        [SerializeField] private TMP_Text _disconnectReasonText;
        // Netcode's reasons already read as sentences ("Disconnected due to host shutting down."), so no prefix by default
        [SerializeField] private string _disconnectReasonFormat = "{0}";
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

        // An empty reason hides the label
        public void ShowDisconnectReason(string reason)
        {
            var hasReason = !string.IsNullOrEmpty(reason);
            _disconnectReasonText.gameObject.SetActive(hasReason);
            _disconnectReasonText.text = hasReason ? string.Format(_disconnectReasonFormat, reason) : string.Empty;
        }
    }
}
