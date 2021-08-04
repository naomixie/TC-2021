using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("Pressed");
        }
        else if (Input.GetButtonDown("Inventory"))
        {
            Debug.Log("Inventory");
        }
    }
}
