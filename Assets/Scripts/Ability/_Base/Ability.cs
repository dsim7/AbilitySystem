using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    public class Ability
    {
        AbilityTemplate _template;
        public AbilityTemplate Template { get { return _template; } }
        AbilityData _data;
        public AbilityData Data { get { return _data; } }
        
        public float Cooldown { get; set; }
        public float CurrentCooldown { get; set; }
        public Buff Passive { get; private set; }
        public BuffInstance PassiveInstance { get; set; }

        public Ability(AbilityTemplate template)
        {
            _template = template;
            Cooldown = template.BaseCooldown;
            _data = _template.GenerateData();
            if (_template.Passive != null)
            {
                Passive = _template.Passive;
            }
        }

        public AbilityInstance Cast(AbilityCaster caster)
        {
            if (CurrentCooldown <= 0)
            {
                EventHandler[] targets = null;

                // If the Ability targets at start, search for targets
                if (Template.Targeting.TargetAtStart)
                {
                    targets = _template.Targeting.GetTargets(caster);
                }
                if (!Template.Targeting.TargetAtStart || HasValidTarget(targets))
                {
                    AbilityInstance instance = AbilityInstance.Cast(this, caster, targets, new AbilityData(Data));

                    CurrentCooldown = Cooldown;

                    if (caster.Animator != null)
                    {
                        caster.Animator.SetTrigger(_template.AnimationName);
                    }

                    return instance;
                }
            }
            return null;
        }

        public AbilityInstance Complete(AbilityInstance instance)
        {
            instance.Complete();
            return instance;
        }

        public void UpdateCooldown()
        {
            if (CurrentCooldown > 0)
            {
                CurrentCooldown -= Time.deltaTime;
            }
        }

        public static bool HasValidTarget(EventHandler[] targets)
        {
            if (targets != null)
            {
                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}