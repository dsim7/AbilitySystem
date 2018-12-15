
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SkySeekers.AbilitySystem
{
    public class EventHandler : MonoBehaviour
    {
        public List<BuffInstance> Buffs { get; private set; }

        public EventSets<AbilityInstance> AbilityEvents { get; private set; }
        public EventSets<AttackInstance> AttackEvents { get; private set; }
        public EventSets<DamageInstance> DamageEvents { get; private set; }
        public EventSets<BuffInstance> BuffEvents { get; private set; }

        void Awake()
        {
            Buffs = new List<BuffInstance>();

            AbilityEvents = new EventSets<AbilityInstance>();
            AttackEvents = new EventSets<AttackInstance>();
            DamageEvents = new EventSets<DamageInstance>();
            BuffEvents = new EventSets<BuffInstance>();
        }

        void Update()
        {
            for (int i = 0; i < Buffs.Count; i++)
            {
                Buffs[i].UpdateTime();
            }
        }
    }
}


