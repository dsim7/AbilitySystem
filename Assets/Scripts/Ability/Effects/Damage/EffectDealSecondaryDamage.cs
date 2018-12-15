
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Effects/Damage/SecondaryDamage", order = 2)]
    public class EffectDealSecondaryDamage : AbilityEffect
    {
        public override void ApplyEffect(AbilityCaster caster,
            EventHandlerObject[] targets, AbilityData data)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                DamageInstance.Damage(this, caster, targets[i], data.SecondaryValue, data.SecondaryType);
            }
        }
    }
}
