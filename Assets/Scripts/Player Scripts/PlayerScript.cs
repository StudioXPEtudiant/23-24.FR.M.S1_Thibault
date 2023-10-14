using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerController))]
public class PlayerScript : MonoBehaviour
{
    public bool onLadder = false;
    
    public float velocity = 10;
    public float jumpForce = 1;
    public float climbSpeed = 10;
    
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerMotor playerMotor;
    
    void Start()
    {
        if (!playerController)
        {
            playerController = GetComponent<PlayerController>();
        }
        if (!playerMotor)
        {
            playerMotor = GetComponent<PlayerMotor>();
        }
    }
}