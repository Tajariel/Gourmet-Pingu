using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGroundFollow : MonoBehaviour
{
    // Variables initialisation
    RaycastHit hit;
    public Rigidbody rb;
    public LayerMask lm;
    public float floordistance;
    [SerializeField] private float minimiumSpeed = 0.000005f;
    [SerializeField] private float rotationspeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.SphereCast(transform.position, 0.5f, -(transform.up), out hit, floordistance, lm)) 
        {
            Debug.Log(hit.point);
            transform.up = hit.normal;
            //transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, hit.normal));
            if (rb.velocity.magnitude < minimiumSpeed)
            {
                rb.velocity = rb.velocity.normalized * minimiumSpeed;
            }
        }
        else
        {
            if (Input.GetButton("Jump"))
            {
                transform.Rotate(0f,0f,rotationspeed,Space.Self);
            }
        }
        
    }
}  

