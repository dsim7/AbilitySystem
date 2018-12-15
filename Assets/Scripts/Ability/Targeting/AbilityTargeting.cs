using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    public abstract class AbilityTargeting : ScriptableObject
    {
        [SerializeField]
        bool _targetAtStart = true;
        public bool TargetAtStart { get { return _targetAtStart; } }

        public abstract EventHandler[] GetTargets(AbilityCaster caster);
    }
}