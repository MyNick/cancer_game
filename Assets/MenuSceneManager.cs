﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    SceneManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void loadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
