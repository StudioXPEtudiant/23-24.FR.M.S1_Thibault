using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(WaitAndPerformAction());
    }

    private IEnumerator WaitAndPerformAction()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1.0f);

        // Perform your action here
        Debug.Log("1 second has passed!");
    }
}
