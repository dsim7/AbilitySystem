
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SkySeekers.AbilitySystem
{
    [Serializable]
    public class BuffInstance : InstanceBase
    {
        public static BuffInstance ApplyBuff(AbilityEffect origin, Buff buff, AbilityCaster caster, EventHandlerObject target, AbilityData data)
        {
            BuffInstance buffInst = new BuffInstance(origin, buff, caster, target, data);
            buffInst.Start();
            return buffInst;
        }

        public AbilityEffect OriginEffect { get; set; }
        public Buff Buff { get; set; }
        public AbilityCaster Caster { get; set; }
        public EventHandlerObject Target { get; set; }
        public AbilityData Data { get; set; }
        public float CurrentDuration { get; set; }
        public float TickInterval { get; set; }
        public AbilitySFX SfxInstance { get; set; }
        public float NextTickTime { get; set; }

        List<ModHandler> _mods = new List<ModHandler>();

        BuffInstance(AbilityEffect originEffect, Buff buff, AbilityCaster caster, EventHandlerObject target, AbilityData data)
        {
            OriginEffect = originEffect;
            Buff = buff;
            Caster = caster;
            Target = target;
            Data = data;
        }

        public void UpdateTime()
        {
            CurrentDuration -= Time.deltaTime;
            if (TickInterval != 0 && CurrentDuration <= NextTickTime)
            {
                Tick();
                NextTickTime -= TickInterval;
            }
            if (CurrentDuration <= 0 && Buff.DurationOverride != -1 && Data != null && Data.Duration != -1)
            {
                Expire();
            }
        }

        public void Start()
        {
            // Setting Durations
            CurrentDuration = Buff.DurationOverride != 0 || Data == null ? Buff.DurationOverride : Data.Duration;

            if (CurrentDuration == 0)
            {
                Debug.LogWarning("Buff with zero second duration applied.");
            }

            TickInterval = Buff.TickIntervalOverride != 0 || Data == null ? Buff.TickIntervalOverride : Data.TickInterval;
            NextTickTime = CurrentDuration - TickInterval;

            // Applying
            Caster.EventHandler.BuffEvents.Trigger(EventFlag.APPLY_BUFF, this);
            Buff.OnApply(this);
            
            ApplyMods();

            // Tick if tickOnApply
            if (Buff.TickOnApply)
            {
                Buff.OnTick(this);
            }

            // Gaining Buff
            if (Target != null)
            {
                Target.BuffEvents.Trigger(EventFlag.GAIN_BUFF, this);
                Target.Buffs.Add(this);
            }

            // SFX application
            if (OriginEffect != null && OriginEffect.SFXOverride != null)
            {
                OriginEffect.SFXOverride.Spawn(Target.transform);
            }
            else if (Buff.SFX != null)
            {
                SfxInstance = Buff.SFX.Spawn(Target.transform);
            }
        }

        public void ApplyBuffMod(ModHandler mod)
        {
            _mods.Add(mod);
        }

        void ApplyMods()
        {
            for (int i = 0; i < _mods.Count; i++)
            {
                _mods[i].AddTo(Target);
            }
        }

        void RemoveMods()
        {
            for (int i = 0; i < _mods.Count; i++)
            {
                _mods[i].RemoveFrom(Target);
            }
        }

        public void Tick()
        {
            Buff.OnTick(this);
        }

        public void Remove()
        {
            Buff.OnRemove(this);

            if (Target != null)
            {
                Target.BuffEvents.Trigger(EventFlag.LOSE_BUFF, this);
                Target.Buffs.Remove(this);
                RemoveMods();
            }

            if (SfxInstance != null)
            {
                SfxInstance.Despawn();
            }
        }

        public void Expire()
        {
            Buff.OnExpire(this);
            Remove();
        }
    }
}