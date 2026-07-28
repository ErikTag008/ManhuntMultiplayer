using KBCore.Refs;
using Project.Assets._Project._Scripts.CameraUtils;
using Reflex.Core;
using UnityEngine;

namespace Project.Assets._Project._Scripts.DI
{
    public class LobbySceneInstaller : ValidatedMonoBehaviour, IInstaller
    {
        [SerializeField, Scene] private Camera _gameplayCamera;
        [SerializeField, Scene] private FPCameraInstaller _fpcameraInstaller;

        public void InstallBindings(ContainerBuilder builder)
        {
            builder.RegisterValue(_gameplayCamera);
            builder.RegisterValue(_fpcameraInstaller);
        }
    }

}


