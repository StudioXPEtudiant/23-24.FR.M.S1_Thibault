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
    [SerializeField] private PlayerScript player;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Animator animator;
    [SerializeField] private LadderScript ladderScript;

    

    private void Start()
    {
        InitAllVars();
    }

    private void InitAllVars()
    {
        if (!rb2d) {rb2d = GetComponent<Rigidbody2D>();}
    
        if (!player) {player = GetComponent<PlayerScript>();}

        if (!animator) {animator = GetComponent<Animator>();}
        
        if (!ladderScript) {ladderScript = GetComponent<LadderScript>();}
        
        if (!animator) {Debug.LogError("Animator of player missing");}
        
        currentJumpCount = maxJump;
    }
    
    private void Update()
    {
        // Stocke les inputs du joueur dans des variables
        horizontalInput = Input.GetAxis("Horizontal");
        float AbsHorizontalInput = Mathf.Abs(horizontalInput);
        
        verticalInput = Input.GetAxis("Vertical");
        
        SetAnimationFloat(animatorMoveHorizontalParameterName, AbsHorizontalInput);
        SetAnimationFloat(animatorMoveVerticalParameterName ,verticalInput);

        if (!ladderScript.onLadder)
        {
            SetAnimationFloat(animatorMoveVerticalParameterName ,0f);
        }
        
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
        
        Flip(rb2d.velocity.x);
    }

    private void Move()
    {
        rb2d.velocity = new Vector2(horizontalInput * player.velocity, rb2d.velocity.y);
    }

    private void Jump()
    {
        bool isOnGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);
        
        if (isOnGround)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, player.jumpForce);

            currentJumpCount -= 1;
            
            currentJumpCount = maxJump;
        }
        else if (!isOnGround && currentJumpCount >= 1)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, player.jumpForce);
            
            currentJumpCount -= 1;
        }
    }

    public void RefreshCurrentJumpCount()
    {
        currentJumpCount = maxJump;
    }
    
    private void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            player.spriteRenderer.flipX = false;
        }else if (_velocity < -0.1f)
        {
            player.spriteRenderer.flipX = true;
        }
    }
}