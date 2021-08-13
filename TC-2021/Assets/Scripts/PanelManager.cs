using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager instance;
    public List<Panel> Panels;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Showpanel(PanelType.HUD);
    }

    public void Showpanel(PanelType panelType)
    {
        // Debug.Log("Opening Panel: " + panelType);
        foreach (Panel panel in Panels)
        {
            if (panel.type != panelType)
            {
                panel.PanelObject.SetActive(false);
            }
            else
            {
                panel.PanelObject.SetActive(true);
            }
        }

        if (panelType != PanelType.HUD)
        {
            Global.instance.DisablePlayerMovements();
        }
        else
        {
            Global.instance.EnablePlayerMovements();
        }
    }
}
