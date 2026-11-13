using System.Collections.Generic;
using UnityEngine;

namespace Project.Assets._Project._Scripts.Player.Abilities
{
    // Every ability a runner can have, looked up by the id stored in PlayerSession.AbilityId
    [CreateAssetMenu(fileName = "AbilityCatalog", menuName = "ScriptableObjects/AbilityCatalog", order = 1)]
    public class AbilityCatalog : ScriptableObject
    {
        [field: SerializeField] public List<AbilityData> Abilities { get; private set; } = new();
        // used while a session has no pick yet (the lobby pick arrives in P1-18)
        [field: SerializeField] public AbilityData DefaultAbility { get; private set; }

        public bool TryGet(int abilityId, out AbilityData ability)
        {
            foreach (var candidate in Abilities)
            {
                if (candidate == null || candidate.Id != abilityId) continue;

                ability = candidate;
                return true;
            }

            ability = null;
            return false;
        }

        // the session's pick, or the default when there is no pick (or it no longer exists)
        public AbilityData Resolve(int abilityId) => TryGet(abilityId, out var ability) ? ability : DefaultAbility;
    }
}
