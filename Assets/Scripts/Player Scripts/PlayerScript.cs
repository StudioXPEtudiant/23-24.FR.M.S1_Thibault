using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
    public int damage = 1; 
    private int currentHealth;
    
    [Header("Behaviour")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerMotor playerMotor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerUIScript playerUIScript;
    
    [Header("Attack Sys")]
    [SerializeField] private GameObject attackAnimation; 
    
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
        if (Input.GetMouseButtonDown(0))
        {
            InstAttackAnimation();
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

    private void InstAttackAnimation()
    {
        Vector3 mousePosScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 mousePosWorldPoint = Camera.main.ScreenToWorldPoint(mousePosScreen);
        
         GameObject _attackTemp = Instantiate(attackAnimation, mousePosWorldPoint, Quaternion.identity);
         
         Destroy(_attackTemp, 0.2f);
    }
}