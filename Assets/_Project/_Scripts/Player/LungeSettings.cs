using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Assets._Project._Scripts.Player
{
    // The catcher's charged attack: hold Attack until the charge is full, release to lunge forward with a longer reach.
    // A tap released before the charge is full is the weapon's normal swing.
    [Serializable]
    public class LungeSettings
    {
        [field: Header("Charge")]
        // held shorter than this, the press is a tap and nothing slows down
        [field: SerializeField, Min(0f)] public float ChargeStartDelayInSeconds { get; private set; } = 0.15f;
        // from the press; a release after this lunges
        [field: SerializeField, Min(0f)] public float FullChargeDurationInSeconds { get; private set; } = 0.6f;
        // applied on the owner while charging
        [field: SerializeField] public StatModifier[] ChargeModifiers { get; private set; } =
        {
            new(ModifiableStat.MaxMoveSpeed, StatModifierKind.Multiply, 0.6f)
        };

        [field: Header("Lunge")]
        [field: SerializeField, Min(0f)] public float LungeSpeed { get; private set; } = 26f;
        [field: SerializeField, Min(0f)] public float LungeDurationInSeconds { get; private set; } = 0.3f;
        // time from the release until the weapon reaches the target; match the Lunge animation
        [field: SerializeField, Min(0f)] public float HitDelayInSeconds { get; private set; } = 0.25f;
        // thickness of the view sweep; wider than a swing, since the catcher is moving fast
        [field: SerializeField, Min(0f)] public float HitRadius { get; private set; } = 0.7f;
        [field: SerializeField, Min(0f)] public float ReachInMeters { get; private set; } = 2.6f;
        // the sweep repeats every frame for this long after the hit delay
        [field: SerializeField, Min(0f)] public float HitWindowInSeconds { get; private set; } = 0.15f;
        // the server rejects a target farther than this from the attacker (lunge distance plus reach and lag)
        [field: SerializeField, Min(0f), FormerlySerializedAs("<MaxHitOriginDistance>k__BackingField")]
        public float MaxTargetDistance { get; private set; } = 12f;
        // from the release to the next attack when the lunge caught something
        [field: SerializeField, Min(0f)] public float HitCooldownInSeconds { get; private set; } = 1.5f;

        [field: Header("Miss recovery")]
        [field: SerializeField, Min(0f)] public float MissCooldownInSeconds { get; private set; } = 2.5f;
        [field: SerializeField, Min(0f)] public float MissRecoveryDurationInSeconds { get; private set; } = 1.2f;
        // applied on the owner for the recovery after a miss
        [field: SerializeField] public StatModifier[] MissRecoveryModifiers { get; private set; } =
        {
            new(ModifiableStat.MaxMoveSpeed, StatModifierKind.Multiply, 0.4f),
            new(ModifiableStat.JumpForce, StatModifierKind.Multiply, 0.5f)
        };
    }
}
