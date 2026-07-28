using Project.Assets._Project._Scripts.UI;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    public class UIManager : MonoBehaviour, ISceneInitialized
    {
        [Inject] private readonly SceneLifecycleManager _sceneLifecycleManager;
        [Inject] private readonly ServerStarterUI _serverStarterUI;
        private Canvas _serverStarterUICanvas;
        public event Action OnHostStart;
        public event Action OnClientStart;

        

        private void Awake()
        {
            _sceneLifecycleManager.Register(this);
        }

        private void InitializeMainMenuReferences()
        {
            _serverStarterUICanvas = _serverStarterUI.GetComponent<Canvas>();
            _serverStarterUI.StartHostButton.onClick.AddListener(() => OnHostStart?.Invoke());
            _serverStarterUI.StartClientButton.onClick.AddListener(() => OnClientStart?.Invoke());
        }
        private void ClearMainMenuReferences()
        {
            _serverStarterUI?.StartHostButton.onClick.RemoveAllListeners();
            _serverStarterUI?.StartClientButton.onClick.RemoveAllListeners();
            _serverStarterUICanvas = null;
        }

        public void InitializeSceneReferences(SceneType scene)
        {
            switch (scene)
            {
                case SceneType.MainMenu:
                    InitializeMainMenuReferences();
                    break;
                case SceneType.Lobby:
                    break;
                case SceneType.Gameplay:
                    break;
            }
        }

        public void ClearSceneReferences(SceneType scene)
        {
            switch (scene)
            {
                case SceneType.MainMenu:
                    ClearMainMenuReferences();
                    break;
                case SceneType.Lobby:
                    break;
                case SceneType.Gameplay:
                    break;
            }
        }

        public void ToggleServerStarterUI(bool enabled)
        {
            _serverStarterUICanvas.enabled = enabled;
        }

        private void OnDestroy()
        {
            _sceneLifecycleManager.Unregister(this);
        }
    }
}
