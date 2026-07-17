using Project.Assets._Project._Scripts.Player;
using Reflex.Core;
using System;
using UnityEngine;

namespace Project.Assets._Project._Scripts.DI
{
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private PlayerStats _playerStats;
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.RegisterFactory(p => _playerStats, new Type[] { typeof(PlayerStats), typeof(IMovementStats), typeof(ICameraStats) },Reflex.Enums.Lifetime.Singleton, Reflex.Enums.Resolution.Lazy);
        }
    }
}
