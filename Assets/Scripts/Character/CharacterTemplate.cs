using UnityEngine;

using SkySeekers.AbilitySystem;

[CreateAssetMenu(menuName = "Character/Template")]
public class CharacterTemplate : ScriptableObject
{
    [SerializeField]
    string _name;
    public string Name { get { return _name; } }

    [SerializeField]
    AbilityTemplate[] _abilities;
    public AbilityTemplate[] Abilities { get { return _abilities; } }

    [SerializeField]
    float _health;
    public float Health { get { return _health; } }
    [SerializeField]
    float _attackPower;
    public float AttackPower { get { return _attackPower; } }
    [SerializeField]
    float _armor;
    public float Armor { get { return _armor; } }

    [Space]
    [SerializeField]
    float _critChance;
    public float CritChance { get { return _critChance; } }

    [SerializeField]
    float _critMultiplier;
    public float CritMultiplier { get { return _critMultiplier; } }

}