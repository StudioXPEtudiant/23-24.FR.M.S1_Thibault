using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ////////////////////////// Création d'un Singleton //////////////////////////////////////////
    
    private static GameManager _instance;

    public static GameManager Instance => _instance;

    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        GameObject singleton = new GameObject("GameManager");
        _instance = singleton.AddComponent<GameManager>();
        DontDestroyOnLoad(singleton);
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////////
    
    [Header("Game Settings")]
    public bool gameOn;

    [Header("Cursor Aim On")] public bool cursorOnEnemy;

    private void Start()
    {
        gameOn = true;
    }
    
}
