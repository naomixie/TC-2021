using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public List<float> TimeForStages;
    public List<float> WaterForStages;
    public List<GameObject> StagePrefabs;
    public List<float> OxygenForStages;
    public float MaxLifeAmount = 100f;


    private int stage;
    private float water_amount;
    private float time_amount;
    private GameObject plant_object;
    private float current_health;
    private bool is_planted = false;




    void Start()
    {
        stage = 0;
        current_health = MaxLifeAmount;
        water_amount = WaterForStages[0] / 2;
        time_amount = 0;
        plant_object = GameObject.Instantiate(StagePrefabs[0], this.transform.position, Quaternion.identity);
        is_planted = false;
    }

    void Update()
    {
        if (is_planted)
        {
            Grow();
        }
    }

    public void PlantTree()
    {
        is_planted = true;
    }

    public void AddWater(float water)
    {
        water_amount += water;
    }

    private void Grow()
    {
        // 成长到最终阶段
        if (stage == 2)
        {
            if (water_amount <= 0)
            {
                // 停止共给氧气
                Debug.Log("Stop Release Oxygen");
                if (current_health <= 0)
                {
                    Destroy(this.gameObject);
                }
                current_health -= Time.deltaTime;
            }
            water_amount -= Time.deltaTime;
            current_health = current_health < MaxLifeAmount ? current_health += Time.deltaTime : MaxLifeAmount;
            // 共给氧气
            Debug.Log("Release Oxygen: " + OxygenForStages[stage]);
        }
        else
        {
            if (water_amount > 0)
            {
                water_amount -= Time.deltaTime;
                current_health = current_health < MaxLifeAmount ? current_health += Time.deltaTime : MaxLifeAmount;
                // 进阶到下一个阶段
                if (time_amount > TimeForStages[stage])
                {
                    ++stage;
                    Destroy(plant_object);
                    plant_object = GameObject.Instantiate(StagePrefabs[stage], gameObject.transform.position, Quaternion.identity);
                    water_amount -= Time.deltaTime;
                    time_amount = 0;
                }
                else
                {
                    time_amount += Time.deltaTime;
                }
                // 供给氧气
                Debug.Log("Release Oxygen: " + OxygenForStages[stage]);
            }
            else if (water_amount <= 0)
            {
                water_amount = 0;
                if (current_health == 0)
                {
                    // Plant dies
                    Destroy(this.gameObject);
                }
                current_health -= Time.deltaTime;
            }
        }
    }
}
