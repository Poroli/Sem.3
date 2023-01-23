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
    public float MinHorizontalSpeedbeforeHoveringCheck;

    private Hoverring hovering;
    private FixedJoint fJoint;
    private GameObject gOP1;
    private Rigidbody rbP1;
    private bool beingCarried = false;

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
        gOP1 = GameObject.Find("Player1");
        rbP1 = gOP1.GetComponent<Rigidbody>();
        orient_Point = GameObject.Find("TargetPosition");
        rb = GetComponent<Rigidbody>();
        hovering= GetComponent<Hoverring>();
    }

    private void CheckCarryThrow()
    {
        //Carry
        if (UpThrow && !beingCarried)
        {
            beingCarried = true;
            transform.position = orient_Point.transform.position;
            CreateJoints();
            UpThrow = false;
        }
        //Throw
        if (beingCarried && UpThrow)
        {
            beingCarried = false;
            DestroyJoints();
            rb.AddForce(orient_Point.transform.up * throwForce);
            hovering.thrown = true;
            UpThrow = false;
        }        
    }

    private void CheckThrownWhispHorizontalSpeed()
    {
        if (!hovering.thrown)
        {
            return;
        }
        else if (rb.velocity.y <= MinHorizontalSpeedbeforeHoveringCheck)
        {
            hovering.thrown = false;
        }
    }
    private void Update()
    {
        CheckThrownWhispHorizontalSpeed();
        CheckCarryThrow();
    }
}