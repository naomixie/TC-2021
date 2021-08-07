using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopMakeOxygenTank : InteractableObject
{
    void Start()
    {
        gameObject.tag = "BuildOxygenTank";

    }
    public override void Interact()
    {
        base.Interact();
        if (Inventory.instance.MakeOxygenTank())
        {
            Debug.Log("sa");

            PlayerResources.instance.oxygen_tank_number++;
            PlayerResources.instance.GenerateOxy();
            WarningPanel.instance.SendWarningText("Built a new oxygen tank.");
        }
        else
        {
            Debug.Log("ss");
            WarningPanel.instance.SendWarningText("Not enough materials for oxygen tank.");
        }
        // Debug.Log("Oxy");
    }
}
