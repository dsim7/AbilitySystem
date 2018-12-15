
using System.Linq;
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/Targeting/Melee")]
    public class TargetingInstantMelee : AbilityTargeting
    {
        [SerializeField]
        LayerMask _layer;

        public override EventHandlerObject[] GetTargets(AbilityCaster caster)
        {
            CharacterMeleeVector meleeVector = caster.EventHandler.GetComponent<Character>().MeleeVector;
            if (meleeVector == null)
            {
                Debug.LogWarning("Caster has no melee vector.");
                return new EventHandlerObject[0];
            }
            Collider[] targetColliders = Physics.OverlapSphere(meleeVector.HitTransform.position,
                meleeVector.HitRadius, _layer);
            EventHandlerObject[] targets = targetColliders.Select(collider => collider.GetComponent<EventHandlerObject>()).ToArray();
            targets = targets.Where(target => target != caster.GetComponent<EventHandlerObject>()).ToArray();
            return targets;
        }
    }
}
