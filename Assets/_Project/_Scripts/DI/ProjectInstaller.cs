using Alchemy.Inspector;
using Project.Assets._Project._Scripts.Managers;
using Project.Assets._Project._Scripts.Player;
using Reflex.Core;
using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.DI
{
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField, AssetsOnly] private PlayerStats _playerStats;
        [SerializeField, AssetsOnly] private GameLobbySettings _gameLobbySettings;
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.RegisterFactory(p => _playerStats, new Type[] { typeof(PlayerStats), typeof(IMovementStats), typeof(ICameraStats) },Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
            builder.RegisterValue(_gameLobbySettings);
        }
    }
}
