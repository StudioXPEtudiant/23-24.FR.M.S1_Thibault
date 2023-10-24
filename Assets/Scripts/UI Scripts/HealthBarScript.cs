using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void SetHealthBarFill(int value)
    {
        value = Math.Clamp(value, 0, 6);
        
        animator.SetInteger("Health Level", value);
    }
}
