using System;
using System.Collections.Generic;

namespace SkySeekers.AbilitySystem
{
    public class EventHandler<T> where T : InstanceBase
    {
        Dictionary<EventFlag, PriorityModList<T>> _events = new Dictionary<EventFlag, PriorityModList<T>>();

        public EventHandler()
        {
            foreach (EventFlag flag in Enum.GetValues(typeof(EventFlag)))
            {
                _events[flag] = new PriorityModList<T>();
            }
        }
        
        public void Add(EventFlag flag, Modifier<T> mod)
        {
            _events[flag].AddAction(mod);
        }

        public void Remove(EventFlag flag, Modifier<T> mod)
        {
            _events[flag].RemoveAction(mod);
        }

        public void Trigger(EventFlag flag, T instance)
        {
            _events[flag].Invoke(instance);
        }

        class PriorityModList<K> where K : InstanceBase
        {
            List<Modifier<K>> _actions = new List<Modifier<K>>();

            public void AddAction(Modifier<K> action)
            {
                _actions.Add(action);
                _actions.Sort((x, y) => x.Priority.CompareTo(y.Priority));
            }

            public void RemoveAction(Modifier<K> action)
            {
                _actions.Remove(action);
            }

            public void Invoke(K action)
            {
                for (int i = 0; i < _actions.Count; i++)
                {
                    _actions[i].Invoke(action);
                }
            }
        }
    }
}