using UnityEngine;

public class CharacterMeleeVector : MonoBehaviour
{
    [SerializeField]
    Transform _hitTransform;
    public Transform HitTransform { get { return _hitTransform; } }

    [SerializeField]
    float _hitRadius;
    public float HitRadius { get { return _hitRadius; } }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_hitTransform.position, _hitRadius);
    }
}