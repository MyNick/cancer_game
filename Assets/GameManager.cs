using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float amountOfCancer = 0;
    public const float MAX_CANCER = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        amountOfCancer = GameObject.FindGameObjectsWithTag("Cancer").Length;
        amountOfCancer += GameObject.FindGameObjectsWithTag("WallCancer").Length;

        if(amountOfCancer <= 0)
        {

            Debug.Log("PLAYER WIN");
        }
        if(amountOfCancer >= MAX_CANCER)
        {
            Debug.Log("PLAYER LOSE");

        }
    }
}
