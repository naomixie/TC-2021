using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Workshop : InteractableObject
{
    [Header("Items that could be built in this workshop")]
    public List<BuildableItem> buildableItems;

    public GameObject WorkshopPanel;
    public List<GameObject> GeneratedFormulas;
    public GameObject Formula;
    public GameObject GenerateFormulaPosition;

    void Start()
    {
        gameObject.tag = "Workshop";
    }


    public override void Interact()
    {
        // 打开合成面板
        WorkshopPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraTrun>().enabled = false;
    }

    public void GenerateWorkshopPanel()
    {
        foreach (GameObject gameObject in GeneratedFormulas)
        {
            Destroy(gameObject);
        }
        foreach (BuildableItem buildableItem in buildableItems)
        {
            GameObject formula = Instantiate(Formula, GenerateFormulaPosition.transform, false);
            GeneratedFormulas.Add(formula);
            // formula.setformula
        }
    }

    public void CloseWorkshopPanel()
    {
        WorkshopPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraTrun>().enabled = true;
    }
}
