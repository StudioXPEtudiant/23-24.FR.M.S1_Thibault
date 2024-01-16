using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemys : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CapsuleCollider2D enemy_CC2D;
    [SerializeField] private PlayerScript playerScript;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyScript _enemyScriptOfOther = other.gameObject.GetComponent<EnemyScript>(); 
            
            StartCoroutine(playerScript.ReceiveHit(_enemyScriptOfOther));
        }
    }
}
