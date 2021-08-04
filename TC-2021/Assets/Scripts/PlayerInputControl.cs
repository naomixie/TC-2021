using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputControl : MonoBehaviour
{
    private Raycast raycast;
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
            Debug.Log("Pressed");
            if (raycast.GetInteractableRaycastedObject() != null)
            {
                raycast.GetInteractableRaycastedObject().GetComponent<InteractableObject>().Interact();
            }
        }
        else if (Input.GetButtonDown("Inventory"))
        {
            InventoryUI.instance.gameObject.SetActive(!InventoryUI.instance.gameObject.active);
            if (InventoryUI.instance.gameObject.active)
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
