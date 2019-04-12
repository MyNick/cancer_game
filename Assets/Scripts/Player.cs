using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float rotationSpeed = 4f;

    public const float MAX_HEALTH = 100;
    public const float HIT_DAMAGE = 20;
    public float health           = MAX_HEALTH;

    private float shootTimer;
    private bool canShoot = true;

    private bool isHitted = false;
    private float hitTimer;

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
        hitTimer -= Time.fixedDeltaTime;
        if (hitTimer <= 0 && isHitted)
        {
            isHitted = false;
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

        if(health <= 0)
        {
            Destroy(gameObject);
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
            if (collision.gameObject.GetComponent<CancerMovement>().IsShrinked()) {
                Destroy(collision.gameObject);
            } else {
                GameObject.Find("Main Camera").GetComponent<MainCamera>().Shake(0.5f);
            }
        }
    }

    private void ResetTimer()
    {
        shootTimer = 0.25f;
    }

    public void Hit()
    {
        if (!isHitted)
        {
            Debug.Log("Player Hit");
            isHitted = true;
            health -= HIT_DAMAGE;
            hitTimer = 2f;
            if (health == 0) {
                Destroy(gameObject);
            }
        }
    }
}
