using KBCore.Refs;
using Project.Assets._Project._Scripts.CameraUtils;
using Project.Assets._Project._Scripts.UI;
using Reflex.Core;
using Reflex.Enums;
using UnityEngine;

namespace Project.Assets._Project._Scripts.DI
{
    public class LobbySceneInstaller : ValidatedMonoBehaviour, IInstaller
    {
        [SerializeField, Scene] private Camera _gameplayCamera;
        [SerializeField, Scene] private FPCameraInstaller _fpcameraInstaller;
        [SerializeField, Scene] private LobbyUI _lobbyUI;

        public void InstallBindings(ContainerBuilder builder)
        {
            builder.RegisterFactory(p => _lobbyUI, new[] { typeof(ILobbyUI) }, Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            builder.RegisterValue(_gameplayCamera);
            builder.RegisterValue(_fpcameraInstaller);
        }
    }

}


