namespace Project.Assets._Project._Scripts.Player
{
    // One change to one stat; drops, abilities and the knocked crawl provide these
    public interface IStatModifier
    {
        ModifiableStat Stat { get; }
        StatModifierKind Kind { get; }
        float Value { get; }
    }

    public enum ModifiableStat
    {
        MaxMoveSpeed,
        JumpForce,
        GroundAcceleration,
        AirAcceleration
    }

    // Final value = (base + sum of Add values) * product of Multiply values
    public enum StatModifierKind
    {
        Add,
        Multiply
    }
}
