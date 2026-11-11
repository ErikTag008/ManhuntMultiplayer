using KBCore.Refs;
using Project.Assets._Project._Scripts.CameraUtils;
using Project.Assets._Project._Scripts.UI;
using Reflex.Attributes;
using Reflex.Core;
using UnityEngine;

namespace Project.Assets._Project._Scripts.DI
{
    public class MainMenuSceneInstaller : ValidatedMonoBehaviour, IInstaller
    {
        [SerializeField, Scene] private Camera _mainCamera;
        [SerializeField, Scene] private ServerStarterUI _serverStarterUI;
        private ActiveCameraProvider _activeCameraProvider;

        [Inject]
        private void RegisterActiveCamera(ActiveCameraProvider activeCameraProvider)
        {
            _activeCameraProvider = activeCameraProvider;
            _activeCameraProvider.Register(_mainCamera);
        }

        public void InstallBindings(ContainerBuilder builder)
        {
            builder.RegisterValue(_mainCamera);
            builder.RegisterValue(_serverStarterUI);
        }

        private void OnDestroy() => _activeCameraProvider?.Unregister(_mainCamera);
    }
}
