using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Abilities
{
    // For ActiveDurationInSeconds the runner sees a marker on every catcher through walls; only the user's own HUD shows it
    [CreateAssetMenu(fileName = "SixthSenseAbilityData", menuName = "ScriptableObjects/SixthSenseAbilityData", order = 1)]
    public class SixthSenseAbilityData : AbilityData
    {
        public override AbilityTrigger Trigger => AbilityTrigger.AbilityKey;
        public override bool RevealsCatchersWhileActive => true;

        // the HUD reads the active time from the cooldown, so there is nothing to apply here
        public override bool TryActivate(IPlayerMovement movement) => true;
    }
}
