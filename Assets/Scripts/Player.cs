using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float rotationSpeed = 4f;

    public float health = 100;

    private float shootTimer;
    private bool canShoot = true;

    void Start() {
        ResetTimer();
    }

    void FixedUpdate() {
        playerMove();

        shootTimer -= Time.fixedDeltaTime;
        if (shootTimer <= 0)
        {
            
            canShoot = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Object laser = Instantiate(Resources.Load<GameObject>("Prefabs/Laser"), transform.position, transform.rotation);
            ResetTimer();
            canShoot = false;
        }
    }

    void playerMove() {


        Vector2 speed = transform.up * 10f;
        speed.Normalize();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.GetComponent<Rigidbody2D>().velocity = speed * movementSpeed;
        }
        

        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.GetComponent<Rigidbody2D>().velocity = -speed * movementSpeed;

        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(transform.forward, -rotationSpeed);

        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(transform.forward, rotationSpeed);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Cancer"))
        {
            GameObject.Find("Main Camera").GetComponent<MainCamera>().Shake(0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cancer"))
        {
            Destroy(collision.gameObject);

        }
    }

    private void ResetTimer()
    {
        shootTimer = 0.25f;
    }
}
