using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;

    public float shakeAmount = 10f;

    private float left = 0;

    private Vector3 originalPos;

    void FixedUpdate() {
        if (GameObject.FindObjectsOfType<Player>().Length == 0) {
            return;
        }
        originalPos = target.position + Vector3.back * 10;
        if (left > 0) {
            transform.position = originalPos + Random.insideUnitSphere * shakeAmount;

            left -= Time.fixedDeltaTime / Time.timeScale;
            if (left <= 0) {
                left = 0;
                transform.position = originalPos;
            }
        } else {
            transform.position = originalPos;
        }
    }

    public void Shake(float shake_duration = 0.1f) {
        left = shake_duration;
    }
}
