using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private float moveInput;

    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;

    private bool isGrounded; 
    
    private PlayerScript player;
    private Rigidbody2D _rb2d;

    private void Start()
    {
        if (!_rb2d)
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }
        
        if (!player)
        {
            player = GetComponent<PlayerScript>();
        }
    }
    
    private void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb2d.velocity = new Vector2(moveInput * player.velocity, _rb2d.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckIfGrounded();
            
            if (isGrounded)
            {
                _rb2d.velocity = new Vector2(_rb2d.velocity.x, player.jumpForce);
            }
        }
    }

    public void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);
    }
}
