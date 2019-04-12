using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCellSpawner : MonoBehaviour
{
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
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/Cell"), transform.position + transform.right, transform.rotation);
        
    }

    public void Hit()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/Cell"), transform.position + transform.right,
                Quaternion.Euler(0, 0, 0));
        go.GetComponent<CancerMovement>().Hit();
        Destroy(gameObject);

    }
}
