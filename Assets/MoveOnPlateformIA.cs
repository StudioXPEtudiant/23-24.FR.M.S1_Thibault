using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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
    
    [Header("Layers / Tags")]
    [SerializeField] private LayerMask groundLayerName;
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

        CheckIfGrounded();
    }

    private void CheckIfGrounded()
    {
        Vector2 raycastOrigin = transform.position; // Position de départ du rayon (centre du GameObject)
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, Mathf.Infinity, groundLayerName); // Lancer le rayon vers le bas

        if (!hit.collider)
        {
            Debug.Log("Le sol n'est pas touché");
            ChangeDirection();
        }
        else
        {
            Debug.Log("Le sol est touché");
            ChangeDirection();
        }
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
        SetMoveAnimatorParameter();
        
        // Vector2 newVelo = new Vector2(int_Direction * velocity, 0);
        
        rb2d.AddForce(new Vector2(int_Direction * velocity, 0));
        
        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity,velocity);
        
        Debug.Log("Velocity : " + rb2d.velocity);
    }

    private void SetMoveAnimatorParameter()
    {
        float tempVelo = rb2d.velocity.x;
        
        if (tempVelo > 0.1f)
        {
            
        } else if (tempVelo < -0.1f)
        {
            
        } else
        {
            
        }
        
        animator.SetInteger("Move Direction", tempValue);

        Vector2 tempsVeloVector = new Vector2(tempVelo, 0).normalized;
        
        Debug.Log("tempVelo" + tempsVeloVector);
    }

    private void ChangeDirection()
    {
        int_Direction *= -1;
    }
}