using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 基础交互类
public class InteractableObject : MonoBehaviour
{
    public float radius = 3f;
    public virtual void Interact()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
