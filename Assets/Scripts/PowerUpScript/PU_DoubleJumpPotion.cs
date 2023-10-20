using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PU_DoubleJumpPotion : MonoBehaviour
{
    private int initialJumpCount;
    private PlayerMotor playerMotor;
    private PlayerScript playerScript;

    [Header("GameObject")] 
    [SerializeField] private GameObject particles;
    
    [Header("PowerUp Parameters")] 
    [SerializeField] private int additionalJumpCount = 2;
    [SerializeField] private float timeOfPowerUp = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponentInChildren<SpriteRenderer>().enabled = false;
            Instantiate(particles, transform.position, Quaternion.identity);
            
            playerMotor = other.GetComponentInParent<PlayerMotor>();
            playerScript = other.GetComponentInParent<PlayerScript>();
            
            StartCoroutine(playerScript.ChangeSpriteColor(new Color(250f / 255f, 95f / 255f, 234f / 255f), 2f));
            
            GetInitialJumpCount();

            AddAdditionalJumpToPlayer();
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
    private IEnumerator WaitBeforReset()
    {
        Debug.Log("WaitBeforReset()");
        
        yield return new WaitForSeconds(timeOfPowerUp);
        
        Debug.Log("wait finished");
        
        playerMotor.maxJump = 1;
        
        playerMotor.RefreshCurrentJumpCount();

        DestroyTheObject();
    }
    private void ResetAdditionalJumpToPlayer()
    {
        Debug.Log("ResetAdditionalJumpToPlayer()");
        
        playerMotor.maxJump = 1;
        
        playerMotor.RefreshCurrentJumpCount();
    }

    private void DestroyTheObject()
    {
        Destroy(this);
    }
}
