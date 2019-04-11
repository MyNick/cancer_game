using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalker : CellMovment {

    private float minChangeDirectionTime = 0.5f;
    private float maxChangeDirectionTime = 2;
    private float changeDirectionTimer;

    void Start()
    {
        SetTimer();
        RandomRotate();
    }

    
    void FixedUpdate()
    {
        changeDirectionTimer -= Time.fixedDeltaTime;
        if (changeDirectionTimer <= 0) {
            SetTimer();
            RandomRotate();
        }
        transform.position += transform.up * speed * Time.fixedDeltaTime;
    }

    private void SetTimer() {
        changeDirectionTimer = Random.Range(minChangeDirectionTime, maxChangeDirectionTime);
    }

    private void RandomRotate() {
        transform.Rotate(0, 0, Random.Range(0, 360.0f));
    }
}
