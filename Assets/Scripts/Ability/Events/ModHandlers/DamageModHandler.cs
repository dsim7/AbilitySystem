
using UnityEngine.Events;

namespace SkySeekers.AbilitySystem
{
    public class DamageModHandler : ModHandler
    {
        public static DamageModHandler Generate(EventFlag flag, UnityAction<DamageInstance> mod, int priority = 0)
        {
            DamageModHandler newMod = new DamageModHandler(flag, new Modifier<DamageInstance>(mod, priority));
            return newMod;
        }

        Modifier<DamageInstance> _mod;
        EventFlag _flag;

        DamageModHandler(EventFlag flag, Modifier<DamageInstance> mod)
        {
            _flag = flag;
            _mod = mod;
        }

        public override void AddTo(EventHandler handler)
        {
            handler.DamageEvents.Add(_flag, _mod);
        }

        public override void RemoveFrom(EventHandler handler)
        {
            handler.DamageEvents.Remove(_flag, _mod);
        }
    }

    public class BuffEvent : UnityEvent<BuffInstance> { }

}