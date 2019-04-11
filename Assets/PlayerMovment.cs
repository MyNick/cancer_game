using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float movementSpeed = 10;

    void Start() {

    }

    void FixedUpdate() {
        playerMove();
        followMouse();
    }

    private void followMouse() {

    }

    void playerMove() {
        Vector2 speed = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.UpArrow)) {
            speed.y += 1;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            speed.y += -1;

        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            speed.x += 1;

        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            speed.x += -1;
        }
        speed.Normalize();
        speed *= movementSpeed * Time.fixedDeltaTime;
        transform.position += (Vector3)speed;;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject.Find("Main Camera").GetComponent<MainCamera>().Shake(0.5f);
    }
}
