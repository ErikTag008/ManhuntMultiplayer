using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    [CreateAssetMenu(fileName = "RunnerStats", menuName = "Project/Runner Stats", order = 0)]
    public class RunnerStats : PlayerStats
    {
        [field: Header("Knocked Stats")]
        [field: SerializeField] public float BleedOutDurationInSeconds { get; private set; } = 30f;
        // applied on the owner while knocked: a slow crawl with no jumping
        [field: SerializeField] public StatModifier[] KnockedModifiers { get; private set; } =
        {
            new(ModifiableStat.MaxMoveSpeed, StatModifierKind.Multiply, 0.2f),
            new(ModifiableStat.JumpForce, StatModifierKind.Multiply, 0f)
        };
    }
}
