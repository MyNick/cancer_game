﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCellSpawner : MonoBehaviour
{
    public Transform player;
    public float minSpawnRate = 2;
    public float maxSpawnRate = 5;

    private float spawnTimer;

    void Start()
    {
        ResetTimer();
    }

    
    void FixedUpdate()
    {
        spawnTimer -= Time.fixedDeltaTime;
        if (spawnTimer <= 0) {
            ResetTimer();
            Spawn();
        }
    }

    private void ResetTimer() {
        spawnTimer = Random.Range(minSpawnRate, maxSpawnRate);
    }

    private void Spawn() {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/Cell"), transform.position, transform.rotation);
        
    }
}