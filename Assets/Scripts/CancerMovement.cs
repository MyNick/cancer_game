using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerMovement : MonoBehaviour
{
    public float speed = 2;

    private float minChangeDirectionTime = 0.5f;
    private float maxChangeDirectionTime = 2;
    private float changeDirectionTimer;


    private Vector2 randomDir;

    void Start()
    {
        SetTimer();
        RandomRotate();
    }


    void FixedUpdate()
    {
        changeDirectionTimer -= Time.fixedDeltaTime;
        if (changeDirectionTimer <= 0)
        {
            SetTimer();
            RandomRotate();
            randomDir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            Debug.Log(randomDir);
            randomDir.Normalize();
            transform.GetComponent<Rigidbody2D>().velocity = randomDir;
        }

        
    }

    private void SetTimer()
    {
        changeDirectionTimer = Random.Range(minChangeDirectionTime, maxChangeDirectionTime);
    }

    private void RandomRotate()
    {
        transform.Rotate(0, 0, Random.Range(0, 360.0f));
    }
}
