
using System;
using UnityEngine;
using UnityEngine.Events;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Buffs/TestBuff")]
    public class TestBuff : Buff
    {
        [SerializeField]
        AbilityDataLabel _scaleLabel;

        public override void OnApply(BuffInstance instance)
        {
            DamageInstance.Damage(instance.OriginEffect, instance.Caster, instance.Target, instance.Data.MainValue, instance.Data.MainType);
            instance.ApplyBuffMod(DamageModHandler.Generate(EventFlag.TAKE_DAMAGE,
                (dmgInst) =>
                {
                    dmgInst.Amount *= instance.Data.MiscFloatData[_scaleLabel];
                }));
        }

        public override void OnExpire(BuffInstance instance)
        {
            DamageInstance.Damage(instance.OriginEffect, instance.Caster, instance.Target, instance.Data.TertiaryValue, instance.Data.TertiaryType);
        }

        public override void OnRemove(BuffInstance instance)
        {

        }

        public override void OnTick(BuffInstance instance)
        {
            DamageInstance.Damage(instance.OriginEffect, instance.Caster, instance.Target, instance.Data.SecondaryValue, instance.Data.SecondaryType);
        }
    }
}
