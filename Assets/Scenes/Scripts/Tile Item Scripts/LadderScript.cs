using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    private PlayerScript playerScript;

    public bool onLadder;

    [Header("Animator System")]
    [SerializeField] private string animatorClimbParameterName;
    
    [Header("Layer Name")]
    [SerializeField] private string ladderLayerName;
    
    [Header("Component")] 
    [SerializeField] private CapsuleCollider2D capsuleCollider2D_Vertical;
    [SerializeField] private CapsuleCollider2D capsuleCollider2D_Horizontal;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMotor motor;
    
    [Header("Behaviours")]
    [SerializeField] private PlayerScript player;
    [SerializeField] private Rigidbody2D _rb2d;


    private void Start()
    {
        if (!playerScript)
        {
            playerScript = GetComponent<PlayerScript>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(ladderLayerName))
        {
            onLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(ladderLayerName))
        {
            onLadder = false;
            animator.SetBool(animatorClimbParameterName, false);
        }
    }

    private void Update()
    {
        if (onLadder)
        {
            if (motor.verticalInput != 0)
            {
                SwitchColliderDirection(true);
                animator.SetBool(animatorClimbParameterName, true);
                _rb2d.velocity = new Vector2(_rb2d.velocity.x, motor.verticalInput * player.climbSpeed);
                Debug.Log("ClimbLadder method called");
            } else if (motor.verticalInput == 0)
            {
                SwitchColliderDirection(false);
            }
        }
    }
    
    public void SwitchColliderDirection(bool value)
    {
        if (value)
        {
            capsuleCollider2D_Vertical.enabled = true;
            capsuleCollider2D_Horizontal.enabled = false;
        }
        else if (!value)
        {
            capsuleCollider2D_Horizontal.enabled = true;
            capsuleCollider2D_Vertical.enabled = false;
        }
    }
}