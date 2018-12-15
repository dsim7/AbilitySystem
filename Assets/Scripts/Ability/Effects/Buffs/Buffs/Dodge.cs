
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Buffs/DodgeBuff")]
    public class Dodge : Buff
    {
        public override void OnApply(BuffInstance instance)
        {
            instance.ApplyBuffMod(AttackModHandler.Generate(EventFlag.ATTACKED,
                (atkInst) =>
                {
                    atkInst.IsDefended = true;
                    atkInst.HitChance = 0;
                    instance.Remove();
                }));
        }
    }
}