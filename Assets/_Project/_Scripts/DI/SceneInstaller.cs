using KBCore.Refs;
using Project.Assets._Project._Scripts.Managers;
using Project.Assets._Project._Scripts.UI;
using Reflex.Core;
using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.DI
{
    public class SceneInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Camera _gameplayCamera;
        [SerializeField, Scene] private ServerStarterUI _serverStarterUI;
        [SerializeField, Scene] private UIManager _uiManager;
        [SerializeField, Scene] private GameManager _gameManager;

        public void InstallBindings(ContainerBuilder builder)
        {

            builder.RegisterValue(_mainCamera);
            builder.RegisterValue(new GameplayCamera(_gameplayCamera));
            builder.RegisterValue(_serverStarterUI);
            builder.RegisterValue(_uiManager);
            builder.RegisterFactory(n => _gameManager, new Type[] { typeof(IPlayerRegistry) }, Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
        }
    }

}


