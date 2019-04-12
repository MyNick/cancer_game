using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Image health_background;
    public Image health_foreground;
    public Image cells_background;
    public Image cells_foreground;
    public GameObject player;

    public const float MAX_CANCER = 100;

    void Start()
    {
    }

    void FixedUpdate()
    {
        if (GameObject.FindObjectsOfType<Player>().Length == 0) {
            health_foreground.fillAmount = 0;
        } else {
            health_foreground.fillAmount = player.GetComponent<Player>().health / Player.MAX_HEALTH;
        }
        cells_foreground.fillAmount = GameObject.FindObjectOfType<GameManager>().AmountOfCancer / MAX_CANCER;
    }
}
