using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToCombat()
    {
        Debug.Log("Function");
        StartCoroutine("GoToCombatCoroutine");
    }

    IEnumerator GoToCombatCoroutine()
    {
        Debug.Log("Coroutine");
        SceneManager.LoadScene("Combat");
        yield return null;
    }
}
