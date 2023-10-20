using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIScript : MonoBehaviour
{
    [Header("GameObject")] 
    [SerializeField] private GameObject espaceMenu;
    
    public void ToggleEscapeMenu()
    {
        espaceMenu.SetActive(!espaceMenu.activeSelf);
    }
}
