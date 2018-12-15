using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [RequireComponent(typeof(EventHandler))]
    public class AbilityCaster : MonoBehaviour
    {
        EventHandler _eventHandler;
        public EventHandler EventHandler { get { return _eventHandler; } }
        Animator _animator;
        public Animator Animator { get { return _animator; } }

        public Ability[] Abilities { get; private set; }

        AbilityInstance _abilityBeingCast;
        public AbilityInstance AbilityBeingCast { get { return _abilityBeingCast; } }

        int canActBuffer = 0;
        public bool CanAct { get { return canActBuffer == 0; } }

        [SerializeField]
        AbilityTemplateSet _abilityTemplates;
        public AbilityTemplateSet AbilityTemplates
        {
            get { return _abilityTemplates; }

            set
            {
                RemovePassives(_abilityTemplates.Templates);
                _abilityTemplates = value;
                Init();
            }
        }
        [SerializeField]
        float _critChance;
        public float CritChance { get { return _critChance; } set { _critChance = value; } }
        [SerializeField]
        float _critMultiplier;
        public float CritMultiplier { get { return _critMultiplier; } set { _critMultiplier = value; } }


        void Start()
        {
            _eventHandler = GetComponent<EventHandler>();
            _animator = GetComponent<Animator>();
            
            Init();
        }

        void Update()
        {
            for (int i = 0; i < Abilities.Length; i++)
            {
                if (Abilities[i] != null)
                {
                    Abilities[i].UpdateCooldown();
                }
            }
        }

        void Init()
        {
            if (_abilityTemplates != null)
            {
                SetAbilities(_abilityTemplates.Templates);
                AddPassives();
            }
        }

        void SetAbilities(AbilityTemplate[] templates)
        {
            Abilities = new Ability[templates.Length];
            for (int i = 0; i < templates.Length; i++)
            {
                AbilityTemplate template = templates[i];
                if (template != null)
                {
                    Abilities[i] = new Ability(template);
                }
            }
        }

        void AddPassives()
        {
            for (int i = 0; i < Abilities.Length; i++)
            {
                Buff passive = Abilities[i].Passive;
                if (passive != null)
                {
                    Abilities[i].PassiveInstance = 
                        BuffInstance.ApplyBuff(null, passive, this, _eventHandler, null);
                }
            }
        }

        void RemovePassives(AbilityTemplate[] templates)
        {
            for (int i = 0; i < Abilities.Length; i++)
            {
                Abilities[i].PassiveInstance.Remove();
            }
        }

        public bool CastAbility(int abilityIndex)
        {
            if (CanCastSpell(abilityIndex))
            {
                _abilityBeingCast = Abilities[abilityIndex].Cast(this);
                return true;
            }
            return false;
        }

        bool CanCastSpell(int abilityIndex)
        {
            return CanAct &&   // not silenced
                abilityIndex >= 0 && abilityIndex < Abilities.Length &&  // ability Index in rage
                Abilities[abilityIndex] != null &&    // ability is not null
                (_abilityBeingCast == null || Abilities[abilityIndex].Template.OverridesCast);  // currently not casting an ability, or casted ability overrides
        }

        public bool CompleteAbility()
        {
            if (_abilityBeingCast != null)
            {
                _abilityBeingCast.Complete();
                _abilityBeingCast = null;
                return true;
            }
            return false;
        }

        public void AddDisabler()
        {
            canActBuffer++;
        }

        public void RemoveDisabler()
        {
            canActBuffer--;
        }
    }
}