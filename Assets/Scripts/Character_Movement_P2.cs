using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement_P2 : MonoBehaviour
{
public CharacterController controller;
public GameObject Camera;
public float speed = 6f;

public float turnSmoothTime = 0.1f;
float turnSmoothVelocity;

private float horizontalP2;
private float verticalP2;

private void Start()
{
    controller = GetComponent<CharacterController>();
    Camera = GameObject.Find("Main_Camera2");
}

void Update()
{
    horizontalP2 = Input.GetAxisRaw("Horizontal_LStick_C2");
    verticalP2 = Input.GetAxisRaw("Vertical_LStick_C2");
    Vector3 direction = new Vector3(horizontalP2, 0f, verticalP2).normalized;

    if (direction.magnitude != 0)
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.transform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        controller.Move(moveDir.normalized * speed * Time.deltaTime);


    }
}
}