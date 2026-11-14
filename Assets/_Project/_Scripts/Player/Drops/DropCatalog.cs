using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Drops
{
    // Every effect a drop box can give, looked up by the id PlayerDropEffects syncs
    [CreateAssetMenu(fileName = "DropCatalog", menuName = "ScriptableObjects/DropCatalog", order = 1)]
    public class DropCatalog : ScriptableObject
    {
        [field: SerializeField] public List<DropEffectData> Effects { get; private set; } = new();

        // reused by every pick so a pickup doesn't allocate
        private readonly List<float> _weights = new();

        public bool TryGet(int effectId, out DropEffectData effect)
        {
            foreach (var candidate in Effects)
            {
                if (candidate == null || candidate.Id != effectId) continue;

                effect = candidate;
                return true;
            }

            effect = null;
            return false;
        }

        public bool TryPick(float random01, out DropEffectData effect)
        {
            _weights.Clear();
            foreach (var candidate in Effects) _weights.Add(candidate != null ? candidate.Weight : 0f);

            effect = WeightedPick.TryPickIndex(_weights, random01, out int index) ? Effects[index] : null;
            return effect != null;
        }
    }
}
