using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Header("Cursors Textures")]
    public Texture2D normalCursor;
    public Texture2D onEnemyCursor;
    public Texture2D onpnjCursor;

    [Header("Camera settings")] [SerializeField]
    private Camera mainCamera;

    [Header("Tags")] 
    [SerializeField] private string enemyTag;
    [SerializeField] private string pnjTag;
    private Camera _camera;

    private void Start()
    {
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Cursor.SetCursor(onEnemyCursor, Vector2.zero, CursorMode.Auto);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
        }
        
        // Lancez un rayon depuis la position actuelle de la souris
        if (mainCamera != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.tag);
        
                if (hit.collider.CompareTag(pnjTag))
                {
                    Cursor.SetCursor(onpnjCursor, Vector2.zero, CursorMode.Auto);
                }
        
                else if (hit.collider.CompareTag(enemyTag))
                {
                    Cursor.SetCursor(onEnemyCursor, Vector2.zero, CursorMode.Auto);
                }
                else
                {
                    Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
                }
            }
        }
    }
}
