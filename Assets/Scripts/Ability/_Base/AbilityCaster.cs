using UnityEngine;

namespace SkySeekers.AbilitySystem
{
    [RequireComponent(typeof(EventHandlerObject))]
    public class AbilityCaster : MonoBehaviour
    {
        EventHandlerObject _eventHandler;
        public EventHandlerObject EventHandler { get { return _eventHandler; } }
        Animator _animator;
        public Animator Animator { get { return _animator; } }

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

        public Ability[] Abilities { get; private set; }

        AbilityInstance _abilityBeingCast;
        public AbilityInstance AbilityBeingCast { get { return _abilityBeingCast; } }

        [SerializeField]
        float _critChance;
        public float CritChance { get { return _critChance; } set { _critChance = value; } }
        [SerializeField]
        float _critMultiplier;
        public float CritMultiplier { get { return _critMultiplier; } set { _critMultiplier = value; } }


        void Start()
        {
            _eventHandler = GetComponent<EventHandlerObject>();
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
            if (abilityIndex >= 0 && abilityIndex < Abilities.Length && 
                Abilities[abilityIndex] != null &&
                (_abilityBeingCast == null || Abilities[abilityIndex].Template.OverridesCast))
            {
                Debug.Log("Setting current cast");
                _abilityBeingCast = Abilities[abilityIndex].Cast(this);
                return true;
            }
            return false;
        }

        public bool CompleteAbility()
        {
            if (_abilityBeingCast != null)
            {
                Debug.Log("Executing current cast");
                _abilityBeingCast.Complete();
                _abilityBeingCast = null;
                return true;
            }
            return false;
        }
    }
}