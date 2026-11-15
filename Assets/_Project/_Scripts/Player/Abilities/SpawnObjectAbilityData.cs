using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Abilities
{
    // Leaves a networked object (smoke cloud, decoy, ...) where the runner stood, facing their heading; the object runs its own effect and lifetime
    [CreateAssetMenu(fileName = "SpawnObjectAbilityData", menuName = "ScriptableObjects/SpawnObjectAbilityData", order = 1)]
    public class SpawnObjectAbilityData : AbilityData
    {
        [field: SerializeField] public NetworkObject Prefab { get; private set; }

        public override AbilityTrigger Trigger => AbilityTrigger.AbilityKey;

        // the object comes from the server, so the owner has nothing to apply
        public override bool TryActivate(IPlayerMovement movement) => Prefab != null;

        // destroyed with the scene, so nothing outlives the round's map
        public override void ActivateOnServer(NetworkManager networkManager, Vector3 position, Quaternion rotation)
        {
            if (Prefab == null) return;

            networkManager.SpawnManager.InstantiateAndSpawn(Prefab, NetworkManager.ServerClientId, destroyWithScene: true, position: position, rotation: rotation);
        }
    }
}
