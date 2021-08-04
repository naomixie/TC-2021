using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : InteractableObject
{
    public string ItemName;
    public Sprite icon = null;
    public string description;
    public Sprite detailImage = null;
    public GameObject ObjectPrefab;

    public virtual void Use()
    {
        Debug.Log("Using " + ItemName);
    }
    public override void Interact()
    {
        // Debug.Log("Interacting " + name);
        //Executes all the code from the base interaction function located inside InteractableT
        base.Interact();
        //After this would be code exclusive to Item
        if (Inventory.instance.AddItem(this))
        {
            ObjectPrefab.SetActive(false);
        }
    }
}
