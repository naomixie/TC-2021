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
    public int count;

    public string type;

    // Item(string item_name, Sprite icon, string description, Sprite detail_image, GameObject object_prefab, int count, string type)
    // {
    //     this.ItemName = item_name;
    //     this.icon = icon;
    //     this.description = description;
    //     this.detailImage = detail_image;
    //     this.ObjectPrefab = object_prefab;
    //     this.count = count;
    //     this.type = type;
    // }

    public virtual void Use()
    {
        Debug.Log("Using " + ItemName);
    }
    public override void Interact()
    {
        base.Interact();
        count = Random.Range(5, 8);
        if (Inventory.instance.AddItem(this))
        {
            ObjectPrefab.SetActive(false);
        }
    }
}
