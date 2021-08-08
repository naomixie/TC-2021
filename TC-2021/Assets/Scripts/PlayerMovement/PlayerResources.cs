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



}
