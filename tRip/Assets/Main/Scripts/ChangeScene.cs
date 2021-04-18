﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    public void changeScene()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("Entered the game");
    }

    public void cerrarJuego()
    {
        EditorApplication.ExecuteMenuItem("Edit/Play");
        Debug.Log("Exited the game");
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}