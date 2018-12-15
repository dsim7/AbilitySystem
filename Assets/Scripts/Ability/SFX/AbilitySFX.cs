
using System.Collections;
using UnityEngine;

namespace SkySeekers.AbilitySystem
{

    public class AbilitySFX : MonoBehaviour
    {
        public bool clearOnEnd;

        ParticleSystem _particle;

        void Start()
        {
            _particle = GetComponent<ParticleSystem>();
        }

        public void Spawn(Transform spawnPoint)
        {
            transform.SetParent(spawnPoint);
            transform.localPosition = Vector3.zero;
            transform.localScale = new Vector3(1, 1, 1);
            _particle.Play();
        }

        public void Despawn()
        {
            _particle.Stop();
            if (clearOnEnd)
            {
                _particle.Clear();
            }
        }
    }
}