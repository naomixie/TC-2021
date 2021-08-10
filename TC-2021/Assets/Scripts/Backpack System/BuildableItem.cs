using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableItem : Item
{
    public Dictionary<Item, int> RequiredItems = new Dictionary<Item, int>();

    public override void Interact()
    {
        base.Interact();
    }

    public virtual void BuildItem()
    {
        if (CheckBuild())
        {
            CheckBuild();
        }
    }

    public bool CheckBuild()
    {
        foreach (var pair in RequiredItems)
        {
            if (!Inventory.instance.FindItem(pair.Key.type, pair.Value))
            {
                WarningPanel.instance.SendWarningText("There is not enough " + pair.Key + "to build this item.");
                return false;
            }
        }
        return true;
    }

    public void StartBuild()
    {
        foreach (var pair in RequiredItems)
        {
            Inventory.instance.DeductItem(pair.Key.type, pair.Value);
        }
        count = 1;
        Inventory.instance.AddItem(this);
    }


}
