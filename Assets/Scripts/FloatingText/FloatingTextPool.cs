using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatingTextPool : ObjectPool<FloatingText>
{
    public FloatingText ShowNext(Transform spawnPoint, string text, Color color, float size)
    {
        FloatingText sfx = GetNext();
        sfx.Appear(spawnPoint, text, color, size);
        return sfx;
    }
}
