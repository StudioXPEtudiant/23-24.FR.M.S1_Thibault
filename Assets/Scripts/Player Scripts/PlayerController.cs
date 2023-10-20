using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Behaviour")] 
    [SerializeField] private PlayerUIScript playerUIScript;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerUIScript.ToggleEscapeMenu();
        }
    }
}
