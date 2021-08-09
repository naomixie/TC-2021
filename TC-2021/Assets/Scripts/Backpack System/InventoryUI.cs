using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;
    public GameObject InventoryPanel;

    public Image detailsImage;
    public Text detailsText;

    public InventorySlot[] slots;

    public InventorySlot selectedSlot;

    public Sprite slotIdle;
    public Sprite slotHover;
    public Sprite slotActive;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        ResetSlots();
        // UpdateUI();
        InventoryPanel.SetActive(false);
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.instance.items.Count)
            {
                slots[i].AddItem(Inventory.instance.items[i]);
                // Debug.Log("added item " + Inventory.instance.items[i].name + " at " + i);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }

    public void OnSlotEnter(InventorySlot slot)
    {
        ResetSlots();
        if (selectedSlot == null || selectedSlot != slot)
        {
            //Debug.Log("Hovering slot");
            slot.Background.sprite = slotHover;
        }
    }


    public void OnSlotExit(InventorySlot slot)
    {
        ResetSlots();
    }

    public void OnSlotSelected(InventorySlot slot)
    {
        selectedSlot = slot;
        Debug.Log("1selected slot is " + slot.name);
        ResetSlots();
        slot.Background.sprite = slotActive;
        int index = slot.transform.GetSiblingIndex();
        Debug.Log("2selected slot is " + slot.name);

    }

    public void ResetSlots()
    {
        foreach (InventorySlot slot in slots)
        {
            if (selectedSlot != null && slot == selectedSlot)
            {
                continue;
            }
            slot.Background.sprite = slotIdle;
        }
    }

    public void Update()
    {
        if (selectedSlot != null)
        {
            detailsImage.gameObject.SetActive(true);
            detailsImage.sprite = selectedSlot.item.detailImage;
            detailsText.text = selectedSlot.item.description;
        }
        else
        {
            detailsImage.gameObject.SetActive(false);
            detailsText.text = "";
        }
    }


    public Item getSelectedItem()
    {
        return selectedSlot != null ? selectedSlot.item : null;
    }

}
