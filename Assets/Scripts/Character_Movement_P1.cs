using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement_P1 : MonoBehaviour
{
    public Rigidbody Rb;
    public GameObject Camera;
    public Control_Keys C_Keys;
    public float speed = 6f;
    public float Jumpforce;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private float horizontalP1;
    private float verticalP1;
    private Jump_Manager j_Manager;

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Camera = GameObject.Find("Main_Camera1");
        j_Manager = GetComponent<Jump_Manager>();
    }

    void Update()
    {
        horizontalP1 = Input.GetAxisRaw("Horizontal_LStick_C1");
        verticalP1 = Input.GetAxisRaw("Vertical_LStick_C1");

        Vector3 direction = new Vector3(horizontalP1, 0f, verticalP1).normalized;

        if (Input.GetKeyDown(C_Keys.P1Jump) == true && j_Manager.Grounded())
        {
            j_Manager.StartCooldown();
            j_Manager.actual_jumps += 1;
            Rb.AddForce(0, Jumpforce, 0);
        }
        else if (direction.magnitude != 0)
        { 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir = moveDir.normalized* speed;
            moveDir.y = Rb.velocity.y;
            Rb.velocity = moveDir;
        }
    }
}
