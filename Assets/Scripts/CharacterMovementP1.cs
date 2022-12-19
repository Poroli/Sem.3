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


    private JumpManager j_Manager;
    private float turnSmoothVelocity;
    private float horizontalP1;
    private float verticalP1;

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Camera = GameObject.Find("Main_Camera1");
        j_Manager = GetComponent<JumpManager>();
    }

    void Update()
    {
        horizontalP1 = Input.GetAxisRaw("Horizontal_LStick_C1");
        verticalP1 = Input.GetAxisRaw("Vertical_LStick_C1");

        Vector3 direction = new Vector3(horizontalP1, 0f, verticalP1).normalized;

        if (Input.GetKeyDown(C_Keys.P1Jump) == true && j_Manager.Grounded())
        {
            j_Manager.StartCooldown();
            j_Manager.ActualJumps += 1;
            Rb.AddForce(0, Jumpforce, 0);
        }
        else if (direction.magnitude != 0)
        { 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir = moveDir.normalized * Speed;
            moveDir.y = Rb.velocity.y;
            Rb.velocity = moveDir;
        }
        else
        {
            Vector3 Playervelocity = new Vector3(0, Rb.velocity.y, 0);
            Rb.velocity = Playervelocity;
        }
    }
}
