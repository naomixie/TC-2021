using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenSystem : MonoBehaviour
{
    #region Unity Components/GameObjects
    public static OxygenSystem instance;
    public GameObject GenerateOxygenImagePosition;
    private List<GameObject> GeneratedOxygenTank = new List<GameObject>();
    public GameObject OxygenImagePrefab;
    public Slider OxygenSlider;
    public Text OxygenRate;
    public GameObject BloodScreen;
    #endregion

    public float current_oxygen;
    public int current_oxygen_tank_number = 3;
    private float timer = 0;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        current_oxygen = GlobalVariables.instance.MaxOxygen;
        OxygenSlider.value = current_oxygen;
        OxygenSlider.maxValue = GlobalVariables.instance.MaxOxygen;
        OxygenSlider.minValue = 0;

        timer = 0;
        BloodScreen.SetActive(false);
        UpdateOxygenTankUI();
    }

    // Update is called once per frame
    void Update()
    {
        OxygenUse();
    }

    public void OxygenUse()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            current_oxygen -= GlobalVariables.instance.OxygenDecreaseRate;
            timer = 0;
            OxygenSlider.value = current_oxygen;
            OxygenRate.text = OxygenSlider.value.ToString() + "%";
            if (current_oxygen < 40)
            {
                BloodScreen.SetActive(true);
            }
            else
            {
                BloodScreen.SetActive(false);
            }
            if (current_oxygen <= 0)
            {
                if (current_oxygen_tank_number == 0)
                {
                    //TODO: Switch to gameover scene?
                    Debug.Log("GameOver");
                }
                else
                {
                    --current_oxygen_tank_number;
                    current_oxygen = GlobalVariables.instance.MaxOxygen;
                    UpdateOxygenTankUI();
                }
            }
        }
    }

    public void UpdateOxygenTankUI()
    {
        foreach (GameObject gameObject in GeneratedOxygenTank)
        {
            Destroy(gameObject);
        }
        for (int i = 0; i < current_oxygen_tank_number; ++i)
        {
            GeneratedOxygenTank.Add(Instantiate(OxygenImagePrefab, GenerateOxygenImagePosition.transform, false));
        }
    }
}