using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovementP1 : MonoBehaviour
{
    public Rigidbody Rb;
    public GameObject Camera;
    public ControlKeys C_Keys;
    public float Speed = 6f;
    public float Jumpforce;
    public float TurnSmoothTime = 0.1f;
    public bool CantJump;

    [SerializeField] private Animator animator;
    private GroundedAndJumpSystem jAGSystem;
    private Vector3 tempVec;
    private Vector3 direction;
    private Vector3 moveDir;
    private Vector3 playerVelocity;
    private float turnSmoothVelocity;
    private float horizontalP1;
    private float verticalP1;
    private float angle;
    private float targetAngle;

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Camera = GameObject.Find("Main_Camera1");
        jAGSystem = GetComponent<GroundedAndJumpSystem>();
    }

    void Update()
    {
        horizontalP1 = Input.GetAxisRaw("Horizontal_LStick_C1");
        verticalP1 = Input.GetAxisRaw("Vertical_LStick_C1");

        tempVec.x = horizontalP1;
        tempVec.z = verticalP1;
        direction = tempVec.normalized;

        if (Input.GetKeyDown(C_Keys.P1Jump) && jAGSystem.Grounded() && !CantJump)
        {
            jAGSystem.NotMovableInJump = true;
            jAGSystem.ActualJumps += 1;
            animator.SetTrigger("StartJump");
        }
        else if (direction.magnitude != 0 && !jAGSystem.NotMovableInJump)
        {
            animator.SetBool("IsWalking", true);
            animator.speed = direction.magnitude;
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.transform.eulerAngles.y;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir = tempVec.magnitude * Speed * moveDir.normalized;
            moveDir.y = Rb.velocity.y;
            Rb.velocity = moveDir;
        }
        else
        {
            animator.SetBool("IsWalking", false);
            playerVelocity.y = Rb.velocity.y;
            Rb.velocity = playerVelocity;
        }
    }
}
