using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkshopMakeLadder : InteractableObject
{
    public GameObject LadderPrefab;
    void Start()
    {
        gameObject.tag = "BuildLadder";

    }
    public override void Interact()
    {
        base.Interact();
        if (Inventory.instance.MakeLadder())
        {
            WarningPanel.instance.SendWarningText("Built a new oxygen tank.");
            Inventory.instance.AddItem(LadderPrefab.GetComponent<Item>());
        }
        else
        {
            WarningPanel.instance.SendWarningText("Not enough materials for ladder.");
        }
        // Debug.Log("Ladder");
    }
}
