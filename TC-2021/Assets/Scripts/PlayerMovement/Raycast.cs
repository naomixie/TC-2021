using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public GameObject raycastedObject;

    void Update()
    {
        if (Camera.main == null) return;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, GlobalVariables.instance.inspection_length))
        {
            raycastedObject = hit.collider.gameObject;
        }
        else
        {
            raycastedObject = null;
        }
    }
}
