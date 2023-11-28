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
    private int int_Direction = 1;
    
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

    private void FixedUpdate()
    {
        IAMove();
        
        //if (CheckLeft())
        {
            int_Direction = 1;
        }
        // if (CheckRight())
        {
            int_Direction = -1;
        }
    }

    private void Start()
    {
        ConvertStrDirectionToIntDirection();
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
        
        Debug.Log("Str direction : " + int_Direction.ToString());
    }

    private void IAMove()
    {
        Vector2 newVelo = new Vector2(int_Direction * velocity / 10, 0);

        rb2d.velocity = Vector2.ClampMagnitude(new Vector2(1,1), 10);
        
        rb2d.AddForce(newVelo);
        
        Debug.Log(rb2d.velocity);
    }

    private bool CheckLeft()
    {
        if (leftCheckCollider.IsTouchingLayers(LayerMask.GetMask(groundLayerName)))
        {
            return false;
        }
        else
        {
           return true; 
        }
    }
    
    private bool CheckRight()
    {
        if (rightCheckCollider.IsTouchingLayers(LayerMask.GetMask(groundLayerName)))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
