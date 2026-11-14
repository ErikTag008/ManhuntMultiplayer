using UnityEngine;

namespace Project.Assets._Project._Scripts.Player
{
    // IMovementStats with the player's active modifiers applied; PlayerMovement reads this instead of the raw stats asset
    public class ModifiedMovementStats : IMovementStats
    {
        private readonly StatModifierStack _modifiers;
        private IMovementStats _baseStats;

        public ModifiedMovementStats(IMovementStats baseStats, StatModifierStack modifiers)
        {
            _baseStats = baseStats;
            _modifiers = modifiers;
        }

        public float MaxMoveSpeed => _modifiers.Apply(ModifiableStat.MaxMoveSpeed, _baseStats.MaxMoveSpeed);
        public float JumpForce => _modifiers.Apply(ModifiableStat.JumpForce, _baseStats.JumpForce);
        public float GroundAcceleration => _modifiers.Apply(ModifiableStat.GroundAcceleration, _baseStats.GroundAcceleration);
        public float AirAcceleration => _modifiers.Apply(ModifiableStat.AirAcceleration, _baseStats.AirAcceleration);

        public float CoyoteTime => _baseStats.CoyoteTime;
        public float JumpBuffer => _baseStats.JumpBuffer;
        public float JumpButtonUpVerticalVelocityMultiplier => _baseStats.JumpButtonUpVerticalVelocityMultiplier;
        public float JumpButtonUpMinVerticalVelocity => _baseStats.JumpButtonUpMinVerticalVelocity;
        public float GroundCheckRadius => _baseStats.GroundCheckRadius;
        public float GroundCheckMaxYVelocity => _baseStats.GroundCheckMaxYVelocity;
        public float MaxGroundAngle => _baseStats.MaxGroundAngle;
        public float HorizontalDamping => _baseStats.HorizontalDamping;
        public float VerticalDamping => _baseStats.VerticalDamping;
        public LayerMask GroundCheckLayers => _baseStats.GroundCheckLayers;
        public float NetworkVariableDetectionMinMagnitude => _baseStats.NetworkVariableDetectionMinMagnitude;
        public float NetworkVariableSmoothingSpeed => _baseStats.NetworkVariableSmoothingSpeed;
        public ParkourSettings Parkour => _baseStats.Parkour;

        // Team changes swap the base asset; the modifiers stay in their own stack
        public void ChangeBaseStats(IMovementStats baseStats)
        {
            if (baseStats != null) _baseStats = baseStats;
        }
    }
}
