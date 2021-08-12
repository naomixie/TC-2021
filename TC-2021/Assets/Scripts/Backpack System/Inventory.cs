using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<Item> items = new List<Item>();

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public bool AddItem(Item item, int amount)
    {
        // Debug.Log("Adding :" + item.ItemName);
        foreach (Item it in items)
        {
            if (it.type == item.type)
            {
                it.count += amount;
                // UpdateInventory("Added " + amount + " " + item.ItemName + " to inventory.");
                return true;
            }
        }
        if (items.Count < GlobalVariables.instance.MaxCapacity)
        {
            item.count = amount;
            items.Add(item);
            // UpdateInventory("Added " + amount + " " + item.ItemName + " to inventory.");
            return true;
        }
        return false;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        // Debug.Log("Removed " + item.ItemName + " from inventory.");
        UpdateInventory("Removed " + item.ItemName + " from inventory.");
    }

    public bool FindItem(ItemType type, int count)
    {
        foreach (Item item in items)
        {
            if (item.type == type && item.count >= count)
            {
                // Debug.Log("Inv has " + item.count + "\t Req is" + count);
                return true;
            }
        }
        return false;
    }

    public bool DeductItem(ItemType type, int number)
    {
        foreach (Item item1 in items)
        {
            if (item1.type == type && item1.count > number)
            {
                item1.count -= number;
                return true;
            }
            else if (item1.type == type && item1.count == number)
            {
                Remove(item1);
                return true;
            }
        }
        return false;
    }

    public void UpdateInventory(string warning_text)
    {
        InventoryUI.instance.UpdateUI();
        WarningPanel.instance.SendWarningText(warning_text);
    }
}
