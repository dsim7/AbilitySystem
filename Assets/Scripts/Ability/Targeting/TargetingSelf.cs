
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Targeting/Self")]
    public class TargetingSelf : AbilityTargeting
    {
        public override EventHandler[] GetTargets(AbilityCaster caster)
        {
            EventHandler[] targets = { caster.GetComponent<EventHandler>() };
            return targets;
        }
    }
}
