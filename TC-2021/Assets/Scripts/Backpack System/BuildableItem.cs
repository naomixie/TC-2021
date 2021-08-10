using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableItem : Item
{
    [SerializeField]
    public List<ItemRequirement> RequiredItems = new List<ItemRequirement>();

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
        foreach (ItemRequirement pair in RequiredItems)
        {
            if (!Inventory.instance.FindItem(pair.required_item.type, pair.count))
            {
                // WarningPanel.instance.SendWarningText("There is not enough " + pair.required_item.ItemName + "to build this item.");
                return false;
            }
        }
        return true;
    }

    public void StartBuild()
    {
        foreach (var pair in RequiredItems)
        {
            Inventory.instance.DeductItem(pair.required_item.type, pair.count);
        }
        count = 1;
        Inventory.instance.AddItem(this);
    }


}
