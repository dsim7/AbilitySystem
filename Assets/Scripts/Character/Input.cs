
using UnityEngine;

public class Input : MonoBehaviour
{
    [SerializeField]
    Character _character;
	
	void Update () {
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            CharacterSelectTarget();
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
        {
            _character.Caster.CastAbility(0);
        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
        {
            _character.Caster.CastAbility(1);
        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
        {
            _character.Caster.CastAbility(2);
        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha4))
        {
            _character.Caster.CastAbility(3);
        }
    }

    void CharacterSelectTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _character = hit.transform.GetComponent<Character>();
        }
    }
}
