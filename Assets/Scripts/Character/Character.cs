
using UnityEngine;

using SkySeekers.AbilitySystem;
using System.Text;

[RequireComponent(typeof(CharacterTargeting))]
[RequireComponent(typeof(CharacterFloatingText))]
public class Character : MonoBehaviour
{
    [SerializeField]
    CharacterTemplate _template;
    public CharacterTemplate Template { get { return _template; } }

    AbilityCaster _caster;
    public AbilityCaster Caster { get { return _caster; } }
    EventHandlerObject _eventHandler;
    public EventHandlerObject EventHandler { get { return _eventHandler; } }

    CharacterTargeting _targeting;
    public CharacterTargeting Targeting { get { return _targeting; } }
    CharacterFloatingText _floatingText;
    public CharacterFloatingText FloatingText { get { return _floatingText; } }
    CharacterMeleeVector _meleeVector;
    public CharacterMeleeVector MeleeVector { get { return _meleeVector; } }

    [SerializeField]
    float _maxHealth;
    public float MaxHealth { get { return _maxHealth; } protected set { _maxHealth = value; } }
    [SerializeField]
    float _attackPower;
    public float AttackPower { get { return _attackPower; } protected set { _attackPower = value; } }
    [SerializeField]
    float _armor;
    public float Armor { get { return _armor; } protected set { _armor = value; } }
    [SerializeField]
    float _health;
    public float Health { get { return _health; } protected set { _health = value; } }
    [SerializeField]
    bool _dead;
    public bool Dead { get { return _dead; } protected set { _dead = value; } }
    
    void Awake()
    {
        _caster = GetComponent<AbilityCaster>();
        _eventHandler = GetComponent<EventHandlerObject>();
        _targeting = GetComponent<CharacterTargeting>();
        _floatingText = GetComponent<CharacterFloatingText>();
        _meleeVector = GetComponent<CharacterMeleeVector>();

        MaxHealth = _template.Health;
        AttackPower = _template.AttackPower;
        Armor = _template.Armor;
        Health = MaxHealth;
        Dead = false;
    }

    void Start()
    {
        _eventHandler.AttackEvents.SetTerminalAction(EventFlag.MISSED, AttackMiss);
        _eventHandler.DamageEvents.SetTerminalAction(EventFlag.TAKE_DAMAGE, TakeDamage);
    }

    void TakeDamage(DamageInstance inst)
    {
        TakeDamage(inst.Amount, inst.Type, inst.IsCrit, inst.IsDefended);
    }

    void TakeDamage(float amount, DamageType type, bool crit, bool defended)
    {
        if (!Dead)
        {
            if (amount < 0)
            {
                amount = 0;
            }

            Health = Mathf.Clamp(Health - amount, 0, _template.Health);

            if (_floatingText != null)
            {
                _floatingText.ShowText(GenerateDamageText(amount, crit), GenerateDamageColor(type, defended), 1.5f);
            }

            if (Health == 0)
            {
                Die();
            }
        }
    }

    string GenerateDamageText(float amount, bool crit)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(amount.ToString("F0"));
        sb.Append(crit ? "!" : "");
        return sb.ToString();
    }

    Color GenerateDamageColor(DamageType type, bool defended)
    {
        Color color = type.Color;
        if (defended)
        {
            color.r *= 0.75f;
            color.g *= 0.75f;
            color.b *= 0.75f;
        }
        return color;
    }

    void AttackMiss(AttackInstance inst)
    {
        if (_floatingText != null)
        {
            _floatingText.ShowText("Missed", Color.white, 1f);
        }
    }

    public void Die()
    {
        Dead = true;
        Health = 0;
        Debug.Log("ded");
    }
    
}
