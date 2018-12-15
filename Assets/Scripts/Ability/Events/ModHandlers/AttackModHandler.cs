
using UnityEngine.Events;

namespace SkySeekers.AbilitySystem
{
    public class AttackModHandler : ModHandler
    {
        public static AttackModHandler Generate(EventFlag flag, UnityAction<AttackInstance> mod, int priority=0)
        {
            AttackModHandler newMod = new AttackModHandler(flag, new Modifier<AttackInstance>(mod, priority));
            return newMod;
        }

        Modifier<AttackInstance> _mod;
        EventFlag _flag;

        AttackModHandler(EventFlag flag, Modifier<AttackInstance> mod)
        {
            _flag = flag;
            _mod = mod;
        }

        public override void AddTo(EventHandlerObject handler)
        {
            handler.AttackEvents.Add(_flag, _mod);
        }

        public override void RemoveFrom(EventHandlerObject handler)
        {
            handler.AttackEvents.Remove(_flag, _mod);
        }
    }

    public class AttackEvent : UnityEvent<AttackInstance> { }

}