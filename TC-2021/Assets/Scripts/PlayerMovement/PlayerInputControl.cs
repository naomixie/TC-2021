using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputControl : MonoBehaviour
{
    private Raycast raycast;
    private float timer = 0;
    public ParticleSystem WaterPS;
    public ParticleSystem OxygenPS;
    public GameObject TipPanel;
    public Image TipImage;


    public GameObject LadderPrefab;

    void Start()
    {
        raycast = GetComponent<Raycast>();
        AudioManager.instance.GenerateAudioSources();
    }

    void Update()
    {
        if (raycast.raycastedObject != null)
        {
            CheckInteractables();
            // Button just pressed
            if (Input.GetButtonDown("Interact"))
            {
                // Debug.Log("Pressed");
                if (raycast.raycastedObject.tag == "InteractableObject")
                {
                    raycast.raycastedObject.GetComponent<InteractableObject>().Interact();
                }
                else if (raycast.raycastedObject.tag == "Water")
                {
                    if (PlayerResources.instance.mode != PlayerMode.water_gun) return;
                    timer = 0;
                    WaterPS.gameObject.SetActive(true);
                }
                else if (raycast.raycastedObject.tag == "Oxygen")
                {
                    if (PlayerResources.instance.mode != PlayerMode.oxygen_gun) return;
                    OxygenPS.gameObject.SetActive(true);
                }
                else if (raycast.raycastedObject.tag == "Hills")
                {
                    if (PlayerResources.instance.mode != PlayerMode.ladder) return;
                    Instantiate(LadderPrefab, raycast.raycastedObject.transform.position, Quaternion.identity);
                    Inventory.instance.DeductItem(ItemType.ladder, 1);
                }
                else if (raycast.raycastedObject.tag == "InitialSpawn")
                {
                    GetComponent<CharacterController>().enabled = false;
                    gameObject.transform.position = raycast.raycastedObject.GetComponent<Transfer>().where_to_go.position;
                    GetComponent<CharacterController>().enabled = true;
                }
                else if (raycast.raycastedObject.tag == "Workshop")
                {
                    raycast.raycastedObject.GetComponent<InteractableObject>().Interact();
                }

            }
            // Continue Pressing the button
            else if (Input.GetButton("Interact"))
            {
                if (raycast.raycastedObject.tag == "Water")
                {
                    if (WaterSystem.instance.current_water == GlobalVariables.instance.MaxWater || PlayerResources.instance.mode != PlayerMode.water_gun)
                    {
                        return;
                    }
                    timer += Time.deltaTime;
                    if (timer > GlobalVariables.instance.WaterAccquireSpeed)
                    {
                        timer = 0;
                        WaterSystem.instance.current_water++;
                    }
                    WaterPS.gameObject.SetActive(true);
                }
                else if (raycast.raycastedObject.tag == "Oxygen")
                {
                    if (PlayerResources.instance.mode != PlayerMode.oxygen_gun) return;
                    OxygenSystem.instance.current_oxygen += Time.deltaTime;
                    OxygenPS.gameObject.SetActive(true);
                }
            }
            // Releasing the button
            else if (Input.GetButtonUp("Interact"))
            {
                timer = 0;
                WaterPS.gameObject.SetActive(false);
                OxygenPS.gameObject.SetActive(false);
            }

        }
        else
        {
            TipPanel.SetActive(false);
        }

        if (Input.GetButtonDown("Inventory"))
        {
            InventoryPanelSwitch();
        }

    }

    public void CheckInteractables()
    {
        if (raycast.raycastedObject.tag == "InitialSpawn")
        {
            TipPanel.SetActive(true);
            TipImage.sprite = GlobalVariables.instance.TransportSprite;
        }
        else if (raycast.raycastedObject.tag == "Water")
        {
            TipPanel.SetActive(true);
            TipImage.sprite = GlobalVariables.instance.WaterSprite;
        }
        else if (raycast.raycastedObject.tag == "InteractableObject")
        {
            TipPanel.SetActive(true);
            TipImage.sprite = GlobalVariables.instance.TransportSprite;
        }
        else if (raycast.raycastedObject.tag == "Workshop")
        {
            TipPanel.SetActive(true);
            TipImage.sprite = GlobalVariables.instance.BuildSprite;
        }
        else
        {
            TipPanel.SetActive(false);
        }
    }

    public void InventoryPanelSwitch()
    {
        // If other panel is active currently
        if (Workshop.instance.WorkshopPanel.activeSelf)
        {
            InventoryUI.instance.InventoryPanel.SetActive(false);
        }
        else
        {
            InventoryUI.instance.InventoryPanel.SetActive(!InventoryUI.instance.InventoryPanel.activeSelf);
        }

        if (InventoryUI.instance.InventoryPanel.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Confined;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraTrun>().enabled = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraTrun>().enabled = true;
        }
        foreach (InventorySlot slot in InventoryUI.instance.slots)
        {
            slot.UpdateInventorySlot();
        }
    }
}
