using Reflex.Core;
using Reflex.Injectors;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Managers
{
    // Spawns a network prefab that relies on [Inject] (in-scene objects normally get it at scene load):
    // every instance is injected from the given scene container before NGO spawns it
    public class InjectingPrefabHandler : INetworkPrefabInstanceHandler
    {
        private readonly NetworkObject _prefab;
        private readonly Container _container;

        public InjectingPrefabHandler(NetworkObject prefab, Container container)
        {
            _prefab = prefab;
            _container = container;
        }

        // made under an inactive holder, so Awake and OnEnable already see the injected fields
        public NetworkObject Instantiate(ulong ownerClientId, Vector3 position, Quaternion rotation)
        {
            var holder = new GameObject(_prefab.name);
            holder.SetActive(false);
            var instance = Object.Instantiate(_prefab, position, rotation, holder.transform);
            GameObjectInjector.InjectRecursive(instance.gameObject, _container);
            instance.transform.SetParent(null, true);
            Object.Destroy(holder);
            return instance;
        }

        public void Destroy(NetworkObject networkObject) => Object.Destroy(networkObject.gameObject);
    }
}
