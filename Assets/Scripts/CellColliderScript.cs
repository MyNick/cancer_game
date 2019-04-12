using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellColliderScript : MonoBehaviour
{

    public const float TIME_CANT_REPRODUCE = 3f;
    private float time_left = TIME_CANT_REPRODUCE;

    void Start() {
        
    }

    void FixedUpdate() {
        time_left -= Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (time_left > 0) {
            return;
        }
        if (collision.collider.tag == "Wall") {
            Vector3 normal = (Vector3)collision.GetContact(0).normal;
            float angle = Mathf.Atan2(normal.y, normal.x) * Mathf.Rad2Deg;
            GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/WallCell"), transform.position,
                Quaternion.Euler(0, 0, angle));
            Destroy(gameObject);
        }
    }
}
