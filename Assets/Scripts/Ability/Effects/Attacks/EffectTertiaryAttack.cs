
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Effects/Attacks/TertiaryAttack", order = 3)]
    public class EffectTertiaryAttack : AbilityEffect
    {
        public override void ApplyEffect(AbilityCaster caster, EventHandlerObject[] targets, AbilityData data)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                AttackInstance.Attack(this, caster, targets[i], data.TertiaryValue, data.TertiaryType, data.SFX);
            }
        }
    }
}