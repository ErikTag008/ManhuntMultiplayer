using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Abilities
{
    [CreateAssetMenu(fileName = "DashAbilityData", menuName = "ScriptableObjects/DashAbilityData", order = 1)]
    public class DashAbilityData : AbilityData
    {
        [field: SerializeField, Min(0f)] public float DashSpeed { get; private set; } = 45f;

        public override AbilityTrigger Trigger => AbilityTrigger.AbilityKey;

        public override bool TryActivate(IPlayerMovement movement)
        {
            movement.Dash(DashSpeed);
            return true;
        }
    }
}
