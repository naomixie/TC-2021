using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequiredItemsUI : MonoBehaviour
{
    public Image ItemImage;
    public Text ItemCount;

    public void SetItem(Item item, int count)
    {
        ItemImage.sprite = item.icon;
        ItemCount.text = count.ToString();
    }
}
