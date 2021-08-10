﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    // public InventoryUI inventoryUI;
    public Image icon;
    public Image Background;
    public Text AmountText;

    public Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        newItem.gameObject.SetActive(false);
        // Debug.Log("adding item " + item.name + " at slot ");
    }

    public void ClearSlot()
    {
        item = null;
    }

    public void UpdateInventorySlot()
    {
        if (item == null)
        {
            AmountText.gameObject.SetActive(false);
            icon.sprite = null;
            icon.enabled = false;
        }
        else
        {
            icon.sprite = item.icon;
            icon.enabled = true;
            AmountText.gameObject.SetActive(true);
            AmountText.text = item.count.ToString();
        }
    }

    public void OnPointerClick()
    {
        if (item != null) InventoryUI.instance.OnSlotSelected(this);
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
