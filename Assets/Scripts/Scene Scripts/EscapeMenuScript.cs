using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenuScript : MonoBehaviour
{
    [Header("Behaviours")]
    [SerializeField] private PlayerUIScript playerUIScript;
    
    public void GameQuit()
    {
        Application.Quit();
    }

    public void ToggleEspaceMenu_()
    {
        playerUIScript.ToggleEscapeMenu();
    }
}