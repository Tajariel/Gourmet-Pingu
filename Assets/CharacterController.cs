using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Variables initialisation
    public bool move = false;
    public GameObject sprites;
    public Rigidbody rb;
    public float speed = 20f;
    public bool isgrounded = true;
    public float rotationspeed = 1f;
    public float backwardrotspeed= -1f;
    public bool didihitground = false;
    public float jumpforce = 10f;
    public GameObject normal;
    public GameObject Jump_crouch;
    public GameObject Jump_standing;
    public float boostspeed;
    public GameObject loseui;


    // Start is called before the first frame update
    void Start()
    {
        normal.SetActive(true);
        Jump_crouch.SetActive(false);
        Jump_standing.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            move = true;
        }
        if(Input.GetButtonUp("Fire1") || Input.GetButtonUp("Jump"))
        {
            move = false;
        }
    }

    private void FixedUpdate()
    {
        if(isgrounded)
        {
            normal.SetActive(true);
            Jump_crouch.SetActive(false);
            Jump_standing.SetActive(false);
        }
        if(didihitground == false)
        {
            rb.AddForce(transform.right * speed * Time.deltaTime*100f, ForceMode.Force);
        }
        if(move == true)
        {
            if(isgrounded==false)
            {
                rb.AddTorque(transform.up*rotationspeed, ForceMode.Force);
                normal.SetActive(false);
                Jump_crouch.SetActive(true);
                Jump_standing.SetActive(false);
            }
            else
            {
                rb.AddForce(transform.up*jumpforce*Time.fixedDeltaTime*100f,ForceMode.Force);
            }
        }
        else
        {
            if(isgrounded==false)
            {
                normal.SetActive(false);
                Jump_crouch.SetActive(false);
                Jump_standing.SetActive(true);
            }
        }
        if(move == false)
        {
            if(isgrounded==false)
            {
                rb.AddTorque(transform.up*1*Time.fixedDeltaTime*100f, ForceMode.Force);
            }
        }
    }

    public void OnCollisionEnter()
    {
        isgrounded=true;
        normal.SetActive(true);
        Jump_crouch.SetActive(false);
        Jump_standing.SetActive(false);
    }

    public void OnCollisionExit(){
        isgrounded = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Ground")
        {
            didihitground = true;
        
            
            Destroy(gameObject);
            loseui.SetActive(true);
        }
        if(collision.tag == "Rock")
        {
            didihitground = true;
            
            Destroy(gameObject);
            loseui.SetActive(true);
        }
    }
}
