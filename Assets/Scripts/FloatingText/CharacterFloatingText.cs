
using UnityEngine;

public class CharacterFloatingText : MonoBehaviour
{
    [SerializeField]
    FloatingTextPool _pool;

    public void ShowText(string text, Color color, float size=1f)
    {
        _pool.ShowNext(transform, text, color, size);
    }
}
