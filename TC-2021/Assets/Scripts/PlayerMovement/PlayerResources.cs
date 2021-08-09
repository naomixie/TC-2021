using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour
{
    public static PlayerResources instance;

    public Image ToolImage;

    public Sprite GunSprite;
    public Sprite LadderSprite;
    public PlayerMode mode;



    // private float timer = 0;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        mode = PlayerMode.none;
        ToolImage.sprite = GunSprite;

    }

    // Update is called once per frame
    void Update()
    {
        CheckMode();

        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     if (!(mode == PlayerMode.ladder) && !Inventory.instance.FindItem(ItemType.ladder, 1))
        //     {
        //         return;
        //     }
        //     mode = mode == "gun" ? "ladder" : "gun";
        //     if (mode == "gun")
        //     {
        //         ToolImage.sprite = GunImage;
        //         WaterSlider.gameObject.SetActive(true);
        //     }
        //     else
        //     {
        //         ToolImage.sprite = LadderImage;
        //         WaterSlider.gameObject.SetActive(false);
        //     }
        // }

    }

    void CheckMode()
    {
        switch (mode)
        {
            case PlayerMode.water_gun:
                ToolImage.sprite = GlobalVariables.instance.WaterSprite;
                return;
            case PlayerMode.oxygen_gun:
                ToolImage.sprite = GlobalVariables.instance.OxygenSprite;
                return;
            case PlayerMode.ladder:
                ToolImage.sprite = GlobalVariables.instance.LadderSprite;
                return;
            case PlayerMode.water_spray:
                ToolImage.sprite = GlobalVariables.instance.SpraySprite;
                return;
            default:
                ToolImage.gameObject.SetActive(false);
                return;
        }
    }



}
