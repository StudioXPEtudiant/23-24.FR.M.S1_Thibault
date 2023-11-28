using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIScript : MonoBehaviour
{
    [Header("Behaviour")]
    [SerializeField] private HealthBarScript healthBarScript;
    
    [Header("GameObjects")] 
    [SerializeField] private GameObject espaceMenu;
    [SerializeField] private GameObject activeUI;
    
    public void ToggleEscapeMenu()
    {
        espaceMenu.SetActive(!espaceMenu.activeSelf);
        
        activeUI.SetActive(!activeUI.activeSelf);
    }

    public void SendHealthValueToUI(int value)
    {
        healthBarScript.SetHealthBarFill(value);
    }
}
