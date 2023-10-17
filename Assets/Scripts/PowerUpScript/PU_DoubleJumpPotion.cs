using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_DoubleJumpPotion : MonoBehaviour
{
    private int initialJumpCount;
    private PlayerMotor playerMotor;
    
    [Header("PowerUp Parameters")] 
    [SerializeField] private int additionalJumpCount = 2;
    [SerializeField] private float timeOfPowerUp = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMotor = other.GetComponentInParent<PlayerMotor>();
            
            GetInitialJumpCount();

            AddAdditionalJumpToPlayer();
            
            gameObject.SetActive(false);
        }
    }
    
    private void GetInitialJumpCount()
    {
        initialJumpCount = playerMotor.maxJump;
    }

    private void AddAdditionalJumpToPlayer()
    {
        Debug.Log("AddAdditionalJumpToPLayer method called");

        
        playerMotor.maxJump += additionalJumpCount;
        
        playerMotor.RefreshCurrentJumpCount();
        
        StartCoroutine(WaitBeforReset());
    }
    IEnumerator WaitBeforReset()
    {
        Debug.Log("WaitBeforReset()");
        
        yield return new WaitForSeconds(3f);
        
        Debug.Log("wait finished");
        
        playerMotor.maxJump = 1;
        
        playerMotor.RefreshCurrentJumpCount();
    }
    private void ResetAdditionalJumpToPlayer()
    {
        Debug.Log("ResetAdditionalJumpToPlayer()");
        
        playerMotor.maxJump = 1;
        
        playerMotor.RefreshCurrentJumpCount();
    }
}
