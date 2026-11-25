using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    [CreateAssetMenu(fileName = "RunnerStats", menuName = "Project/Runner Stats", order = 0)]
    public class RunnerStats : PlayerStats
    {
        [field: Header("Knocked Stats")]
        // the bleed-out of the 1st, 2nd, ... knock in a round; a knock past the last entry eliminates at once
        [field: SerializeField] public float[] BleedOutDurationsByKnockInSeconds { get; private set; } = { 30f, 20f, 10f };
        // anti-camp: the bleed-out holds while any catcher is within this many meters of the knocked runner
        [field: SerializeField] public float BleedOutPauseCatcherRange { get; private set; } = 8f;
        [field: SerializeField] public float RescueDurationInSeconds { get; private set; } = 5f;
        [field: SerializeField] public float RescueRange { get; private set; } = 2.5f;
        // catches are ignored for this long after a rescue, so a camping catcher can't knock the runner straight back
        [field: SerializeField] public float ReviveInvulnerabilityDurationInSeconds { get; private set; } = 3f;
        // applied on the owner while knocked: a slow crawl with no jumping
        [field: SerializeField] public StatModifier[] KnockedModifiers { get; private set; } =
        {
            new(ModifiableStat.MaxMoveSpeed, StatModifierKind.Multiply, 0.2f),
            new(ModifiableStat.JumpForce, StatModifierKind.Multiply, 0f)
        };

        // knockNumber counts from 1; false once the runner has used up every bleed-out this round
        public bool TryGetBleedOutDuration(int knockNumber, out float durationInSeconds)
        {
            int index = knockNumber - 1;
            bool hasDuration = index >= 0 && index < BleedOutDurationsByKnockInSeconds.Length;
            durationInSeconds = hasDuration ? BleedOutDurationsByKnockInSeconds[index] : 0f;
            return hasDuration;
        }
    }
}
