using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Emotes
{
    // One emote on the wheel. The trigger names the Animator state that plays it; the duration is how long it lasts
    // before the player goes back to normal, whatever the clip length.
    [CreateAssetMenu(fileName = "EmoteData", menuName = "ScriptableObjects/EmoteData", order = 1)]
    public class EmoteData : ScriptableObject
    {
        [field: SerializeField] public string DisplayName { get; private set; } = "Emote";
        // placeholder until human-made icons exist; the wheel shows the name when there is none
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public string AnimationTrigger { get; private set; } = "";
        [field: SerializeField, Min(0f)] public float DurationInSeconds { get; private set; } = 2f;
    }
}
