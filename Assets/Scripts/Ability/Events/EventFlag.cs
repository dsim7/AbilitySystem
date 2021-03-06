﻿
namespace SkySeekers.AbilitySystem
{
    public enum EventFlag
    {
        APPLY_BUFF,
        GAIN_BUFF,
        LOSE_BUFF,

        DEAL_DAMAGE,
        TAKE_DAMAGE,

        ATTACK,
        ATTACKED,
        CRIT,
        CRITTED,
        DEFEND,
        DEFENDED,
        MISS,
        MISSED,
        HIT_WITH_ATTACK,
        HIT_BY_ATTACK,

        START_CASTING_ABILITY,
        FINISH_CASTING_ABILITY,
        TARGETED_BY_ABILITY,
        HIT_BY_ABILITY,
    }
}
