using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    public abstract class AbilityEffect : ScriptableObject
    {
        [SerializeField]
        AbilitySFXPool _sfx;
        public AbilitySFXPool SFXOverride { get { return _sfx; } }

        public abstract void ApplyEffect(AbilityCaster caster, EventHandler[] targets, AbilityData data);
    }
}