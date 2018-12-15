
using System.Collections.Generic;

namespace SkySeekers.AbilitySystem
{
    public class AbilityData
    {
        public float MainValue, SecondaryValue, TertiaryValue, Duration, TickInterval;
        public DamageType MainType, SecondaryType, TertiaryType;
        public AbilitySFXPool SFX;
        public Dictionary<AbilityDataLabel, int> MiscIntData { get; set; }
        public Dictionary<AbilityDataLabel, float> MiscFloatData { get; set; }
        public Dictionary<AbilityDataLabel, DamageType> MiscTypeData { get; set; }

        public AbilityData(float mainValue, float secondaryValue, float tertiaryValue, float duration, float tickInterval,
            DamageType mainType, DamageType secondaryType, DamageType tertiaryType, AbilitySFXPool sfx,
            Dictionary<AbilityDataLabel, int> miscIntData,
            Dictionary<AbilityDataLabel, float> miscFloatData,
            Dictionary<AbilityDataLabel, DamageType> miscTypeData)
        {
            MainValue = mainValue;
            SecondaryValue = secondaryValue;
            TertiaryValue = tertiaryValue;
            Duration = duration;
            TickInterval = tickInterval;
            MainType = mainType;
            SecondaryType = secondaryType;
            TertiaryType = tertiaryType;
            SFX = sfx;
            MiscFloatData = miscFloatData;
            MiscIntData = miscIntData;
            MiscTypeData = miscTypeData;
        }

        public AbilityData(AbilityData other)
        {
            MainValue = other.MainValue;
            SecondaryValue = other.SecondaryValue;
            TertiaryValue = other.TertiaryValue;
            MainType = other.MainType;
            SecondaryType = other.SecondaryType;
            TertiaryType = other.TertiaryType;
            Duration = other.Duration;
            TickInterval = other.TickInterval;
            SFX = other.SFX;
            MiscFloatData = new Dictionary<AbilityDataLabel, float>(other.MiscFloatData);
            MiscIntData = new Dictionary<AbilityDataLabel, int>(other.MiscIntData);
            MiscTypeData = new Dictionary<AbilityDataLabel, DamageType>(other.MiscTypeData);
        }
    }
}
