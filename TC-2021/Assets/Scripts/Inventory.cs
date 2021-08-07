using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int MaxCapacity = 20;
    public int MakeOxygenTankSteelNumber = 5;
    public int MakeOxygenTankWoodNumber = 20;
    public int MakeLadderWood = 30;
    public List<Item> items = new List<Item>();

    public static Inventory instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public bool AddItem(Item item)
    {
        Debug.Log("Adding :" + item.ItemName);
        foreach (Item it in items)
        {
            if (it.type == item.type)
            {
                it.count += item.count;
                InventoryUI.instance.UpdateUI();
                WarningPanel.instance.SendWarningText("Added " + item.count + " " + item.ItemName + " to inventory.");
                return true;
            }
        }
        if (items.Count < MaxCapacity)
        {
            items.Add(item);
            InventoryUI.instance.UpdateUI();
            WarningPanel.instance.SendWarningText("Added " + item.count + " " + item.ItemName + " to inventory.");
            return true;
        }
        return false;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        InventoryUI.instance.UpdateUI();
    }

    public bool MakeOxygenTank()
    {
        foreach (Item item in items)
        {
            if (item.type == "steel" && item.count >= MakeOxygenTankSteelNumber)
            {
                foreach (Item wood in items)
                {
                    if (wood.type == "wood" && wood.count >= MakeOxygenTankWoodNumber)
                    {
                        if (item.count - MakeOxygenTankSteelNumber == 0)
                        {
                            Remove(item);
                        }
                        else
                        {
                            item.count -= MakeOxygenTankSteelNumber;
                        }
                        if (wood.count - MakeOxygenTankWoodNumber == 0)
                        {
                            Remove(wood);
                        }
                        else
                        {
                            wood.count -= MakeOxygenTankWoodNumber;
                        }
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool MakeLadder()
    {
        foreach (Item item in items)
        {
            if (item.type == "wood" && item.count >= MakeLadderWood)
            {
                if (item.count - MakeLadderWood == 0)
                {
                    Remove(item);
                }
                else
                {
                    item.count -= MakeLadderWood;
                }
                return true;
            }
        }
        return false;
    }

    public bool LadderExist()
    {
        foreach (Item item in items)
        {
            if (item.type == "ladder")
            {
                return true;
            }
        }
        return false;
    }

    public bool DeductItem(string type, int number)
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
}
