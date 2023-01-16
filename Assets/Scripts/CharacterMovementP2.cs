using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovementP2 : MonoBehaviour
{
    public Rigidbody Rb;
    public GameObject Camera;
    public ControlKeys CKeys;
    public float Speed = 6f;
    public float Jumpforce;
    public float TurnSmoothTime = 0.1f;


    private Vector3 tempVec;
    private Vector3 direction;
    private Vector3 moveDir;
    private Vector3 playerVelocity;
    private float turnSmoothVelocity;
    private float horizontalP2;
    private float verticalP2;
    private float angle;
    private float targetAngle;


    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Camera = GameObject.Find("Main_Camera2");
    }

    void Update()
    {
        horizontalP2 = Input.GetAxisRaw("Horizontal_LStick_C2");
        verticalP2 = Input.GetAxisRaw("Vertical_LStick_C2");

        tempVec.x = horizontalP2;
        tempVec.z = verticalP2;
        direction = tempVec.normalized;

        if (direction.magnitude != 0)
        {
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
            playerVelocity.y = Rb.velocity.y;
            Rb.velocity = playerVelocity;
        }
    }
}