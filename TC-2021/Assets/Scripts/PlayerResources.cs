﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour
{
    public static PlayerResources instance;

    public float MaxOxygen = 100f;
    public float OxygenDecreaseRate = 2.0f;
    public int oxygen_tank_number = 3;

    public float MaxWater = 100f;
    public float WaterAccquireSpeed = 2.0f;

    public Slider OxygenSlider;
    public Text OxygenRate;


    private float current_oxygen;
    private float current_water;

    private float timer = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        current_oxygen = MaxOxygen;
        current_water = 0;
        timer = 0;
        OxygenSlider.value = current_oxygen;
        OxygenSlider.maxValue = MaxOxygen;
        OxygenSlider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            current_oxygen -= OxygenDecreaseRate;
            timer = 0;
        }
        if (current_oxygen < 0)
        {
            if (oxygen_tank_number == 0)
            {
                Debug.Log("GameOver");
            }
            else
            {
                --oxygen_tank_number;
                current_oxygen = MaxOxygen;
            }
        }
        OxygenSlider.value = current_oxygen;
        OxygenRate.text = OxygenSlider.value.ToString() + "%";
    }

}
