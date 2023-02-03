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
    public float compensateRadius = 0.15f;
    public bool CantJump;

    [SerializeField] [Range(0,1)]private float CanMoveDirectionCheckSphereDistance;
    [SerializeField] [Range(0,-1)]private float dotMinCanMoveDirectionCheckSphere;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask CanMoveDirectionCheckSphereLayerMask;
    private GroundedAndJumpSystem jAGSystem;
    private CapsuleCollider cCollider;
    private RaycastHit hit;
    private Vector3 direction;
    private Vector3 moveDir;
    private Vector3 playerVelocity;
    private Vector3 moveSpeed;
    private Vector3 cCastPos1;
    private Vector3 cCastPos2;
    private float dot;
    private float turnSmoothVelocity;
    private float horizontalP1;
    private float verticalP1;
    private float angle;
    private float targetAngle;

    private void CheckNormalObjectInMoveDirection()
    {
        cCastPos1.x = cCollider.center.x;
        cCastPos1.y = cCollider.center.y + (cCollider.height / 2);
        cCastPos1.z = cCollider.center.z;
        
        cCastPos2.x = cCollider.center.x;
        cCastPos2.y = cCollider.center.y - (cCollider.height / 2);
        cCastPos2.z = cCollider.center.z;

        if (Physics.CapsuleCast((transform.position + cCastPos1), (transform.position + cCastPos2), cCollider.radius - compensateRadius, gameObject.transform.forward, out hit, CanMoveDirectionCheckSphereDistance, CanMoveDirectionCheckSphereLayerMask))
        {
            dot = Vector3.Dot(hit.normal, gameObject.transform.forward);
            if (dot <= dotMinCanMoveDirectionCheckSphere && verticalP1 > 0)
            {
                verticalP1 = 0;
            }
        }
    }

    private void Walking()
    {
            animator.SetBool("IsWalking", true);
            animator.speed = moveSpeed.magnitude;
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.transform.eulerAngles.y;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir = direction.magnitude * Speed * moveDir.normalized;
            moveDir.y = Rb.velocity.y;
            Rb.velocity = moveDir;
    }
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Camera = GameObject.Find("Main_Camera1");
        jAGSystem = GetComponent<GroundedAndJumpSystem>();
        cCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        horizontalP1 = Input.GetAxisRaw("Horizontal_LStick_C1");
        verticalP1 = Input.GetAxisRaw("Vertical_LStick_C1");

        CheckNormalObjectInMoveDirection();

        direction.x = horizontalP1;
        direction.z = verticalP1;
        moveSpeed = direction;
        direction = direction.normalized;
        if (Input.GetKeyDown(C_Keys.P1Jump) && jAGSystem.Grounded() && !CantJump)
        {
            jAGSystem.NotMovableInJump = true;
            jAGSystem.ActualJumps += 1;
            animator.SetTrigger("StartJump");
        }
        else if (direction.magnitude != 0 && !jAGSystem.NotMovableInJump)
        {
            Walking();
        }
        else
        {
            animator.SetBool("IsWalking", false);
            playerVelocity.y = Rb.velocity.y;
            Rb.velocity = playerVelocity;
        }
    }
}

