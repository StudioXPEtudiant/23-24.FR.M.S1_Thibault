using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerController))]
public class PlayerScript : MonoBehaviour
{
    [Header("Parameters Vars")] 
    public bool onLadder = false;
    
    [Header("Player Variable")]
    public float velocity = 10;
    public float jumpForce = 1;
    public float climbSpeed = 10;
    
    [Header("Behaviour")]
    [SerializeField] private PlayerController playercontroller;
    [SerializeField] private PlayerMotor playerMotor;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!playercontroller)
        {
            playercontroller = GetComponent<PlayerController>();
        }
        if (!playerMotor)
        {
            playerMotor = GetComponent<PlayerMotor>();
        }
    }
}
