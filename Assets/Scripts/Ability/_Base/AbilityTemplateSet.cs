
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/AbilityTemplateSet", order = 6)]
    public class AbilityTemplateSet : ScriptableObject
    {
        [SerializeField]
        AbilityTemplate[] _templates;
        public AbilityTemplate[] Templates { get { return _templates; } }
    }
}