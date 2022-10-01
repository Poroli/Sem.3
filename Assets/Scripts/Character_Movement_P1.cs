using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement_P1 : MonoBehaviour
{
    public CharacterController controller;
    public Control_Keys C_Keys;
    public Transform cam;
    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private float horizontalP1;
    private float verticalP1;



    void Update()
    {
        if (Input.GetKey(C_Keys.P1Forward))
        {
            verticalP1 = 1;
        }
        else if (Input.GetKey(C_Keys.P1Backwards))
        {
            verticalP1 = -1;
        }
        else
        {
            verticalP1 = 0;
        }
        
        if (Input.GetKey(C_Keys.P1Left))
        {
            horizontalP1 = -1;
        }
        else if (Input.GetKey(C_Keys.P1Right))
        {
            horizontalP1 = 1;
        }
        else
        {
            horizontalP1 = 0;
        }
        Vector3 direction = new Vector3(horizontalP1, 0f, verticalP1).normalized;

        if (direction.magnitude != 0)
        { 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        
        }
    }
}
