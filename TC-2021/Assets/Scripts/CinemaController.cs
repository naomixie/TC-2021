using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CinemaController : MonoBehaviour
{
    private GameObject player;
    public static CinemaController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        player = GameObject.FindGameObjectWithTag("Player");
        DisablePlayer();
    }

    public void DisablePlayer()
    {
        player.SetActive(false);
    }

    public void EnablePlayer()
    {
        player.SetActive(true);
    }

}
