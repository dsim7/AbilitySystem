using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FloatingText : MonoBehaviour
{
    TextMesh _childTextMesh;
    Animator _animator;
    Vector3 _random = new Vector3(1f, 0.8f, 0);

    void Start()
    {
        _childTextMesh = transform.GetChild(0).GetComponent<TextMesh>();
        _animator = GetComponent<Animator>();
    }

    public void Appear(Transform attachedTo, string text, Color color, float size)
    {
        transform.SetParent(attachedTo);
        transform.localPosition = Vector3.zero + 
            new Vector3(Random.Range(-_random.x, _random.x),
                        Random.Range(-_random.y, _random.y),
                        Random.Range(-_random.z, _random.z));
        _childTextMesh.text = text;
        _childTextMesh.color = color;
        transform.localScale = new Vector3(size, size);
        _animator.SetTrigger("Appear");
    }
}