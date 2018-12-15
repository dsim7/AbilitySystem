
using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [CreateAssetMenu(menuName = "Ability/SFX/SFXPool")]
    public class AbilitySFXPool : ObjectPool<AbilitySFX>
    {
        [Space]
        [SerializeField]
        AbilitySFXPoolSet _poolSet;

        public void OnEnable()
        {
            if (_poolSet != null)
            {
                _poolSet.Add(this);
            }
        }

        public void OnDisable()
        {
            if (_poolSet != null)
            {
                _poolSet.Remove(this);
            }
        }

        public AbilitySFX Spawn(Transform spawnPoint)
        {
            AbilitySFX sfx = GetNext();
            sfx.Spawn(spawnPoint);
            return sfx;
        }
    }
}