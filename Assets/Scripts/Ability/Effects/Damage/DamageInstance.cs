
using System;

namespace SkySeekers.AbilitySystem
{
    [Serializable]
    public class DamageInstance : InstanceBase
    {
        public static DamageInstance Damage(AbilityEffect origin, AbilityCaster dealer, EventHandlerObject target,
            float amount, DamageType type, bool isCrit=false, bool isDefended=false)
        {
            DamageInstance dmgInst = new DamageInstance(origin, dealer, target,
                amount, type, isCrit, isDefended);
            dmgInst.Deal();
            return dmgInst;
        }

        public AbilityEffect OriginEffect { get; set; }
        public AbilityCaster Dealer { get; set; }
        public EventHandlerObject Target { get; set; }
        public float Amount { get; set; }
        public DamageType Type { get; set; }
        public bool IsCrit { get; set; }
        public bool IsDefended { get; set; }

        DamageInstance(AbilityEffect origin, AbilityCaster dealer, EventHandlerObject target,
            float amount, DamageType type, bool isCrit, bool isDefended)
        {
            OriginEffect = origin;
            Dealer = dealer;
            Target = target;
            Amount = amount;
            Type = type;
            IsCrit = isCrit;
            IsDefended = isDefended;
        }

        void Deal()
        {
            Dealer.EventHandler.DamageEvents.Trigger(EventFlag.DEAL_DAMAGE, this);
            if (Target != null)
            {
                Target.DamageEvents.Trigger(EventFlag.TAKE_DAMAGE, this);
            }
        }
    }
}