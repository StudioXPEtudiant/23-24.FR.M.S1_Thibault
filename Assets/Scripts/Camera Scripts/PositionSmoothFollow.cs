using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSmoothFollow : MonoBehaviour
{
    [Header("Camera Follow System")]
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -4f);
    [SerializeField] private float smoothTime = 0.15f;
    [SerializeField] private Vector3 velocity = Vector3.zero;

    [Header("GameObject")] 
    [SerializeField] private Transform target;
    
    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
