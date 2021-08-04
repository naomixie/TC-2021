using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    // public InventoryUI inventoryUI;
    public Image icon;
    public Image Background;

    public Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        newItem.gameObject.SetActive(false);
        // Debug.Log("adding item " + item.name + " at slot ");
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    //public void UseItem ()
    //{
    //    if (!item)
    //    {
    //        item.Use();
    //    }
    //}

    public void OnPointerClick()
    {
        Debug.Log("Clicking Item : " + item.ItemName);

        if (item != null)
        {
            Debug.Log("Clicking Item : " + item.ItemName);
            InventoryUI.instance.OnSlotSelected(this);
        }
    }

    public void OnPointerEnter()
    {
        if (item != null) InventoryUI.instance.OnSlotEnter(this);
    }

    public void OnPointerExit()
    {
        if (item != null) InventoryUI.instance.OnSlotExit(this);

    }
}
