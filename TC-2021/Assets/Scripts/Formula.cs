using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Formula : MonoBehaviour
{
    public BuildableItem buildableItem;

    public Image BuildableItemImage;
    public GameObject GenerateRequiredItemsPosition;
    public GameObject GeneratedRequiredItemsPrefab;
    public GameObject BuildButton;
    public GameObject ErrorButton;


    void Start()
    {
        BuildButton.GetComponent<Button>().onClick.AddListener(BuildItem);
    }

    public void GenerateRequiredItemsUI(BuildableItem item)
    {
        buildableItem = item;
        BuildableItemImage.sprite = buildableItem.icon;

        foreach (ItemRequirement pair in item.RequiredItems)
        {
            GameObject reqItem = Instantiate(GeneratedRequiredItemsPrefab, GenerateRequiredItemsPosition.transform, false);
            reqItem.GetComponent<RequiredItemsUI>().SetItem(pair.required_item, pair.count);
        }

        UpdateBuildStatus();
    }

    public void UpdateBuildStatus()
    {
        if (buildableItem.CheckBuild())
        {
            BuildButton.SetActive(true);
            ErrorButton.SetActive(false);
        }
        else
        {
            BuildButton.SetActive(false);
            ErrorButton.SetActive(true);
        }
    }

    public void BuildItem()
    {
        if (buildableItem.CheckBuild())
        {
            buildableItem.StartBuild();
            UpdateBuildStatus();
        }
    }
}
