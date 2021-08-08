using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : InteractableObject
{
    public string ItemName;
    public Sprite icon = null;
    public string description;
    public Sprite detailImage = null;
    public int count;
    public ItemType type;


    public override void Interact()
    {
        count = Random.Range(1, 2);
        if (Inventory.instance.AddItem(this))
        {
            ObjectPrefab.SetActive(false);
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}

