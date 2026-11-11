using Reflex.Attributes;
using UnityEngine;

namespace Project.Assets._Project._Scripts
{
    public class Persistent : MonoBehaviour
    {
        [Inject] private readonly PersistentObjectRegistry _persistentObjectRegistry;

        private void Awake()
        {
            if (!_persistentObjectRegistry.TryRegister(this))
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }

        private void OnDestroy() => _persistentObjectRegistry?.Unregister(this);
    }
}
