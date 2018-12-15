using System;
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Buffs/BurningBuff")]
    public class Burning : Buff
    {
        public override void OnApply(BuffInstance instance)
        {
            instance.ApplyBuffMod(AttackModHandler.Generate(EventFlag.HIT_BY_ATTACK,
                (atkInst) =>
                {
                    OnTick(instance);
                }));
        }

        public override void OnTick(BuffInstance instance)
        {
            DamageInstance.Damage(instance.OriginEffect, instance.Caster, instance.Target,
                instance.Data.SecondaryValue, instance.Data.SecondaryType);
        }
    }
}
