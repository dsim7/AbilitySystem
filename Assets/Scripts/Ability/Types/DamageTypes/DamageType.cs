using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Types/DamageType")]
    public class DamageType : ScriptableObject
    {
        [SerializeField]
        public Color Color;
    }
}