using Project.Assets._Project._Scripts.Player.Feedback;
using Unity.Netcode;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Abilities
{
    // One runner ability. Its id is what PlayerSession.AbilityId stores, so it must be unique and never reused.
    public abstract class AbilityData : ScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public string DisplayName { get; private set; } = "Ability";
        [field: SerializeField, Min(0f)] public float CooldownInSeconds { get; private set; } = 15f;
        // what the HUD slot shows while the ability is ready; {0} is the ability key as currently bound, e.g. "Air" needs none
        [field: SerializeField] public string ReadyHint { get; private set; } = "{0}";
        // Animator trigger played when the ability is used; empty when the regular animation already shows it
        [field: SerializeField] public string AnimationTrigger { get; private set; } = "";
        // how long the effect lasts after a use, counted from the use; 0 for instant abilities
        [field: SerializeField, Min(0f)] public float ActiveDurationInSeconds { get; private set; }
        // what everyone hears and sees on a use; left empty, PlayerFeedbackData.AbilityUsed plays instead
        [field: SerializeField] public FeedbackCue UseFeedback { get; private set; } = new();

        // while active, the user sees where every catcher is, through walls
        public virtual bool RevealsCatchersWhileActive => false;

        public abstract AbilityTrigger Trigger { get; }

        // Owner only: applies the effect, or returns false when it can't happen right now (no cooldown is spent)
        public abstract bool TryActivate(IPlayerMovement movement);

        // Server only, once the use is accepted: what the ability leaves in the world, placed where the owner stood and facing their heading
        public virtual void ActivateOnServer(NetworkManager networkManager, Vector3 position, Quaternion rotation) { }
    }

    public enum AbilityTrigger
    {
        // the ability key
        AbilityKey,
        // a jump press while airborne
        AirJump
    }
}
