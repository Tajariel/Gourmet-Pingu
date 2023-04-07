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
            Vector3 currentXvelocity = rb.velocity;
            currentXvelocity.y = 0;
            if (currentXvelocity.magnitude < minimiumSpeed)
            {
                currentXvelocity = currentXvelocity.normalized * minimiumSpeed;
                currentXvelocity.y = rb.velocity.y;
                rb.velocity = currentXvelocity;
            }
        }
    }
}  

