using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public GameObject raycastedObject;
    public Transform raycastedObjectTransform;
    // private bool interactable;

    private InteractableObject interactableRaycastedObject;

    // Gizmos
    public float radius = 8f;
    // public Transform uiInteractable;


    [SerializeField] private int rayLength = 10;
    [SerializeField] private LayerMask layerMaskInteract;
    //private LayerMask layerMaskInteract = ~(1);


    private void Start()
    {
        // fpsCam = Camera.main;
        // playerBehavior = GetComponent<PlayerBehavior>();
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(GameObject.FindGameObjectWithTag("MainCamera").transform.position, GameObject.FindGameObjectWithTag("MainCamera").transform.forward, out hit, rayLength))
        {
            Debug.Log("Hit an Object!");
            if (hit.collider.CompareTag("InteractableObject"))
            {
                Debug.Log("Hit an Interactable Object!");
                raycastedObject = hit.collider.gameObject;
                raycastedObjectTransform = hit.collider.gameObject.GetComponent<Transform>();
                interactableRaycastedObject = hit.collider.gameObject.GetComponent<InteractableObject>();

                // CrosshairActive();
            }
            else
            {
                raycastedObject = null;
                raycastedObjectTransform = null;
                interactableRaycastedObject = null;
                // CrosshairNormal();
            }
        }
        else
        {
            Debug.Log("Object not found");

            // CrosshairNormal();
        }
    }

    // void CrosshairActive()
    // {
    //     if (!interactable)
    //     {
    //         uiCrosshair.color = Color.red;
    //     }
    //     interactable = true;
    // }

    // void CrosshairNormal()
    // {
    //     if (interactable)
    //     {
    //         uiCrosshair.color = Color.white;
    //     }
    //     interactable = false;
    // }

    // public void CrosshairHide()
    // {
    //     this.uiCrosshair.enabled = false;
    // }

    // public void CrosshairShow()
    // {
    //     this.uiCrosshair.enabled = true;
    // }

    public GameObject GetRaycastedObject()
    {
        return raycastedObject;
    }

    public Transform GetRaycastedObjectTransform()
    {
        return raycastedObjectTransform;
    }

    public InteractableObject GetInteractableRaycastedObject()
    {
        //Debug.Log(interactableRaycastedObject.name);
        if (interactableRaycastedObject != null)
        {
            return interactableRaycastedObject;
        }
        return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
