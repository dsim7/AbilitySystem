
using System;

namespace SkySeekers.AbilitySystem
{
    [Serializable]
    public class AbilityInstance : InstanceBase
    {
        Ability _ability;
        public Ability Ability { get { return _ability; } }
        AbilityCaster _caster;
        public AbilityCaster Caster { get { return _caster; } }
        EventHandlerObject[] _targets;
        public EventHandlerObject[] Targets { get { return _targets; } }
        AbilityData _data;
        public AbilityData Data { get { return _data; } }

        public static AbilityInstance Cast(Ability originAbility, AbilityCaster caster,
            EventHandlerObject[] targets, AbilityData data)
        {
            AbilityInstance instance = new AbilityInstance(originAbility, caster, targets, data);
            instance.Start();
            return instance;
        }

        AbilityInstance(Ability originAbility, AbilityCaster caster,
            EventHandlerObject[] targets, AbilityData data)
        {
            _ability = originAbility;
            _caster = caster;
            _targets = targets;
            _data = data;
        }

        void Start()
        {
            _caster.EventHandler.AbilityEvents.Trigger(EventFlag.START_CASTING_ABILITY, this);
            if (_targets != null)
            {
                for (int i = 0; i < _targets.Length; i++)
                {
                    _targets[i].AbilityEvents.Trigger(EventFlag.TARGETED_BY_ABILITY, this);
                }
            }
        }

        public void Complete()
        {
            _caster.EventHandler.AbilityEvents.Trigger(EventFlag.FINISH_CASTING_ABILITY, this);

            // Search for targets again
            if (_targets == null)
            {
                _targets = _ability.Template.Targeting.GetTargets(_caster);
            }

            // Validate targets and run events
            if (Ability.HasValidTarget(_targets))
            {
                for (int i = 0; i < _targets.Length; i++)
                {
                    if (_targets[i] != null)
                    {
                        _targets[i].AbilityEvents.Trigger(EventFlag.HIT_BY_ABILITY, this);
                    }
                }
            }

            // Apply Effects
            AbilityEffect[] effects = _ability.Template.Effects;
            for (int i = 0; i < effects.Length; i++)
            {
                if (effects[i] != null)
                {
                    effects[i].ApplyEffect(_caster, _targets, _data);
                }
            }
        }
    }
}