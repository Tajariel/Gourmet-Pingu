using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class Character_Input : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 jumpForce;
    [SerializeField] private int boostcounter;
    [SerializeField] private float rotationspeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSaut(InputAction.CallbackContext context)
    {
        if (!rb) return;
        if (!context.performed) return;

        rb.AddForce(jumpForce, ForceMode.Impulse);
        Debug.Log("JUMP !");
    }
    public void OnBackflip(InputAction.CallbackContext context)
    {
        //Debug.Log(boostcounter);
        bool backfliplimiter = false;
        transform.Rotate(0f, 0f, rotationspeed, Space.Self);
        if (transform.rotation.z >= -120 && transform.rotation.y <= -110 && backfliplimiter == false)
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
