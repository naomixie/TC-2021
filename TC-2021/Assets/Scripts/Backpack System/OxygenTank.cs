using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTank : InteractableObject
{
    public override void Interact()
    {
        if (OxygenSystem.instance.current_oxygen_tank_number > Global.instance.max_oxygen_tank)
        {
            WarningPanel.instance.SendWarningText("Maximum amount of oxygen tanks reached.");
        }
        else
        {
            ++OxygenSystem.instance.current_oxygen_tank_number;
            OxygenSystem.instance.UpdateOxygenTankUI();
            Destroy(gameObject);
        }

    }
}
