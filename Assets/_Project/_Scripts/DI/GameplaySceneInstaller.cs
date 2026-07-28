using KBCore.Refs;
using Project.Assets._Project._Scripts.CameraUtils;
using Reflex.Core;
using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.DI
{
    public class GameplaySceneInstaller : ValidatedMonoBehaviour, IInstaller
    {
        [SerializeField] private Camera _gameplayCamera;
        [SerializeField, Scene] private FPCameraInstaller _fpcameraInstaller;

        public void InstallBindings(ContainerBuilder builder)
        {
            builder.RegisterValue(_gameplayCamera);
            builder.RegisterValue(_fpcameraInstaller);
        }
    }

}


