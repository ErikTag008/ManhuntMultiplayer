using NUnit.Framework;
using Project.Assets._Project._Scripts.SceneFlow;
using System.Collections.Generic;

namespace Project.Assets._Project.Tests.EditMode
{
    public class SceneLifecycleManagerTests
    {
        private class RecordingSceneObject : ISceneInitialized
        {
            public readonly List<SceneType> Initialized = new();
            public readonly List<SceneType> Cleared = new();

            public void InitializeSceneReferences(SceneType scene) => Initialized.Add(scene);
            public void ClearSceneReferences(SceneType scene) => Cleared.Add(scene);
        }

        [Test]
        public void InitializeScene_NotifiesRegisteredObjects()
        {
            var manager = new SceneLifecycleManager();
            var sceneObject = new RecordingSceneObject();
            manager.Register(sceneObject);

            manager.InitializeScene(SceneType.Lobby);

            CollectionAssert.AreEqual(new[] { SceneType.Lobby }, sceneObject.Initialized);
        }

        [Test]
        public void Register_AfterSceneInitialized_InitializesImmediately()
        {
            var manager = new SceneLifecycleManager();
            manager.InitializeScene(SceneType.Gameplay);
            var sceneObject = new RecordingSceneObject();

            manager.Register(sceneObject);

            CollectionAssert.AreEqual(new[] { SceneType.Gameplay }, sceneObject.Initialized);
        }

        [Test]
        public void Register_Twice_NotifiesOnce()
        {
            var manager = new SceneLifecycleManager();
            var sceneObject = new RecordingSceneObject();
            manager.Register(sceneObject);
            manager.Register(sceneObject);

            manager.InitializeScene(SceneType.Lobby);

            Assert.AreEqual(1, sceneObject.Initialized.Count);
        }

        [Test]
        public void ClearScene_NotifiesAndStopsLateInitialization()
        {
            var manager = new SceneLifecycleManager();
            var registered = new RecordingSceneObject();
            manager.Register(registered);
            manager.InitializeScene(SceneType.Lobby);

            manager.ClearScene(SceneType.Lobby);
            var lateObject = new RecordingSceneObject();
            manager.Register(lateObject);

            CollectionAssert.AreEqual(new[] { SceneType.Lobby }, registered.Cleared);
            Assert.IsEmpty(lateObject.Initialized);
        }

        [Test]
        public void Unregister_StopsNotifications()
        {
            var manager = new SceneLifecycleManager();
            var sceneObject = new RecordingSceneObject();
            manager.Register(sceneObject);

            manager.Unregister(sceneObject);
            manager.InitializeScene(SceneType.Lobby);

            Assert.IsEmpty(sceneObject.Initialized);
        }
    }
}
