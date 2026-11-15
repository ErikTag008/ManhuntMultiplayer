using KBCore.Refs;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Drops
{
    // The Visible Trail drop: a trail follows the runner for everyone, catchers included, until the effect ends.
    // The TrailRenderer is the swap point; its look lives on the prefab child.
    [RequireComponent(typeof(PlayerDropEffects))]
    public class PlayerDropTrail : ValidatedMonoBehaviour
    {
        [SerializeField, Self] private PlayerDropEffects _dropEffects;
        [SerializeField] private TrailRenderer _trail;

        private void Awake()
        {
            ToggleTrail(false);
            _dropEffects.OnActiveEffectChanged += HandleActiveEffectChanged;
        }

        private void HandleActiveEffectChanged(DropEffectData effect) => ToggleTrail(effect != null && effect.Has(DropStatus.Trail));

        // starting fresh keeps an old trail from drawing a line across a teleport
        private void ToggleTrail(bool isOn)
        {
            if (_trail == null) return;

            if (isOn != _trail.emitting) _trail.Clear();
            _trail.emitting = isOn;
        }

        private void OnDestroy() => _dropEffects.OnActiveEffectChanged -= HandleActiveEffectChanged;
    }
}
