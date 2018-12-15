
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Effects/Damage/MainDamage", order = 1)]
    public class EffectDealMainDamage : AbilityEffect
    {
        public override void ApplyEffect(AbilityCaster caster,
            EventHandler[] targets, AbilityData data)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                DamageInstance.Damage(this, caster, targets[i], data.MainValue, data.MainType);
            }
        }
    }
}