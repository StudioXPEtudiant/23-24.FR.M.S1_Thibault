using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Header("Cursors Textures")]
    public Texture2D normalCursor;
    public Texture2D onEnemyCursor;
    public Texture2D onPnjCursor;
    
    private void Start()
    {
        SetCursorDefault();
    }

    public void SetCursorRed()
    {
        Cursor.SetCursor(onEnemyCursor, new Vector2(onEnemyCursor.width / 2, onEnemyCursor.height / 2), CursorMode.Auto);
    }
    
    public void SetCursorYellow()
    {
        Cursor.SetCursor(onPnjCursor, new Vector2(onPnjCursor.width / 2, onPnjCursor.height / 2), CursorMode.Auto);
    }
    
    public void SetCursorDefault()
    {
        Cursor.SetCursor(normalCursor, new Vector2(normalCursor.width / 2, normalCursor.height / 2), CursorMode.Auto);
    }
    
}
