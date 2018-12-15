
using UnityEngine;

using SkySeekers.AbilitySystem;

public class SOInitializer : MonoBehaviour
{
    [SerializeField]
    AbilitySFXPoolSet _sfxPoolSet;
    [SerializeField]
    FloatingTextPool _floatingTextPool;

	void Start () {
        for (int i = 0; i < _sfxPoolSet.Items.Count; i++)
        {
            _sfxPoolSet.Items[i].Init(transform);
        }

        _floatingTextPool.Init(transform);
	}
	
}
