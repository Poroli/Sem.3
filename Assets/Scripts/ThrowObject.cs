using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public GameObject orient_Point;
    public ControlKeys CKeys;
    public Rigidbody rb;
    public float throwForce = 10;
    public bool UpThrow;

    private FixedJoint fJoint;
    private GameObject gOP1;
    private Rigidbody rbP1;
    private bool beingCarried = false;
    private bool hasPlayer = false;

    private void OnTriggerEnter(Collider sCollider)
    {
        if (sCollider.CompareTag("Player1"))
        {
            hasPlayer = true;
        }
    }
    private void OnTriggerExit(Collider sCollider)
    {
        if(sCollider.CompareTag("Player1"))
        {
            hasPlayer = false;
        }
    }

    private void createJoints()
    {
        gameObject.AddComponent<FixedJoint>();
        fJoint = gameObject.GetComponent<FixedJoint>();
        fJoint.connectedBody = rbP1;
    }
    private void destroyJoints()
    {
        Debug.Log("Destroy Joint");
        Destroy(fJoint);
    }

    public void Start()
    {
        gOP1 = GameObject.Find("Player_1");
        rbP1 = gOP1.GetComponent<Rigidbody>();
        orient_Point = GameObject.Find("Target_Position_Stone_Moving");
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (hasPlayer && UpThrow && !beingCarried)
        {
            beingCarried = true;
            transform.position = orient_Point.transform.position;
            createJoints();
            UpThrow = false;
        }
        if (beingCarried && UpThrow)
        {
            beingCarried = false;
            destroyJoints();
            rb.AddForce(orient_Point.transform.up * throwForce);
            UpThrow = false;
        }
    }
}