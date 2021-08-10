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
                Debug.Log("There is not enough " + pair.required_item.ItemName + " in inventory.");
                // WarningPanel.instance.SendWarningText("There is not enough " + pair.required_item.ItemName + "to build this item.");
                return false;
            }
        }
        Debug.Log("There is enough to build " + ItemName + ".");
        return true;
    }

    public void StartBuild()
    {
        foreach (ItemRequirement pair in RequiredItems)
        {
            Debug.Log("Deduct item: " + pair.required_item.type + "\tDeduct amount: " + pair.count);
            Inventory.instance.DeductItem(pair.required_item.type, pair.count);
        }
        Inventory.instance.AddItem(this, 1);
    }


}
