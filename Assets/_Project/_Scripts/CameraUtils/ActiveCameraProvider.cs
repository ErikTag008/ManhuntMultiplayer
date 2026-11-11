using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.CameraUtils
{
    public class ActiveCameraProvider
    {
        private readonly List<Camera> _cameras = new();

        public Camera Current => _cameras.Count > 0 ? _cameras[^1] : null;

        public void Register(Camera camera)
        {
            if (camera == null) return;
            _cameras.Remove(camera);
            _cameras.Add(camera);
        }

        public void Unregister(Camera camera) => _cameras.Remove(camera);
    }
}
