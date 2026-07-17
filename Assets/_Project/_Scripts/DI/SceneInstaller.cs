using UnityEngine;
using Reflex.Core;
using KBCore.Refs;
using Project.Assets._Project._Scripts.UI;
using Project.Assets._Project._Scripts.Managers;

namespace Project.Assets._Project._Scripts.DI
{
    public class SceneInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Camera _gameplayCamera;
        
        [SerializeField, Scene] private ServerStarterUI _serverStarterUI;
        [SerializeField, Scene] private UIManager _uiManager;

        public void InstallBindings(ContainerBuilder builder)
        {

            builder.RegisterValue(_mainCamera);
            builder.RegisterValue(new GameplayCamera(_gameplayCamera));
            builder.RegisterValue(_serverStarterUI);
            builder.RegisterValue(_uiManager);
        }
    }
}
