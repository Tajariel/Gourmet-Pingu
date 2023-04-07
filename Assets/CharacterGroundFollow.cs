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
    private int boostcounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.SphereCast(transform.position, 0.5f, -(transform.up), out hit, floordistance, lm)) 
        {
            Vector3 normal1 = hit.normal;
            if(Physics.SphereCast(transform.position+transform.right, 0.5f, -(transform.up), out hit, floordistance, lm))
            {
                Vector3 normal2 = hit.normal;
                Vector3 midnormal = (normal1 + normal2) / 2;
                transform.up = midnormal;
            }
            else
            {
                transform.up = normal1;
            }
            if (Physics.SphereCast(transform.position - transform.right, 0.5f, -(transform.up), out hit, floordistance, lm))
            {
                Vector3 normal2 = hit.normal;
                Vector3 midnormal = (normal1 + normal2) / 2;
                transform.up = midnormal;
            }
            else
            {
                transform.up = normal1;
            }

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
                //Debug.Log(boostcounter);
                bool backfliplimiter=false;
                transform.Rotate(0f,0f,rotationspeed,Space.Self);
                if(transform.rotation.z >= -120 && transform.rotation.y <= -110 && backfliplimiter == false)
                {
                    backfliplimiter = true;
                    boostcounter += 1;
                    Debug.Log(boostcounter);
                }
                if (transform.rotation.z >= 0 && backfliplimiter == true)
                {
                    backfliplimiter = false;
                    Debug.Log(boostcounter);
                }
            }
        }
        
    }
}  

