using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerController))]
public class PlayerScript : MonoBehaviour
{
    [Header("Player Capacity")]
    public float velocity = 10;
    public float jumpForce = 1;
    public float climbSpeed = 10;
    public int minHealth = 0;
    public int maxHealth = 6;
    private int currentHealth;
    
    [Header("Behaviour")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerMotor playerMotor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerUIScript playerUIScript;
    
    void Start()
    {
        currentHealth = maxHealth;
        currentHealth = Mathf.Clamp(currentHealth, minHealth, maxHealth);
        
        if (!playerController)
        {
            playerController = GetComponent<PlayerController>();
        }
        if (!playerMotor)
        {
            playerMotor = GetComponent<PlayerMotor>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            IncreaseHeath(1);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            DecreaseHealth(1);
        }
    }

    public void IncreaseHeath(int value)
    {
        if (currentHealth < 6)
        {
            currentHealth += value;

            SendHealthValueToUI();  
        } else {Debug.Log("Max Health Reched");}
    }
    public void DecreaseHealth(int value)
    {
        if (currentHealth > 0)
        {
            currentHealth -= value;

            SendHealthValueToUI();
        } else {Debug.Log("Min Health Reched");}
    } 
    private void SetMaxHealth()
    {
        currentHealth = maxHealth;

        SendHealthValueToUI();
    }

    private void SendHealthValueToUI()
    {
        playerUIScript.SendHealthValueToUI(currentHealth);
    }

    public IEnumerator ChangeSpriteColor(Color _color, float _time)
    {
        Color colorBeforeChange = spriteRenderer.color;
        
        spriteRenderer.color = _color;

        yield return new WaitForSeconds(_time);
        
        spriteRenderer.color = colorBeforeChange;
    }
}