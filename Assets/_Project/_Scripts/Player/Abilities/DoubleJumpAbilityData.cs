using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Abilities
{
    [CreateAssetMenu(fileName = "DoubleJumpAbilityData", menuName = "ScriptableObjects/DoubleJumpAbilityData", order = 1)]
    public class DoubleJumpAbilityData : AbilityData
    {
        // 1 = the same push as a normal jump
        [field: SerializeField, Min(0f)] public float JumpForceMultiplier { get; private set; } = 1f;

        public override AbilityTrigger Trigger => AbilityTrigger.AirJump;

        // a press that would be an ordinary jump or a wall-jump stays one
        public override bool TryActivate(IPlayerMovement movement)
        {
            if (movement.CanJumpFromGround() || movement.CanWallJump()) return false;

            movement.AirJump(JumpForceMultiplier);
            return true;
        }
    }
}
