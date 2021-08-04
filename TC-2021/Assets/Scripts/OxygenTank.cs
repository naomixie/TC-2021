using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTank : InteractableObject
{
    public override void Interact()
    {
        if (PlayerResources.instance.oxygen_tank_number > PlayerResources.instance.max_oxygen_tank)
        {
            // TODO: 提示玩家氧气罐数量到达上限
            return;
        }
        ++PlayerResources.instance.oxygen_tank_number;
        PlayerResources.instance.GenerateOxy();
        Destroy(gameObject);
    }
}
