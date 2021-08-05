using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transfer : MonoBehaviour
{
    public Transform where_to_go;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "InitialSpawn";
    }

}
