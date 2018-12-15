
using UnityEngine.Events;

namespace SkySeekers.AbilitySystem
{
    public class AbilityModHandler : ModHandler
    {
        public static AbilityModHandler Generate(EventFlag flag, UnityAction<AbilityInstance> mod, int priority = 0)
        {
            AbilityModHandler newMod = new AbilityModHandler(flag, new Modifier<AbilityInstance>(mod, priority));
            return newMod;
        }

        Modifier<AbilityInstance> _mod;
        EventFlag _flag;

        AbilityModHandler(EventFlag flag, Modifier<AbilityInstance> mod)
        {
            _flag = flag;
            _mod = mod;
        }

        public override void AddTo(EventHandlerObject handler)
        {
            handler.AbilityEvents.Add(_flag, _mod);
        }

        public override void RemoveFrom(EventHandlerObject handler)
        {
            handler.AbilityEvents.Remove(_flag, _mod);
        }
    }

    public class AbilityEvent : UnityEvent<AbilityInstance> { } 
}