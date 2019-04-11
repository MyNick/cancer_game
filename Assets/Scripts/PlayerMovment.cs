using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float rotationSpeed = 4f;
    void Start() {

    }

    void FixedUpdate() {
        playerMove();
        followMouse();
    }

    private void followMouse() {

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
            transform.Rotate(transform.forward, rotationSpeed);

        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(transform.forward, -rotationSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Cancer"))
        {
            GameObject.Find("Main Camera").GetComponent<MainCamera>().Shake(0.5f);
        }
    }
}
