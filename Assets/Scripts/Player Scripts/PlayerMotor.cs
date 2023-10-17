using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public float verticalInput;
    public float horizontalInput;
    private bool isGrounded;
    
    public int currentJumpCount;
    public int maxJump = 1;

    [Header("Animator System")] 
    [SerializeField] private string animatorMoveHorizontalParameterName;
    [SerializeField] private string animatorMoveVerticalParameterName;
    
    [Header("Ground System")]
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;
    
    [Header("Behaviours")]
    private PlayerScript player;
    private Rigidbody2D _rb2d;
    [SerializeField] Animator animator;

    

    private void Start()
    {
        if (!_rb2d) {_rb2d = GetComponent<Rigidbody2D>();}
    
        if (!player) {player = GetComponent<PlayerScript>();}
        
        if (!animator) {Debug.LogError("Animator of player missing");}

        currentJumpCount = maxJump;
    }
    
    private void Update()
    {
        // Stocke les inputs du joueur dans des variables
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        SetAnimationFloat(animatorMoveHorizontalParameterName, horizontalInput);
        SetAnimationFloat(animatorMoveVerticalParameterName ,verticalInput);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    
    private void SetAnimationFloat(string _animationName, float _value)
    {
        animator.SetFloat(_animationName, _value);
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb2d.velocity = new Vector2(horizontalInput * player.velocity, _rb2d.velocity.y);
    }

    private void Jump()
    {
        bool isOnGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);
        
        if (isOnGround)
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, player.jumpForce);

            currentJumpCount -= 1;
            
            currentJumpCount = maxJump;
        }
        else if (!isOnGround && currentJumpCount >= 1)
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, player.jumpForce);
            
            currentJumpCount -= 1;
        }
    }

    public void RefreshCurrentJumpCount()
    {
        currentJumpCount = maxJump;
        
        Debug.Log("CurrentJump Refreshing...");
    }
}