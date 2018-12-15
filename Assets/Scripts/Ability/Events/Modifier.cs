
using UnityEngine.Events;

namespace SkySeekers.AbilitySystem
{
    public class Modifier<T> where T : InstanceBase
    {
        public UnityAction<T> Action { get; private set; }
        public int Priority { get; private set; }

        public Modifier(UnityAction<T> action, int priority = 0)
        {
            Action = action;
            Priority = priority;
        }

        public void Invoke(T instance)
        {
            Action.Invoke(instance);
        }
    }
}