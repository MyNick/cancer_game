using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const float MAX_CANCER = 100;
    public int AmountOfCancer { get; private set; }

    

    // Start is called before the first frame update
    void Start()
    {
        AmountOfCancer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AmountOfCancer = GameObject.FindGameObjectsWithTag("Cancer").Length;
        AmountOfCancer += GameObject.FindGameObjectsWithTag("WallCancer").Length;

        if (AmountOfCancer == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (AmountOfCancer >= MAX_CANCER)
        {
            SceneManager.LoadScene(0);
        }

        else if (FindObjectsOfType<Player>().Length == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
