using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterSystem : MonoBehaviour
{
    public static WaterSystem instance;

    public Slider WaterSlider;
    public Text WaterRate;

    public int current_water = 0;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        current_water = 0;
        WaterSlider.maxValue = GlobalVariables.instance.MaxWater;
        WaterSlider.value = current_water;
        WaterSlider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        WaterSlider.value = current_water;
        WaterRate.text = current_water.ToString() + "%";
    }
}
