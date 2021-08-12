using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static GlobalVariables instance;

    # region Inventory
    public int MaxCapacity = 20;
    # endregion

    # region Making Tools
    public int MakeOxygenTankSteelNumber = 5;
    public int MakeOxygenTankWoodNumber = 20;
    public int MakeLadderWood = 30;
    #endregion

    # region oxygen system
    public float MaxOxygen = 100f;
    public float OxygenDecreaseRate = 0.5f;
    public int max_oxygen_tank = 5;
    #endregion

    # region water system
    public int MaxWater = 3;
    public float WaterAccquireSpeed = 2.0f;
    # endregion

    # region sprites for inspection
    public float inspection_length = 5f;

    public Sprite TransportSprite;
    public Sprite WaterSprite;
    public Sprite SpraySprite;
    public Sprite LadderSprite;
    public Sprite BuildSprite;
    public Sprite OxygenSprite;
    # endregion




    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}


public enum ItemType
{
    ladder,
    metal,
    wood,
    oxygen_tank,
    water_gun,
    oxygen_gun,
    aluminum,
    electric_parts,
    small_motor,
    tow,
    water_spray
}

public enum PlayerMode
{
    none,
    water_gun,
    oxygen_gun,
    ladder,
    water_spray
}

[System.Serializable]
public struct ItemRequirement
{
    public int count;
    public Item required_item;
}

public enum SoundType
{
    move,
    jump,
    absorb_water,
    absorb_oxygen,
    pick_up_item,
    build_item,
    low_oxygen_rate,
}

public struct SoundEffect
{
    public SoundType soundType;
    public AudioClip soundClip;
}