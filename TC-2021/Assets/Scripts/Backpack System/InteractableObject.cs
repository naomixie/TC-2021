using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 基础交互类
public class InteractableObject : MonoBehaviour
{
    public GameObject ObjectPrefab;


    void Start()
    {
        gameObject.tag = "InteractableObject";
    }
    public virtual void Interact()
    {
    }

}
