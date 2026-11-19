using KBCore.Refs;
using Project.Assets._Project._Scripts.CameraUtils;
using Project.Assets._Project._Scripts.SceneFlow;
using Project.Assets._Project._Scripts.UI;
using Reflex.Attributes;
using Reflex.Core;
using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.DI
{
    public class GameplaySceneInstaller : ValidatedMonoBehaviour, IInstaller, ISceneContext, IMapBoundsReceiver
    {
        [SerializeField] private Camera _gameplayCamera;
        [SerializeField, Scene] private FPCameraInstaller _fpcameraInstaller;
        [SerializeField, Scene] private SpectatorCamera _spectatorCamera;
        // optional: without it ghosts can fly anywhere; a bundle map sets its own once it's placed
        [SerializeField, Scene(Flag.Optional)] private MapBounds _mapBounds;

        private ActiveCameraProvider _activeCameraProvider;
        private SceneContextProvider _sceneContextProvider;

        public SceneType SceneType => SceneType.Gameplay;
        public Camera GameplayCamera => _gameplayCamera;
        public FPCameraInstaller FPCameraInstaller => _fpcameraInstaller;
        public SpectatorCamera SpectatorCamera => _spectatorCamera;
        public ILobbyUI LobbyUI => null;
        public MapBounds MapBounds => _mapBounds;

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
            builder.RegisterValue(this, new Type[] { typeof(IMapBoundsReceiver) });
        }

        public void SetMapBounds(MapBounds mapBounds)
        {
            _mapBounds = mapBounds;
            _sceneContextProvider?.NotifyMapBoundsChanged(this);
        }

        private void OnDestroy()
        {
            _activeCameraProvider?.Unregister(_gameplayCamera);
            _sceneContextProvider?.Unregister(this);
        }
    }
}
