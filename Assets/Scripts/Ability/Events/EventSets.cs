using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace SkySeekers.AbilitySystem
{
    public class EventSets<T> where T : InstanceBase
    {
        Dictionary<EventFlag, PriorityModList<T>> _events = new Dictionary<EventFlag, PriorityModList<T>>();

        Modifier<T> _terminalAction;

        public EventSets()
        {
            foreach (EventFlag flag in Enum.GetValues(typeof(EventFlag)))
            {
                _events[flag] = new PriorityModList<T>();
            }
        }

        public void SetTerminalAction(EventFlag flag, UnityAction<T> action)
        {
            if (_terminalAction != null)
            {
                Remove(flag, _terminalAction);
            }
            _terminalAction = new Modifier<T>(action, 999999999);
            Add(flag, _terminalAction);
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