using System.Collections.Generic;
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/AbilityTemplate", order = 5)]
    public class AbilityTemplate : ScriptableObject
    {
        [SerializeField]
        string _name;
        public string Name { get { return _name; } }
        [SerializeField]
        [TextArea(7,20)]
        string _tooltip;
        public string Tooltip { get { return _tooltip; } }

        [Space]
        [SerializeField]
        AbilityType _type;
        public AbilityType Type { get { return _type; } }
        [SerializeField]
        AbilityEffect[] _effects;
        public AbilityEffect[] Effects { get { return _effects; } }
        [SerializeField]
        float _baseCooldown;
        public float BaseCooldown { get { return _baseCooldown; } }
        [SerializeField]
        AbilityTargeting _targeting;
        public AbilityTargeting Targeting { get { return _targeting; } }
        [SerializeField]
        string _animationName;
        public string AnimationName { get { return _animationName; } }
        [SerializeField]
        bool _overridesCast;
        public bool OverridesCast { get { return _overridesCast; } }
        [SerializeField]
        Buff _passive;
        public Buff Passive { get { return _passive; } }

        [Header("General Data")]
        [SerializeField]
        float _mainValue;
        public float MainValue { get { return _mainValue; } }
        [SerializeField]
        DamageType _mainType;
        public DamageType MainType { get { return _mainType; } }
        [SerializeField]
        float _secondaryValue;
        public float SecondaryValue { get { return _secondaryValue; } }
        [SerializeField]
        DamageType _secondaryType;
        public DamageType SecondaryType { get { return _secondaryType; } }
        [SerializeField]
        float _tertiaryValue;
        public float TertiaryValue { get { return _tertiaryValue; } }
        [SerializeField]
        DamageType _tertiaryType;
        public DamageType TertiaryType { get { return _tertiaryType; } }
        [Space]
        [SerializeField]
        float _duration;
        public float Duration { get { return _duration; } }
        [SerializeField]
        float _tickInterval;
        public float TickInterval { get { return _tickInterval; } }
        [SerializeField]
        AbilitySFXPool _sfx;
        public AbilitySFXPool SFX { get { return _sfx; } }

        [Header("Misc Float Data")]
        [SerializeField]
        List<AbilityDataLabel> floatDataKeys;
        [SerializeField]
        List<float> floatData;

        [Header("Misc Type Data")]
        [SerializeField]
        List<AbilityDataLabel> typeDataKeys;
        [SerializeField]
        List<DamageType> typeData;

        [Header("Misc Integer Data")]
        [SerializeField]
        List<AbilityDataLabel> intDataKeys;
        [SerializeField]
        List<int> intData;

        public AbilityData GenerateData()
        {
            Dictionary<AbilityDataLabel, int> intDataDict = new Dictionary<AbilityDataLabel, int>();
            for (int i = 0; i < intDataKeys.Count; i++)
            {
                intDataDict.Add(intDataKeys[i], intData[i]);
            }

            Dictionary<AbilityDataLabel, float> floatDataDict = new Dictionary<AbilityDataLabel, float>();
            for (int i = 0; i < floatDataKeys.Count; i++)
            {
                floatDataDict.Add(floatDataKeys[i], floatData[i]);
            }

            Dictionary<AbilityDataLabel, DamageType> typeDataDict = new Dictionary<AbilityDataLabel, DamageType>();
            for (int i = 0; i < typeDataKeys.Count; i++)
            {
                typeDataDict.Add(typeDataKeys[i], typeData[i]);
            }

            return new AbilityData(_mainValue, _secondaryValue, _tertiaryValue, _duration, _tickInterval,
                _mainType, _secondaryType, _tertiaryType, _sfx,
                intDataDict, floatDataDict, typeDataDict);
        }

    }
}