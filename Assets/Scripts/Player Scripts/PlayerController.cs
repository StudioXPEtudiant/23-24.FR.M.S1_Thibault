using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMotor motor;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!motor)
        {
            motor = GetComponent<PlayerMotor>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
