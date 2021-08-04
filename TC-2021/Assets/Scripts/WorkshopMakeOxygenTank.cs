using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopMakeOxygenTank : InteractableObject
{
    public override void Interact()
    {
        base.Interact();
        if (Inventory.instance.MakeOxygenTank())
        {
            PlayerResources.instance.oxygen_tank_number++;
            PlayerResources.instance.GenerateOxy();
        }
        else
        {
            // TODO: 提示玩家材料不够
        }

    }
}
