using Gilzoide.UpdateManager;
using Reflex.Attributes;
using UnityEngine;

namespace Project.Assets._Project._Scripts.CameraUtils
{
    public class AudioListenerFollower : AManagedBehaviour, IUpdatable
    {
        [Inject] private readonly ActiveCameraProvider _activeCameraProvider;

        public void ManagedUpdate()
        {
            var activeCamera = _activeCameraProvider.Current;
            if (activeCamera == null) return;

            transform.SetPositionAndRotation(activeCamera.transform.position, activeCamera.transform.rotation);
        }
    }
}
