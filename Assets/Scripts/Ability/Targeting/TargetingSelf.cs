
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Targeting/Self")]
    public class TargetingSelf : AbilityTargeting
    {
        public override EventHandlerObject[] GetTargets(AbilityCaster caster)
        {
            EventHandlerObject[] targets = { caster.GetComponent<EventHandlerObject>() };
            return targets;
        }
    }
}
