using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerMovement : MonoBehaviour
{
    public float speed = 2;

    private float minChangeDirectionTime = 0.5f;
    private float maxChangeDirectionTime = 2;
    private float changeDirectionTimer;
    private bool isShrinked = false;

    private float scaleBackTimer;

    private Vector2 randomDir;

    void Start()
    {
        SetTimer();
        RandomRotate();
    }


    void FixedUpdate()
    {
        scaleBackTimer -= Time.fixedDeltaTime;
        if(scaleBackTimer <= 0f && isShrinked)
        {
            isShrinked = false;
            transform.localScale = new Vector3(transform.localScale.x * 2.0f, transform.localScale.y * 2.0f, transform.localScale.z * 2.0f);

        }

        if(isShrinked)
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
        }
        else
        {
            GetComponent<CircleCollider2D>().isTrigger = false;

        }
        Movement();

    }

    private void SetTimer()
    {
        changeDirectionTimer = Random.Range(minChangeDirectionTime, maxChangeDirectionTime);
    }

    private void RandomRotate()
    {
        transform.Rotate(0, 0, Random.Range(0, 360.0f));
    }

    private void Movement()
    {
        changeDirectionTimer -= Time.fixedDeltaTime;
        if (changeDirectionTimer <= 0)
        {
            SetTimer();
            RandomRotate();
            randomDir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            randomDir.Normalize();
            transform.GetComponent<Rigidbody2D>().velocity = randomDir;
        }
    }


    public void Hit()
    {
        if (!isShrinked)
        {
            transform.localScale = new Vector3(transform.localScale.x / 2.0f, transform.localScale.y / 2.0f, transform.localScale.z / 2.0f);
            isShrinked = true;
            scaleBackTimer = 5f;
        }
        
    }

}
