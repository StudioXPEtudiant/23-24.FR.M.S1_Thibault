using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MoveOnPlateformIA : MonoBehaviour
{
    [Header("IA Capacitys")] 
    [SerializeField] private float velocity;
    [SerializeField] private float health;

    [Header("IA Parameters")]
    [SerializeField] bool canDoPauseRandomly;
    [SerializeField] private int pauseInterval;

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

    private int direction;

    private void FixedUpdate()
    {
        IAMove();
    }

    private void Start()
    {
        GenerateRandomDirection();
    }

    private void IAMove()
    {
        rb2d.velocity = new Vector2(direction * velocity, rb2d.velocity.y);
    }

    private void GenerateRandomDirection()
    {
        float floatDirection = Random.Range(0f, 0.1f);
        
        if (floatDirection == 0f) { direction = 1; }
        else if (floatDirection == 0.1f) { direction = -1; }
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
