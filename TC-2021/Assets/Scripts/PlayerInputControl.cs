using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputControl : MonoBehaviour
{
    private Raycast raycast;
    public float gun_length = 10f;
    private float timer = 0;
    public ParticleSystem WaterPS;
    public ParticleSystem OxygenPS;
    // Start is called before the first frame update
    void Start()
    {
        raycast = GetComponent<Raycast>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            // Debug.Log("Pressed");
            if (raycast.GetInteractableRaycastedObject() != null)
            {
                raycast.GetInteractableRaycastedObject().GetComponent<InteractableObject>().Interact();
            }
            RaycastHit hit;
            if (Physics.Raycast(GameObject.FindGameObjectWithTag("MainCamera").transform.position, GameObject.FindGameObjectWithTag("MainCamera").transform.forward, out hit, gun_length))
            {
                if (hit.collider.tag == "Water")
                {
                    timer = 0;
                    WaterPS.gameObject.SetActive(true);
                }
                else if (hit.collider.tag == "Oxygen")
                {
                    OxygenPS.gameObject.SetActive(true);
                }
            }
        }
        else if (Input.GetButton("Interact"))
        {
            RaycastHit hit;
            if (Physics.Raycast(GameObject.FindGameObjectWithTag("MainCamera").transform.position, GameObject.FindGameObjectWithTag("MainCamera").transform.forward, out hit, gun_length))
            {
                if (hit.collider.tag == "Water")
                {
                    timer += Time.deltaTime;
                    if (timer > 2)
                    {
                        timer = 0;
                        PlayerResources.instance.current_water++;
                    }
                    WaterPS.gameObject.SetActive(true);
                }
                else if (hit.collider.tag == "Oxygen")
                {

                    PlayerResources.instance.current_oxygen += Time.deltaTime;
                    OxygenPS.gameObject.SetActive(true);
                }
            }
        }

        else if (Input.GetButtonUp("Interact"))
        {
            timer = 0;
            WaterPS.gameObject.SetActive(false);
            OxygenPS.gameObject.SetActive(false);
        }
        else if (Input.GetButtonDown("Inventory"))
        {
            InventoryUI.instance.InventoryPanel.SetActive(!InventoryUI.instance.InventoryPanel.activeSelf);
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
        }
    }
}
