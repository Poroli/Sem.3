using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement_P2 : MonoBehaviour
{
    public Rigidbody Rb;
    public GameObject Camera;
    public Control_Keys C_Keys;
    public float speed = 6f;
    public float Jumpforce;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private Jump_Manager j_Manager;
    private float horizontalP2;
    private float verticalP2;

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Camera = GameObject.Find("Main_Camera2");
        j_Manager = GetComponent<Jump_Manager>();
    }

    void Update()
    {
        horizontalP2 = Input.GetAxisRaw("Horizontal_LStick_C2");
        verticalP2 = Input.GetAxisRaw("Vertical_LStick_C2");
    
        Vector3 direction = new Vector3(horizontalP2, 0f, verticalP2).normalized;

        if (Input.GetKeyDown(C_Keys.P2Jump) == true && j_Manager.Grounded())
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
            moveDir = moveDir.normalized * speed;
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