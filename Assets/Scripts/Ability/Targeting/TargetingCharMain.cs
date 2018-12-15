using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Targeting/CharTarget")]
    public class TargetingCharMain : AbilityTargeting
    {
        public override EventHandlerObject[] GetTargets(AbilityCaster caster)
        {
            EventHandlerObject[] targets = { caster.EventHandler.GetComponent<Character>().Targeting.CurrentTarget };
            return targets;
        }
    }
}
