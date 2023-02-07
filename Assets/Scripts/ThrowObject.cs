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
    private CharacterMovementP1 cMP1;
    private GroundedAndJumpSystem jAGSystem;
    private Animator animatorP1;
    private Animator animatorP2;
    private Hoverring hovering;
    private FixedJoint fJoint;
    private GameObject gOP1;
    private GameObject cModelMoth;
    private Rigidbody rbP1;
    private Vector3 tempThrowDirection;
    private bool beingCarried = false;
    private bool disableCTWHS;
    private bool isWhisp;
    private bool speedToActivateMHSHC;

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

    private void CheckCarryThrow()
    {
        //Carry
        if (UpThrow && !beingCarried)
        {
            beingCarried = true;
            cMP1.CantJump = true;
            if (isWhisp)
            {
                disableCTWHS = true;
            }
            jAGSystem.NotMovableInJump = false;
            jAGSystem.OnAir = false;
            animatorP1.SetBool("Carrying", true);
            transform.position = orient_Point.transform.position;
            CreateJoints();
            if (gameObject.CompareTag("Player2"))
            {
                hovering.disableHoveringCheck = true;
            }
            UpThrow = false;
        }
        //Throw
        if (beingCarried && UpThrow)
        {
            beingCarried = false;
            SetThrowDirection();
            DestroyJoints();
            rb.AddForce(tempThrowDirection * throwForce);
            animatorP1.speed = 1;
            animatorP2.SetBool("Flying", true);
            animatorP1.SetTrigger("Throwing");
            animatorP1.SetBool("Carrying", false);
            cMP1.CantJump = false;
            UpThrow = false;
            if (isWhisp)
            {
                disableCTWHS = false;
            }
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
            tempThrowDirection *= ObjectHorizontalThrowDirectionImpact;
            tempThrowDirection.y = ObjectVerticalThrowDirectionImpact;
        }
    }
    private void CheckThrownWhispHorizontalSpeed()
    {
        if (!hovering.disableHoveringCheck)
        {
            return;
        }
        else if (rb.velocity.y >= MinHorizontalSpeedbeforeHoveringCheck)
        {
            speedToActivateMHSHC = true;
        }
        else if (rb.velocity.y <= MinHorizontalSpeedbeforeHoveringCheck && speedToActivateMHSHC)
        {
            hovering.disableHoveringCheck = false;
            speedToActivateMHSHC = false;
            animatorP2.SetBool("Flying", false);
        }
    }

    public void Start()
    {
        gOP1 = GameObject.Find("Player1");
        rbP1 = gOP1.GetComponent<Rigidbody>();
        orient_Point = GameObject.Find("CarryTargetPosition");
        rb = GetComponent<Rigidbody>();
        cModelMoth = GameObject.Find("Character_Moth");
        animatorP1 = cModelMoth.GetComponent<Animator>();
        animatorP2 = GetComponentInChildren<Animator>();
        cMP1 = cModelMoth.GetComponentInParent<CharacterMovementP1>();
        jAGSystem = FindObjectOfType<GroundedAndJumpSystem>();
        if (gameObject.CompareTag("Player2"))
        {
            isWhisp = true;
            hovering = GetComponent<Hoverring>();
        }
        else
        {
            isWhisp = false;
        }
    }
    private void Update()
    {
        CheckCarryThrow();
        if (!disableCTWHS && isWhisp)
        {
            CheckThrownWhispHorizontalSpeed();
        }
    }
}