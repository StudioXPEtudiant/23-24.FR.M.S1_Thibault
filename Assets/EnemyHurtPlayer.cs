using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyScript))]
public class EnemyHurtPlayer : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private EnemyScript enemyScript;
    [SerializeField] private Collider2D collider2D; 
    
    private void Awake()
    {
        if (!enemyScript)
        {
            enemyScript = GetComponent<EnemyScript>();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            
            InflictDamage(player);
            
        }
    }

    private void InflictDamage(GameObject _player)
    {
        PlayerScript playerScript = _player.GetComponent<PlayerScript>();

        playerScript.currentHealth -= enemyScript.damage;
    }
}
