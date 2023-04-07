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
    [SerializeField] private PlayerInput playerInput;

    InputAction touchPositionAction;
    InputAction touchPressAction;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPositionAction = playerInput.actions.FindAction("Backflip");
        touchPressAction = playerInput.actions.FindAction("Saut");
    }

    // Update is called once per frame
    void Update()
    {
        OnBackflip();
    }

    public void OnSaut(InputAction.CallbackContext context)
    {
            if (!rb) return;
            if (!context.performed) return;

            rb.AddForce(jumpForce, ForceMode.Impulse);
            Debug.Log("JUMP !");
    }
    public void OnBackflip()
    {
        if (touchPressAction.IsPressed())
        {
            Debug.Log("SPIN");
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
}
