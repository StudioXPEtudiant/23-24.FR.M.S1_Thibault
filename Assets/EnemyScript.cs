using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private CursorChanger cursorChanger;
    
    [Header("Enemy Capacity")]
    public float life = 10f;
    public float speed = 10f;
    public int damage = 1;
    
    [Header("Particles System")]
    [SerializeField] private GameObject explosionParticle;

    private void Awake()
    {
        if (!cursorChanger)
        {
            cursorChanger = GetComponent<CursorChanger>();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        
        cursorChanger.cursorManager.SetCursorDefault();

        Vector3 modifiedSpawnPosition = new Vector3(transform.position.x, transform.position.y + 0.20f);
        
        GameObject explosionParticleInst = Instantiate(explosionParticle, modifiedSpawnPosition, transform.rotation);
        
        Destroy(explosionParticleInst, 2);
    }
} 