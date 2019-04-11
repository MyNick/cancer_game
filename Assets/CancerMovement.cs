using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerMovement : MonoBehaviour
{
    public float speed = 2;

    private float minChangeDirectionTime = 0.5f;
    private float maxChangeDirectionTime = 2;
    private float changeDirectionTimer;


    private Vector2 targetPos;

    void Start()
    {
        SetTimer();
        RandomRotate();
    }


    void FixedUpdate()
    {
        changeDirectionTimer -= Time.fixedDeltaTime;
        if (changeDirectionTimer <= 0 && Vector2.Distance(transform.position, targetPos) < 0.2f)
        {
            SetTimer();
            RandomRotate();
        }

        targetPos = Random.insideUnitCircle;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
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
