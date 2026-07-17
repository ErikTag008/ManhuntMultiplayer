using UnityEngine;
using Reflex.Core;
using KBCore.Refs;

namespace Project.Assets._Project._Scripts.DIInstallers
{
    public class SceneInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private UnityEngine.Camera _camera;

        public void InstallBindings(ContainerBuilder builder)
        {
            builder.RegisterValue(_camera);
        }
    }
}
