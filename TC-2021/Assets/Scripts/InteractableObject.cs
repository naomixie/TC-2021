using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 基础交互类
public class InteractableObject : MonoBehaviour
{
    public float radius = 3f;

    void Start()
    {
        gameObject.tag = "InteractableObject";
    }
    public virtual void Interact()
    {
        Debug.Log("Interact");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
