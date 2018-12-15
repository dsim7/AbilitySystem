
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Effects/ApplyBuff")]
    public class EffectApplyBuff : AbilityEffect
    {
        [SerializeField]
        Buff _buff;

        public override void ApplyEffect(AbilityCaster caster, EventHandlerObject[] targets, AbilityData data)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                _buff.Apply(this, caster, targets[i], data);
            }
        }
    }

}