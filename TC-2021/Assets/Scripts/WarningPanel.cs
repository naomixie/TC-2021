using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningPanel : MonoBehaviour
{
    public static WarningPanel instance;

    private float timer;
    public float Duration = 2;

    public GameObject Panel;
    public Text WarningText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (Panel.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer > Duration)
            {
                Panel.SetActive(false);
                timer = 0;
            }
        }
    }


    public void SendWarningText(string warning)
    {
        timer = 0;
        Panel.SetActive(true);
        WarningText.text = warning;
    }
}
