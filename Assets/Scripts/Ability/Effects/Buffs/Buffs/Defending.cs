
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Buffs/DefendingBuff")]
    public class Defending : Buff
    {
        public override void OnApply(BuffInstance instance)
        {
            instance.ApplyBuffMod(AttackModHandler.Generate(EventFlag.ATTACKED,
                (atkInst) =>
                {
                    atkInst.IsDefended = true;
                }));
        }
    }
}