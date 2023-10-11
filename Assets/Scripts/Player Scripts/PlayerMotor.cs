using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private float moveInput;

    [Header("Animator System")] 
    [SerializeField] private string animatorMoveParameterName;
    
    [Header("Ground System")]
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;

    private bool isGrounded; 
    
    [Header("Behaviours")]
    private PlayerScript player;
    private Rigidbody2D _rb2d;
    [SerializeField] Animator animator;

    private void Start()
    {
        // Assignation des variables 
        if (!_rb2d) {_rb2d = GetComponent<Rigidbody2D>();}
    
        if (!player) {player = GetComponent<PlayerScript>();}
        
        if (!animator) {Debug.LogError("Animator of player missing");}
    }
    
    private void Update()
    {
        // Stock les inputs du joueur dans une varibale
        moveInput = Input.GetAxis("Horizontal");
        
        // Envoie l'info de l'input du joueur a l'animator
        if (moveInput > 0)
        {
            SetAnimation(animatorMoveParameterName, 1);
        }
        if (moveInput < 0)
        {
            SetAnimation(animatorMoveParameterName, -1);
        }
        if (moveInput == 0)
        {
            SetAnimation(animatorMoveParameterName, 0);
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
        _rb2d.velocity = new Vector2(moveInput * player.velocity, _rb2d.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Verif si le joueur touche le sol
            CheckIfGrounded();
            
            if (isGrounded)
            {
                // Si oui, faire sauter le personnage
                _rb2d.velocity = new Vector2(_rb2d.velocity.x, player.jumpForce);
            }
        }
    }

    public void CheckIfGrounded()
    {
        // Check si le collider Ground touche un objet avec le layer "Ground"
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);
    }
}
