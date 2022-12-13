using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public GameObject player;
    public GameObject playerCam;
    public Control_Keys C_Keys;
    public Rigidbody rb;
    public float throwForce = 10;
    
    private float dist;
    private bool touched = false;
    private bool beingCarried = false;
    private bool hasPlayer = false;

    public void Start()
    {
        player = GameObject.Find("Player_1");
        playerCam = GameObject.Find("Target_Position_Stone_Moving");
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (dist <= 2.5f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
        if (hasPlayer && Input.GetKeyDown(C_Keys.Interact_Key_P1))
        {
            rb.isKinematic = true;
            transform.parent = playerCam.transform;
            beingCarried = true;
        }
        if (beingCarried)
        {
            if (touched)
            {
                rb.isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            if (Input.GetKeyDown(C_Keys.Interact_Key_P1))
            {
                rb.isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                rb.AddForce(playerCam.transform.forward * throwForce);
               
            }   
        }
    }
   

    
    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}