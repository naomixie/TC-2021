using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int MaxCapacity = 20;
    private List<Item> items = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
