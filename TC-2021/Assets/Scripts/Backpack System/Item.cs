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

    public string type;

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
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
