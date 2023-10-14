using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    private CapsuleCollider2D collider2D;
    private PlayerScript playerScript;

    [SerializeField] private string ladderLayerName;

    private void Start()
    {
        // Init des components
        if (!playerScript)
        {
            playerScript = GetComponent<PlayerScript>();
        }
    }

    // S'active quand le joueur rentre en colission avec un autre collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifi si le Layer est bien le {ladderLayerName}
        if (other.gameObject.layer == LayerMask.NameToLayer(ladderLayerName))
        {
            playerScript.onLadder = true;
        }
    }
    // S'active quand le joueur quitte la collision avec l'objet
    private void OnTriggerExit2D(Collider2D other)
    {
        // Desactive onLadder si le collider possedait le layer {ladderLayerName}
        if (other.gameObject.layer == LayerMask.NameToLayer(ladderLayerName))
        {
            playerScript.onLadder = false;
        }
    }
}