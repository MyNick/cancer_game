﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public float movementSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 speed = transform.up * 10f;

        transform.GetComponent<Rigidbody2D>().velocity = speed * movementSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cancer"))
        {
            collision.GetComponent<CancerMovement>().Hit();

        }

        if (collision.CompareTag("WallCancer"))
        {
            collision.GetComponent<WallCellSpawner>().Hit();

        }
        if (!collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
