using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopMakeLadder : InteractableObject
{
    public override void Interact()
    {
        base.Interact();
        if (Inventory.instance.MakeLadder())
        {
            // TODO: Inventory.add <- Resources.Load(Ladder).getcomponent<Item>()
        }
        else
        {
            // TODO: 提示玩家材料不够
        }

    }
}
