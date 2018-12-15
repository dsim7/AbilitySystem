
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Effects/Attacks/MainAttack", order = 1)]
    public class EffectMainAttack : AbilityEffect
    {
        public override void ApplyEffect(AbilityCaster caster, EventHandlerObject[] targets, AbilityData data)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                AttackInstance.Attack(this, caster, targets[i], data.MainValue, data.MainType, data.SFX);
            }
        }
    }

}