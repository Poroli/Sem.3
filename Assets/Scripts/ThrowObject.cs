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

    private void createJoints()
    {
        gameObject.AddComponent<FixedJoint>();
        fJoint = gameObject.GetComponent<FixedJoint>();
        fJoint.connectedBody = rbP1;
    }
    private void destroyJoints()
    {
        Destroy(fJoint);
    }

    public void Start()
    {
        gOP1 = GameObject.Find("Player1");
        rbP1 = gOP1.GetComponent<Rigidbody>();
        orient_Point = GameObject.Find("TargetPosition");
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (UpThrow && !beingCarried)
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