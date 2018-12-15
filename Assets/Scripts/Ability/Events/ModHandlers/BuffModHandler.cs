
using UnityEngine.Events;

namespace SkySeekers.AbilitySystem
{
    public class BuffModHandler : ModHandler
    {
        public static BuffModHandler Generate(EventFlag flag, UnityAction<BuffInstance> mod, int priority = 0)
        {
            BuffModHandler newMod = new BuffModHandler(flag, new Modifier<BuffInstance>(mod, priority));
            return newMod;
        }

        Modifier<BuffInstance> _mod;
        EventFlag _flag;

        BuffModHandler(EventFlag flag, Modifier<BuffInstance> mod)
        {
            _flag = flag;
            _mod = mod;
        }

        public override void AddTo(EventHandler handler)
        {
            handler.BuffEvents.Add(_flag, _mod);
        }

        public override void RemoveFrom(EventHandler handler)
        {
            handler.BuffEvents.Remove(_flag, _mod);
        }
    }

    public class DamageEvent : UnityEvent<DamageInstance> { }

}