using System;
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Buffs/Block")]
    public class Block : Buff
    {
        public override void OnApply(BuffInstance instance)
        {
            instance.ApplyBuffMod(AttackModHandler.Generate(EventFlag.ATTACKED,
                (atkInst) =>
                {
                    atkInst.IsDefended = true;
                    atkInst.Damage *= instance.Data.MainValue;
                }));
        }
    }
}