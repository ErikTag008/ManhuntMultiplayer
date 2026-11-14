using KBCore.Refs;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Drops
{
    // Shows the shield bubble around a shielded runner on every instance, so catchers see it too.
    // The bubble is a child object, the swap point for the real model and material.
    [RequireComponent(typeof(PlayerDropEffects))]
    public class PlayerShieldVisual : NetworkBehaviour
    {
        [SerializeField, Self] private PlayerDropEffects _dropEffects;
        [SerializeField] private GameObject _shieldVisual;

        private void OnValidate() => this.ValidateRefs();

        public override void OnNetworkSpawn()
        {
            _dropEffects.OnActiveEffectChanged += HandleActiveEffectChanged;
            ToggleShield(_dropEffects.Has(DropStatus.Shielded));
        }

        private void HandleActiveEffectChanged(DropEffectData effect) => ToggleShield(effect != null && effect.Has(DropStatus.Shielded));

        private void ToggleShield(bool isShown)
        {
            if (_shieldVisual != null) _shieldVisual.SetActive(isShown);
        }

        public override void OnNetworkDespawn()
        {
            _dropEffects.OnActiveEffectChanged -= HandleActiveEffectChanged;
            ToggleShield(false);
        }
    }
}
