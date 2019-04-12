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
        health_foreground.fillAmount = player.GetComponent<Player>().health / Player.MAX_HEALTH;

        float cancer = GameObject.FindGameObjectsWithTag("Cancer").Length;
        cancer += GameObject.FindGameObjectsWithTag("WallCancer").Length;
        cancer /= MAX_CANCER;
        cells_foreground.fillAmount = cancer;
    }
}
