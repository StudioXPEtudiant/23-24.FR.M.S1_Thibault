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
    [SerializeField] private CapsuleCollider2D capsuleCollider2D_Vertical;
    [SerializeField] private CapsuleCollider2D capsuleCollider2D_Horizontal;

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
            SetMoveAnimation(animatorMoveParameterName, 1);
        }
        if (horizontalInput < 0)
        {
            SetMoveAnimation(animatorMoveParameterName, -1);
        }
        if (horizontalInput == 0)
        {
            SetMoveAnimation(animatorMoveParameterName, 0);
        }
        
        if (player.onLadder)
        {
            if (Input.GetKey(KeyCode.W))
            {
                ClimbLadder();
            }
            else
            {
                animator.SetBool(animatorClimbParameterName, false);
                SwitchColliderDirection(false);
            }
        }
        
        Jump();
    }

    private void SetMoveAnimation(string _animationName, int _direction)
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
    
        _rb2d.velocity = new Vector2(_rb2d.velocity.x, verticalInput * player.climbSpeed);
        Debug.Log("Climp methode called");
    
        animator.SetBool(animatorClimbParameterName, true);
    }

    private void SwitchColliderDirection(bool value) // Si value est a true -> Collider Verticale
    {
        if (value)
        {
            // Active le collider vertical
            capsuleCollider2D_Vertical.enabled = true;
            
            // Desactive le collider vertical
            capsuleCollider2D_Horizontal.enabled = false;
        }
        
        if (!value)
        {
            // Active le collider horizontal
            capsuleCollider2D_Horizontal.enabled = true;
            
            // Desactive le collider vertical
            capsuleCollider2D_Vertical.enabled = false;
        }
    }
}
