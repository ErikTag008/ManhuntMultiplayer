using KBCore.Refs;
using Project.Assets._Project._Scripts.CameraUtils;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.UI;
using Reflex.Attributes;
using Reflex.Core;
using UnityEngine;

namespace Project.Assets._Project._Scripts.DI
{
    public class GameplaySceneInstaller : ValidatedMonoBehaviour, IInstaller, ISceneContext
    {
        [SerializeField] private Camera _gameplayCamera;
        [SerializeField, Scene] private FPCameraInstaller _fpcameraInstaller;

        private ActiveCameraProvider _activeCameraProvider;
        private SceneContextProvider _sceneContextProvider;

        public SceneType SceneType => SceneType.Gameplay;
        public Camera GameplayCamera => _gameplayCamera;
        public FPCameraInstaller FPCameraInstaller => _fpcameraInstaller;
        public ILobbyUI LobbyUI => null;

        [Inject]
        private void RegisterActiveCamera(ActiveCameraProvider activeCameraProvider)
        {
            _activeCameraProvider = activeCameraProvider;
            _activeCameraProvider.Register(_gameplayCamera);
        }

        [Inject]
        private void RegisterSceneContext(SceneContextProvider sceneContextProvider)
        {
            _sceneContextProvider = sceneContextProvider;
            _sceneContextProvider.Register(this);
        }

        public void InstallBindings(ContainerBuilder builder)
        {
            builder.RegisterValue(_gameplayCamera);
            builder.RegisterValue(_fpcameraInstaller);
        }

        private void OnDestroy()
        {
            _activeCameraProvider?.Unregister(_gameplayCamera);
            _sceneContextProvider?.Unregister(this);
        }
    }
}
