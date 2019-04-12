using System.Collections;
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
        SceneManager.LoadScene(2);
    }

    public void loadTutorial() {
        SceneManager.LoadScene(1);
    }


    public void loadMenu() {
        SceneManager.LoadScene(0);
    }

    public void Exit() {
        Application.Quit();
    }
}
