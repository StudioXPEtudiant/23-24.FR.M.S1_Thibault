using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MoveOnPlateformIA : MonoBehaviour
{
    [Header("IA Capacitys")] 
    [SerializeField] private float velocity = 10;
    [SerializeField] private float health = 10;

    [Header("IA Parameters")]
    [SerializeField] bool canDoPauseRandomly = false;
    [SerializeField] private int pauseInterval = 0;
    [SerializeField] private string str_Direction;
    private int int_Direction = -1;
    
    [Header("Colliders")] 
    [SerializeField] private Collider2D baseCollider;
    [SerializeField] private Collider2D middleCheckCollider;
    [SerializeField] private Collider2D leftCheckCollider;
    [SerializeField] private Collider2D rightCheckCollider;
    
    [Header("Layers / Tags")]
    [SerializeField] private string groundLayerName;
    [SerializeField] private string playerTagName;

    [Header("Behaviours")] 
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Animator animator;
    
    
    int tempValue = 0;
    
    private void Start()
    {
        ConvertStrDirectionToIntDirection();
    }
    
    private void FixedUpdate()
    {
        IAMove();
        
        if (!CheckGrounded())
        {
            ChangeDirection();
        }
    }

    private bool CheckGrounded()
    {
        return rightCheckCollider.IsTouchingLayers(LayerMask.GetMask(groundLayerName)) || leftCheckCollider.IsTouchingLayers(LayerMask.GetMask(groundLayerName));
    }

    private void ConvertStrDirectionToIntDirection()
    {
        if (str_Direction == "right")
        {
            int_Direction = 1;
        } else if (str_Direction == "left")
        {
            int_Direction = -1;
        }
    }

    private void IAMove()
    {
        Vector2 newVelo = new Vector2(int_Direction * velocity / 10, 0);
        
        rb2d.AddForce(newVelo);
        
        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity,10);
        
        SetMoveAnimatorParameter();
    }

    private void SetMoveAnimatorParameter()
    {
        float tempVelo = rb2d.velocity.x;

        if (tempVelo > 0.1f)
        {
            tempValue = 1;
        } else if (tempVelo <= -0.1f)
        {
            tempValue = -1;
        } else
        {
            tempValue = 0;
        }
        
        animator.SetInteger("Move Direction", tempValue);
        
        Debug.Log("tempValue : " + tempValue);
    }

    private void ChangeDirection()
    {
        int_Direction *= -1;
    }
}