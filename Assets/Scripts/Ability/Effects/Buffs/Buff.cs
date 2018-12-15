
using System.Linq;
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    public abstract class Buff : ScriptableObject
    {
        [SerializeField]
        bool _doesStack;
        public bool DoesStack { get { return _doesStack; } }
        [SerializeField]
        bool _tickOnApply;
        public bool TickOnApply { get { return _tickOnApply; } }
        [SerializeField]
        float _durationOverride;
        public float DurationOverride { get { return _durationOverride; } }
        [SerializeField]
        float _tickIntervalOverride;
        public float TickIntervalOverride { get { return _tickIntervalOverride; } }
        //[SerializeField]
        //AbilityPassive[] _passives;
        //public AbilityPassive[] Passives { get { return _passives; } }

        [SerializeField]
        AbilitySFXPool _sfx;
        public AbilitySFXPool SFX { get { return _sfx; } }

        public void Apply(AbilityEffect origin, AbilityCaster caster, EventHandlerObject target, AbilityData data)
        {
            if (!_doesStack)
            {
                BuffInstance existingBuff = target.Buffs.FirstOrDefault(
                    (buffInst) => buffInst.Caster == caster && buffInst.Buff == this);
                if (existingBuff != null)
                {
                    existingBuff.Remove();
                }
            }
            BuffInstance.ApplyBuff(origin, this, caster, target, data);
            
        }

        public virtual void OnApply(BuffInstance instance) { }

        public virtual void OnTick(BuffInstance instance) { }

        public virtual void OnExpire(BuffInstance instance) { }

        public virtual void OnRemove(BuffInstance instance) { }

    }
}