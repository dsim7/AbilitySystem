using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    public class CharacterTargeting : MonoBehaviour
    {
        EventHandlerObject _currentTarget;
        public EventHandlerObject CurrentTarget
        {
            get { return _currentTarget; }
            set { _currentTarget = value; Debug.Log("Target set to " + _currentTarget); }
        }
    }
}
