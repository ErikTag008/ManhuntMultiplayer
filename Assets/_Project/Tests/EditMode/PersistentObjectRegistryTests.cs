using NUnit.Framework;
using Project.Assets._Project._Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project.Tests.EditMode
{
    public class PersistentObjectRegistryTests
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
        public void TryRegister_First_Succeeds()
        {
            var registry = new PersistentObjectRegistry();

            Assert.IsTrue(registry.TryRegister(CreatePersistent()));
        }

        [Test]
        public void TryRegister_Duplicate_Fails()
        {
            var registry = new PersistentObjectRegistry();
            registry.TryRegister(CreatePersistent());

            Assert.IsFalse(registry.TryRegister(CreatePersistent()));
        }

        [Test]
        public void TryRegister_SameInstanceTwice_Succeeds()
        {
            var registry = new PersistentObjectRegistry();
            var persistent = CreatePersistent();
            registry.TryRegister(persistent);

            Assert.IsTrue(registry.TryRegister(persistent));
        }

        [Test]
        public void Unregister_Current_AllowsNewInstance()
        {
            var registry = new PersistentObjectRegistry();
            var first = CreatePersistent();
            registry.TryRegister(first);

            registry.Unregister(first);

            Assert.IsTrue(registry.TryRegister(CreatePersistent()));
        }

        [Test]
        public void Unregister_Duplicate_KeepsCurrent()
        {
            var registry = new PersistentObjectRegistry();
            var first = CreatePersistent();
            var duplicate = CreatePersistent();
            registry.TryRegister(first);
            registry.TryRegister(duplicate);

            registry.Unregister(duplicate);

            Assert.IsFalse(registry.TryRegister(CreatePersistent()));
        }

        // AddComponent in Edit Mode doesn't run Awake, so no injection is needed
        private Persistent CreatePersistent()
        {
            var persistentObject = new GameObject(nameof(PersistentObjectRegistryTests));
            _createdObjects.Add(persistentObject);
            return persistentObject.AddComponent<Persistent>();
        }
    }
}
