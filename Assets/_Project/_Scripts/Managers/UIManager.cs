using Project.Assets._Project._Scripts.UI;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        [Inject] private readonly ServerStarterUI _serverStarterUI;
        private Canvas _serverStarterUICanvas;
        public event Action OnHostStart;
        public event Action OnClientStart;

        private void Awake()
        {
            _serverStarterUICanvas = _serverStarterUI.GetComponent<Canvas>();
            _serverStarterUI.StartHostButton.onClick.AddListener(() => OnHostStart?.Invoke());
            _serverStarterUI.StartClientButton.onClick.AddListener(() => OnClientStart?.Invoke());
        }

        public void ToggleServerStarterUI(bool enabled)
        {
            _serverStarterUICanvas.enabled = enabled;
        }

        private void OnDestroy()
        {
            _serverStarterUI.StartHostButton.onClick.RemoveAllListeners();
            _serverStarterUI.StartClientButton.onClick.RemoveAllListeners();
        }
    }
}
