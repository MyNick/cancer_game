using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmuneSystemBehavior : MonoBehaviour {

    public float speed;
    public Transform target;
    public float MAX_DISTANCE;


    private float minChangeDirectionTime = 0.5f;
    private float maxChangeDirectionTime = 2;
    private float changeDirectionTimer;
    private Vector2 randomDir;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        SetTimer();
        RandomRotate();
    }

    /***
     * Moves to the player position if he's close enough, otherwise moving randomly.
     * TODO: the cells are currently jiggles in place if the player is far. needs
     *      to make them move more like RandomWalker.
     */
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, target.position) < MAX_DISTANCE) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        } else {
            Movement();
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Hit();
        }
    }
}
