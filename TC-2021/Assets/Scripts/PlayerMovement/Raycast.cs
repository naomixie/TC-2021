using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public GameObject raycastedObject;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(GameObject.FindGameObjectWithTag("MainCamera").transform.position, GameObject.FindGameObjectWithTag("MainCamera").transform.forward, out hit, GlobalVariables.instance.inspection_length))
        {
            raycastedObject = hit.collider.gameObject;
        }
        else
        {
            raycastedObject = null;
        }
    }
}
