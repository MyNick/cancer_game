using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellColliderScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("collision");
        if (collision.otherCollider.tag == "Wall") {
            Debug.Log("collides with wall");
            GameObject go = Instantiate(Resources.Load<GameObject>("WallCell"), transform.position, transform.rotation);
            go.GetComponent<WallCellSpawner>().player = GameObject.Find("Player").transform;
            Destroy(this);
        }
    }
}
