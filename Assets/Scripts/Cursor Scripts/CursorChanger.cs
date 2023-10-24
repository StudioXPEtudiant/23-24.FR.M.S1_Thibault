using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    [Header("Cursor System")]
    [SerializeField] private CursorManager cursorManager;
    private Collider2D collider;

    [Header("Tags Names")] 
    [SerializeField] private string tagEnemy = "Enemy";
    [SerializeField] private string tagPnj = "PNJ";

    private void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnMouseEnter()
    {
        if (collider.CompareTag(tagEnemy))
        {
            cursorManager.SetCursorRed();
        }
        else if (collider.CompareTag(tagPnj))
        {
            cursorManager.SetCursorYellow();
        }
    }

    private void OnMouseExit()
    {
        cursorManager.SetCursorDefault();
    }
}
