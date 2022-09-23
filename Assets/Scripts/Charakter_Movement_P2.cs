using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charakter_Movement_P2 : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Control_Keys C_Keys;
    private float horizontalP2;
    private float verticalP2;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Update()
    {
        if (Input.GetKey(C_Keys.P2Forward))
        {
            verticalP2 = 1;
        }
        else if (Input.GetKey(C_Keys.P2Backwards))
        {
            verticalP2 = -1;
        }
        else
        {
            verticalP2 = 0;
        }

        if (Input.GetKey(C_Keys.P2Left))
        {
            horizontalP2 = 1;
        }
        else if (Input.GetKey(C_Keys.P2Right))
        {
            horizontalP2 = -1;
        }
        else
        {
            horizontalP2 = 0;
        }

        Vector3 direction = new Vector3(horizontalP2, 0f, verticalP2).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);


        }
    }
}
