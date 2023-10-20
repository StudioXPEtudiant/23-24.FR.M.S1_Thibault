using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerController))]
public class PlayerScript : MonoBehaviour
{
    public float velocity = 10;
    public float jumpForce = 1;
    public float climbSpeed = 10;
    
    [Header("Behaviour")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerMotor playerMotor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        if (!playerController)
        {
            playerController = GetComponent<PlayerController>();
        }
        if (!playerMotor)
        {
            playerMotor = GetComponent<PlayerMotor>();
        }
    }

    public IEnumerator ChangeSpriteColor(Color _color, float _time)
    {
        spriteRenderer.color = _color;

        yield return new WaitForSeconds(_time);
        
        spriteRenderer.color = Color.white;
    }
}