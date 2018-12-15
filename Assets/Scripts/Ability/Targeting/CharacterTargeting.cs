using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    public class CharacterTargeting : MonoBehaviour
    {
        EventHandler _currentTarget;
        public EventHandler CurrentTarget
        {
            get { return _currentTarget; }
            set { _currentTarget = value; Debug.Log("Target set to " + _currentTarget); }
        }
    }
}
