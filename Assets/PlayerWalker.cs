using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalker : CellMovment {

    public Transform target;
    public float MAX_DISTANCE = 3;

    void Start()
    {
        
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
            Vector3 movment_dir = Quaternion.Euler(0, 0, Random.Range(0, 360)) * new Vector3(1, 0, 0);
            transform.position += speed * Time.fixedDeltaTime * movment_dir;
        }
    }
}
