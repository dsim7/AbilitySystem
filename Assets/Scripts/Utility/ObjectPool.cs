using UnityEngine;

public class ObjectPool<T> : ScriptableObject where T : Component
{
    [SerializeField]
    T _prefab;
    [SerializeField]
    T[] _pool;
    [SerializeField]
    int _poolSize;
    int _index = 0;

    public void Init(Transform parent)
    {
        _index = 0;
        _pool = new T[_poolSize];
        for (int i = 0; i < _pool.Length; i++)
        {
            if (parent != null)
            {
                _pool[i] = Instantiate(_prefab, parent);
            }
            else
            {
                _pool[i] = Instantiate(_prefab);
            }
        }
    }

    protected T GetNext()
    {
        if (_index >= _pool.Length)
        {
            _index = 0;
        }
        if (_pool[_index] == null)
        {
            _pool[_index] = Instantiate(_prefab);
        }
        return _pool[_index++];
    }
}
