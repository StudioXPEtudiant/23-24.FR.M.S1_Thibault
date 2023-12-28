using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyScript))]
public class EnemyLifeSystem : MonoBehaviour
{
    [SerializeField] private PlayerScript playerScript;   
    [SerializeField] private EnemyScript enemyScript;

    private void Awake()
    {
        if (!enemyScript)
        {
            enemyScript = GetComponent<EnemyScript>();
        }
        if (!playerScript)
        {
            Debug.LogError("PlayerScript missing");
        }
    }

    private void OnMouseDown()
    {
        enemyScript.life -= playerScript.damage;
        
        Debug.Log(enemyScript.life);
        
        CheckLifeEnemy();
    }

    private void CheckLifeEnemy()
    {
        if (enemyScript.life <= 0)
        {
            enemyScript.Die();
        }
    }
}
