using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoverring : MonoBehaviour
{
    public float xtra_range;
    public float Change_heigth_power;

    private Vector3 hovering_check_pos_1;
    private Vector3 hovering_check_pos_2;
    private CapsuleCollider c_Collider;
    private Rigidbody rb;
    private bool spherecheck;

    private void Start()
    {
        c_Collider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }
    private void Hovering_Check_Ground()
    {
        hovering_check_pos_1.x = transform.position.x;
        hovering_check_pos_1.y = transform.position.y - ((c_Collider.height / 2) + c_Collider.radius);
        hovering_check_pos_1.z = transform.position.z;

        hovering_check_pos_2.x = transform.position.x;
        hovering_check_pos_2.y = hovering_check_pos_1.y - xtra_range;
        hovering_check_pos_2.z = transform.position.z;

        spherecheck = Physics.CheckCapsule(hovering_check_pos_1, hovering_check_pos_2, c_Collider.radius);

        if (!spherecheck)
        {
            rb.AddForce(transform.up * -Change_heigth_power, ForceMode.Force);
        }
        else if (spherecheck)
        {
            rb.AddForce(transform.up * Change_heigth_power, ForceMode.Force);
        }
    }

    private void Update()
    {
        Hovering_Check_Ground();
    }
}