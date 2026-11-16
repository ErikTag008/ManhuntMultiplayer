using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Feedback
{
    // The sounds and particle bursts every instance plays on a player for the round's key moments.
    // An ability's own UseFeedback replaces AbilityUsed when it has any content.
    [CreateAssetMenu(fileName = "PlayerFeedbackData", menuName = "ScriptableObjects/PlayerFeedbackData", order = 1)]
    public class PlayerFeedbackData : ScriptableObject
    {
        // a catcher's hit knocked this runner
        [field: SerializeField] public FeedbackCue Knocked { get; private set; } = new();
        // a shield drop took the catcher's hit instead
        [field: SerializeField] public FeedbackCue ShieldBlocked { get; private set; } = new();
        [field: SerializeField] public FeedbackCue Revived { get; private set; } = new();
        // the bleed-out ran out
        [field: SerializeField] public FeedbackCue BledOut { get; private set; } = new();
        [field: SerializeField] public FeedbackCue GoodDropTaken { get; private set; } = new();
        [field: SerializeField] public FeedbackCue BadDropTaken { get; private set; } = new();
        [field: SerializeField] public FeedbackCue AbilityUsed { get; private set; } = new();
    }
}
