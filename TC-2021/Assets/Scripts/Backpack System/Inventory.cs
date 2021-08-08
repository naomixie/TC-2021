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

    public bool AddItem(Item item)
    {
        // Debug.Log("Adding :" + item.ItemName);
        foreach (Item it in items)
        {
            if (it.type == item.type)
            {
                it.count += item.count;
                UpdateInventory("Added " + item.count + " " + item.ItemName + " to inventory.");
                return true;
            }
        }
        if (items.Count < GlobalVariables.instance.MaxCapacity)
        {
            items.Add(item);
            UpdateInventory("Added " + item.count + " " + item.ItemName + " to inventory.");
            return true;
        }
        return false;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        UpdateInventory("Removed " + item.ItemName + " from inventory.");
    }

    public bool FindItem(ItemType type, int count)
    {
        foreach (Item item in items)
        {
            if (item.type == type && count >= item.count)
            {
                return true;
            }
        }
        return false;
    }

    // public bool MakeOxygenTank()
    // {
    //     foreach (Item item in items)
    //     {
    //         if (item.type == ItemType.metal && item.count >= GlobalVariables.instance.MakeOxygenTankSteelNumber)
    //         {
    //             foreach (Item wood in items)
    //             {
    //                 if (wood.type == ItemType.wood && wood.count >= GlobalVariables.instance.MakeOxygenTankWoodNumber)
    //                 {
    //                     if (item.count - GlobalVariables.instance.MakeOxygenTankSteelNumber == 0)
    //                     {
    //                         Remove(item);
    //                     }
    //                     else
    //                     {
    //                         item.count -= GlobalVariables.instance.MakeOxygenTankSteelNumber;
    //                     }
    //                     if (wood.count - GlobalVariables.instance.MakeOxygenTankWoodNumber == 0)
    //                     {
    //                         Remove(wood);
    //                     }
    //                     else
    //                     {
    //                         wood.count -= GlobalVariables.instance.MakeOxygenTankWoodNumber;
    //                     }
    //                     return true;
    //                 }
    //             }
    //         }
    //     }
    //     return false;
    // }

    // public bool MakeLadder()
    // {
    //     foreach (Item item in items)
    //     {
    //         if (item.type == ItemType.wood && item.count >= GlobalVariables.instance.MakeLadderWood)
    //         {
    //             if (item.count - GlobalVariables.instance.MakeLadderWood == 0)
    //             {
    //                 Remove(item);
    //             }
    //             else
    //             {
    //                 item.count -= GlobalVariables.instance.MakeLadderWood;
    //             }
    //             return true;
    //         }
    //     }
    //     return false;
    // }

    // public bool LadderExist()
    // {
    //     foreach (Item item in items)
    //     {
    //         if (item.type == ItemType.ladder)
    //         {
    //             return true;
    //         }
    //     }
    //     return false;
    // }

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
