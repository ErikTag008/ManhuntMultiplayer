using Gilzoide.UpdateManager;
using UnityEngine;

namespace Project.Assets._Project._Scripts.CameraUtils
{
    public class AudioListenerFollower : AManagedBehaviour, IUpdatable
    {
        public void ManagedUpdate()
        {
            if (Camera.main != null)
            {
                transform.SetPositionAndRotation(Camera.main.transform.position, Camera.main.transform.rotation);
            }
        }
    }
}
