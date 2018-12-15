using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Targeting/CharTarget")]
    public class TargetingCharMain : AbilityTargeting
    {
        public override EventHandler[] GetTargets(AbilityCaster caster)
        {
            EventHandler[] targets = { caster.EventHandler.GetComponent<Character>().Targeting.CurrentTarget };
            return targets;
        }
    }
}
