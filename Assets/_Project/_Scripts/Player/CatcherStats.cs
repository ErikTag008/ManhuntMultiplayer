using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    [CreateAssetMenu(fileName = "CatcherStats", menuName = "Project/Catcher Stats", order = 0)]
    public class CatcherStats : PlayerStats
    {
        [field: SerializeField] public LungeSettings Lunge { get; private set; } = new();
        // a swing can't reach a runner behind these (walls, floors); player layers never block it
        [field: SerializeField] public LayerMask HitBlockingLayers { get; private set; }

        [field: Header("Trip Trap Snare")]
        // how long a runner's Trip Trap holds this catcher back; no lunge is possible meanwhile
        [field: SerializeField, Min(0f)] public float SnareDurationInSeconds { get; private set; } = 1.5f;
        [field: SerializeField] public StatModifier[] SnareModifiers { get; private set; } =
        {
            new(ModifiableStat.MaxMoveSpeed, StatModifierKind.Multiply, 0.3f),
            new(ModifiableStat.JumpForce, StatModifierKind.Multiply, 0.5f)
        };
    }
}
