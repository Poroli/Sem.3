using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ThrowObject : MonoBehaviour
{
    public GameObject orient_Point;
    public ControlKeys CKeys;
    public Rigidbody rb;
    public float throwForce = 1000;
    public bool UpThrow;
    public float MinHorizontalSpeedbeforeHoveringCheck;

    [SerializeField][Range(0,1)] private float ObjectVerticalThrowDirectionImpact;
    [SerializeField][Range(0, 1)] private float ObjectHorizontalThrowDirectionImpact;
    private Hoverring hovering;
    private FixedJoint fJoint;
    private GameObject gOP1;
    private Rigidbody rbP1;
    private Vector3 tempThrowDirection;
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
            SetThrowDirection();
            DestroyJoints();
            rb.AddForce(tempThrowDirection * throwForce);
            if (gameObject.CompareTag("Player2"))
            {
            hovering.thrown = true;
            }
            UpThrow = false;
        }        
    }

    private void SetThrowDirection()
    {
        if (gameObject.CompareTag("Player2"))
        {
            tempThrowDirection = orient_Point.transform.up;
        }
        else if (gameObject.CompareTag("InteractableP1"))
        {
            tempThrowDirection = gOP1.transform.forward;
            tempThrowDirection = tempThrowDirection * ObjectHorizontalThrowDirectionImpact;
            tempThrowDirection.y = ObjectVerticalThrowDirectionImpact;
        }
    }
    private void CheckThrownWhispHorizontalSpeed()
    {
        if (!gameObject.CompareTag("Player2"))
        {
            return;
        }
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