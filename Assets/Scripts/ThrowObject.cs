using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public GameObject orient_Point;
    public Control_Keys C_Keys;
    public Rigidbody rb;
    public float throwForce = 10;
    public bool up_throw;

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

    private void CreateJoints()
    {
        gameObject.AddComponent<FixedJoint>();
        fJoint = gameObject.GetComponent<FixedJoint>();
        fJoint.connectedBody = rbP1;
    }
    private void DestroyJoints()
    {
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
        if (hasPlayer && up_throw && !beingCarried)
        {
            beingCarried = true;
            up_throw = false;
            transform.position = orient_Point.transform.position;
            CreateJoints();
        }
        if (beingCarried && up_throw)
        {
            beingCarried = false;
            DestroyJoints();
            rb.AddForce(orient_Point.transform.up * throwForce);
            up_throw = false;
        }
    }
}