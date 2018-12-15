
using System;

namespace SkySeekers.AbilitySystem
{
    [Serializable]
    public class AttackInstance : InstanceBase
    {
        public static AttackInstance Attack(AbilityEffect origin, AbilityCaster attacker, EventHandlerObject target,
            float amount, DamageType type, AbilitySFXPool sfx)
        {
            AttackInstance atkInst = new AttackInstance(origin, attacker, target, amount, type, sfx);
            atkInst.Execute();
            return atkInst;
        }

        public AbilityEffect OriginEffect { get; set; }
        public AbilityCaster Attacker { get; set; }
        public EventHandlerObject Target { get; set; }
        public AbilitySFXPool SFX { get; set; }
        public float Damage { get; set; }
        public DamageType Type { get; set; }

        public float CritChance { get; set; }
        public float CritMultiplier { get; set; }
        public float HitChance { get; set; }
        public bool IsHit { get; set; }
        public bool IsCrit { get; set; }
        public bool IsDefended { get; set; }

        AttackInstance(AbilityEffect origin, AbilityCaster attacker, EventHandlerObject target,
            float amount, DamageType type, AbilitySFXPool sfx)
        {
            OriginEffect = origin;
            Attacker = attacker;
            Target = target;
            Damage = amount;
            Type = type;
            SFX = sfx;

            HitChance = 1f;
            IsHit = true;
            CritChance = attacker.CritChance;
            CritMultiplier = attacker.CritMultiplier;
        }

        void Execute()
        {
            Attacker.EventHandler.AttackEvents.Trigger(EventFlag.ATTACK, this);
            Target.AttackEvents.Trigger(EventFlag.ATTACKED, this);

            if (IsDefended)
            {
                Attacker.EventHandler.AttackEvents.Trigger(EventFlag.DEFEND, this);
                Target.AttackEvents.Trigger(EventFlag.DEFENDED, this);
            }

            if (UnityEngine.Random.Range(0, 1) < HitChance)
            {
                IsHit = true;
                if (OriginEffect.SFXOverride != null)
                {
                    OriginEffect.SFXOverride.Spawn(Target.transform);
                }
                else if (SFX != null)
                {
                    SFX.Spawn(Target.transform);
                }

                float critDeter = UnityEngine.Random.Range(0, 1f);
                if (critDeter < CritChance)
                {
                    IsCrit = true;
                    Attacker.EventHandler.AttackEvents.Trigger(EventFlag.CRIT, this);
                    Target.AttackEvents.Trigger(EventFlag.CRITTED, this);
                    Damage *= CritMultiplier;
                }
                DamageInstance.Damage(OriginEffect, Attacker, Target, Damage, Type, IsCrit, IsDefended);
            }
            else
            {
                Attacker.EventHandler.AttackEvents.Trigger(EventFlag.MISS, this);
                Target.AttackEvents.Trigger(EventFlag.MISSED, this);
            }
            
        }

    }
}