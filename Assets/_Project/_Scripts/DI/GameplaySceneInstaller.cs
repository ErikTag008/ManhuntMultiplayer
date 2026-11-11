using KBCore.Refs;
using Project.Assets._Project._Scripts.CameraUtils;
using Reflex.Attributes;
using Reflex.Core;
using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.DI
{
    public class GameplaySceneInstaller : ValidatedMonoBehaviour, IInstaller
    {
        [SerializeField] private Camera _gameplayCamera;
        [SerializeField, Scene] private FPCameraInstaller _fpcameraInstaller;

        private ActiveCameraProvider _activeCameraProvider;

        [Inject]
        private void RegisterActiveCamera(ActiveCameraProvider activeCameraProvider)
        {
            _activeCameraProvider = activeCameraProvider;
            _activeCameraProvider.Register(_gameplayCamera);
        }

        public void InstallBindings(ContainerBuilder builder)
        {
            builder.RegisterValue(_gameplayCamera);
            builder.RegisterValue(_fpcameraInstaller);
        }

        private void OnDestroy() => _activeCameraProvider?.Unregister(_gameplayCamera);
    }
}
