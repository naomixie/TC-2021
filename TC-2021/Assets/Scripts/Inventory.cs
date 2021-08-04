using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int MaxCapacity = 20;
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
        if (items.Count < MaxCapacity)
        {
            items.Add(item);
            // InventoryUI.instance.UpdateUI();
            return true;
        }
        return false;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        // InventoryUI.instance.UpdateUI();
    }
}
