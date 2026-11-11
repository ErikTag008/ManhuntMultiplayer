using NUnit.Framework;
using Project.Assets._Project._Scripts.CameraUtils;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class ActiveCameraProviderTests
    {
        private readonly List<GameObject> _createdObjects = new();

        [TearDown]
        public void TearDown()
        {
            foreach (var createdObject in _createdObjects)
                Object.DestroyImmediate(createdObject);
            _createdObjects.Clear();
        }

        [Test]
        public void Current_IsLastRegistered()
        {
            var provider = new ActiveCameraProvider();
            var first = CreateCamera();
            var second = CreateCamera();

            provider.Register(first);
            provider.Register(second);

            Assert.AreSame(second, provider.Current);
        }

        [Test]
        public void Unregister_Current_FallsBackToPrevious()
        {
            var provider = new ActiveCameraProvider();
            var first = CreateCamera();
            var second = CreateCamera();
            provider.Register(first);
            provider.Register(second);

            provider.Unregister(second);

            Assert.AreSame(first, provider.Current);
        }

        [Test]
        public void Unregister_NonCurrent_KeepsCurrent()
        {
            var provider = new ActiveCameraProvider();
            var first = CreateCamera();
            var second = CreateCamera();
            provider.Register(first);
            provider.Register(second);

            provider.Unregister(first);

            Assert.AreSame(second, provider.Current);
        }

        [Test]
        public void Register_SameCameraAgain_MovesItToTop()
        {
            var provider = new ActiveCameraProvider();
            var first = CreateCamera();
            var second = CreateCamera();
            provider.Register(first);
            provider.Register(second);

            provider.Register(first);
            provider.Unregister(first);

            Assert.AreSame(second, provider.Current);
        }

        [Test]
        public void Register_Null_IsIgnored()
        {
            var provider = new ActiveCameraProvider();

            provider.Register(null);

            Assert.IsNull(provider.Current);
        }

        private Camera CreateCamera()
        {
            var cameraObject = new GameObject(nameof(ActiveCameraProviderTests));
            _createdObjects.Add(cameraObject);
            return cameraObject.AddComponent<Camera>();
        }
    }
}
