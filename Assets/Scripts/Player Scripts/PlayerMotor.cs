using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    private bool isGrounded;

    [Header("Animator System")] 
    [SerializeField] private string animatorMoveParameterName;
    [SerializeField] private string animatorClimbParameterName;
    
    [Header("Ground System")]
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;
    
    [Header("Behaviours")]
    private PlayerScript player;
    private Rigidbody2D _rb2d;
    [SerializeField] Animator animator;

    [Header("Component")] 
    [SerializeField] private CapsuleCollider2D capsuleCollider2D;

    private void Start()
    {
        // Assignation des variables 
        if (!_rb2d) {_rb2d = GetComponent<Rigidbody2D>();}
    
        if (!player) {player = GetComponent<PlayerScript>();}
        
        if (!animator) {Debug.LogError("Animator of player missing");}
    }
    
    private void Update()
    {
        
        // Stock les inputs du joueur dans des varibales
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        // Envoie l'info de l'input du joueur a l'animator
        if (horizontalInput > 0)
        {
            SetAnimation(animatorMoveParameterName, 1);
        }
        if (horizontalInput < 0)
        {
            SetAnimation(animatorMoveParameterName, -1);
        }
        if (horizontalInput == 0)
        {
            SetAnimation(animatorMoveParameterName, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (player.onLadder)
            {
                ClimbLadder();
            }
            else
            {
                if (_rb2d.gravityScale != 1)
                {
                    _rb2d.gravityScale = 1;
                }
            }
            
        }
        else
        {
            animator.SetBool(animatorClimbParameterName, false);
            SwitchColliderDirection(false);
        }
        
        Jump();
    }

    private void SetAnimation(string _animationName, int _direction)
    {
        // Change le parametre "Move Direction" pour faire changer la direction du joueur 
        animator.SetInteger(_animationName, _direction);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // Fait bouger le joueur
        _rb2d.velocity = new Vector2(horizontalInput * player.velocity, _rb2d.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Verifie si le joueur touche le sol
            bool isOnGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);
        
            if (isOnGround)
            {
                // Si oui, faire sauter le personnage
                _rb2d.velocity = new Vector2(_rb2d.velocity.x, player.jumpForce);
            }
        }
    }


    private void ClimbLadder()
    {
        SwitchColliderDirection(true);
        
        _rb2d.gravityScale = 0;
    
        _rb2d.velocity = new Vector2(_rb2d.velocity.x, verticalInput * player.climbSpeed);
        Debug.Log("Climp methode called");
    
        animator.SetBool(animatorClimbParameterName, true);
    }

    private void SwitchColliderDirection(bool value) // Si value est a true -> Collider Verticale
    {
        if (value)
        {
            // Met le collider verticalement
            capsuleCollider2D.direction = CapsuleDirection2D.Vertical;
            capsuleCollider2D.offset = new Vector2((float)-0.0009462237, (float)-0.01945906);
            capsuleCollider2D.size = new Vector2((float)0.3922933, (float)0.6083833);
        }
        if (!value)
        {
            // Met le collider horizontalement
            capsuleCollider2D.direction = CapsuleDirection2D.Horizontal;
            capsuleCollider2D.offset = new Vector2((float)-0.005013915, (float)-0.2533293);
            capsuleCollider2D.size = new Vector2((float)0.8626499, (float)0.3910655);

        }
    }
}
