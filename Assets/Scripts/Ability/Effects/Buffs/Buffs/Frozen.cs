using System;
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Buffs/FrozenBuff")]
    public class Frozen : Buff
    {
        public override void OnApply(BuffInstance instance)
        {
            instance.Target.GetComponent<AbilityCaster>().AddDisabler();

            instance.ApplyBuffMod(AttackModHandler.Generate(EventFlag.HIT_BY_ATTACK,
                (atkInst) =>
                {
                DamageInstance.Damage(instance.OriginEffect, instance.Caster, instance.Target,
                    instance.Data.MainValue * (atkInst.IsCrit ? 2 : 1), instance.Data.MainType);
                    instance.Remove();
                }));
        }

        public override void OnRemove(BuffInstance instance)
        {
            instance.Target.GetComponent<AbilityCaster>().RemoveDisabler();
        }
    }
}
