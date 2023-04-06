using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Backflip : MonoBehaviour
{

    Raycast hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            
        }
    }
}
