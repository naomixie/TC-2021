using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Workshop : InteractableObject
{
    public static Workshop instance;
    [Header("Items that could be built in this workshop")]
    public List<BuildableItem> buildableItems;

    public GameObject WorkshopPanel;
    public List<GameObject> GeneratedFormulas;
    public GameObject Formula;
    public GameObject GenerateFormulaPosition;
    public Button CloseWorkshopPanelbutton;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        gameObject.tag = "Workshop";
        CloseWorkshopPanelbutton.onClick.AddListener(() => PanelManager.instance.Showpanel(PanelType.HUD));
    }

    public override void Interact()
    {
        // 打开合成面板
        PanelManager.instance.Showpanel(PanelType.Workshop);
        GenerateWorkshopPanel();
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
            formula.GetComponent<Formula>().GenerateRequiredItemsUI(buildableItem);
            GeneratedFormulas.Add(formula);
        }
    }

    public void CloseWorkshopPanel()
    {
        WorkshopPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraTrun>().enabled = true;
    }
}
