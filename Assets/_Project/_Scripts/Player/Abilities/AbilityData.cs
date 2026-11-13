using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Abilities
{
    // One runner ability. Its id is what PlayerSession.AbilityId stores, so it must be unique and never reused.
    public abstract class AbilityData : ScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public string DisplayName { get; private set; } = "Ability";
        [field: SerializeField, Min(0f)] public float CooldownInSeconds { get; private set; } = 15f;
        // what the HUD slot shows while the ability is ready, e.g. the key that triggers it
        [field: SerializeField] public string ReadyHint { get; private set; } = "Q";

        public abstract AbilityTrigger Trigger { get; }

        // Owner only: applies the effect, or returns false when it can't happen right now (no cooldown is spent)
        public abstract bool TryActivate(IPlayerMovement movement);
    }

    public enum AbilityTrigger
    {
        // the ability key
        AbilityKey,
        // a jump press while airborne
        AirJump
    }
}
