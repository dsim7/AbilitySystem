
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Effects/Attacks/SecondaryAttack", order = 2)]
    public class EffectSecondaryAttack : AbilityEffect
    {
        public override void ApplyEffect(AbilityCaster caster, EventHandler[] targets, AbilityData data)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                AttackInstance.Attack(this, caster, targets[i], data.SecondaryValue, data.SecondaryType, data.SFX);
            }
        }
    }
}