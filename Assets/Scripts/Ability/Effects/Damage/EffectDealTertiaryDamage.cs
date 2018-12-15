
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Effects/Damage/TertiaryDamage", order = 3)]
    public class EffectDealTertiaryDamage : AbilityEffect
    {
        public override void ApplyEffect(AbilityCaster caster,
            EventHandler[] targets, AbilityData data)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                DamageInstance.Damage(this, caster, targets[i], data.TertiaryValue, data.TertiaryType);
            }
        }
    }
}
