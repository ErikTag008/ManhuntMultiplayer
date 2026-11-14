using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Drops
{
    // One effect a drop box can give a runner. Its id is what PlayerDropEffects syncs, so it must be unique, at least 1, and never reused.
    [CreateAssetMenu(fileName = "DropEffectData", menuName = "ScriptableObjects/DropEffectData", order = 1)]
    public class DropEffectData : ScriptableObject
    {
        [field: SerializeField, Min(1)] public int Id { get; private set; } = 1;
        [field: SerializeField] public string DisplayName { get; private set; } = "Drop";
        [field: SerializeField] public bool IsGood { get; private set; } = true;
        // relative chance against the other effects in the catalog; 0 never drops
        [field: SerializeField, Min(0f)] public float Weight { get; private set; } = 1f;
        [field: SerializeField, Min(0f)] public float DurationInSeconds { get; private set; } = 8f;
        // applied to the owner's movement for the duration
        [field: SerializeField] public List<StatModifier> Modifiers { get; private set; } = new();
        [field: SerializeField] public DropStatus Statuses { get; private set; }

        public bool Has(DropStatus status) => (Statuses & status) != 0;
    }

    [Flags]
    public enum DropStatus
    {
        None = 0,
        Invisible = 1,
        Revealed = 2,
        Shielded = 4,
        InvertedControls = 8
    }
}
