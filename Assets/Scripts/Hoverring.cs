using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoverring : MonoBehaviour
{
    public float XtraRange;
    public float ChangeHeigthPower;

    private Vector3 hoveringCheckPos1;
    private Vector3 hoveringCheckPos2;
    private CapsuleCollider cCollider;
    private Rigidbody rb;
    private bool spherecheck;

    private void Start()
    {
        cCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }
    private void hoveringCheckGround()
    {
        hoveringCheckPos1.x = transform.position.x;
        hoveringCheckPos1.y = transform.position.y - ((cCollider.height / 2) + cCollider.radius);
        hoveringCheckPos1.z = transform.position.z;

        hoveringCheckPos2.x = transform.position.x;
        hoveringCheckPos2.y = hoveringCheckPos1.y - XtraRange;
        hoveringCheckPos2.z = transform.position.z;

        spherecheck = Physics.CheckCapsule(hoveringCheckPos1, hoveringCheckPos2, cCollider.radius);

        if (!spherecheck)
        {
            rb.AddForce(transform.up * -ChangeHeigthPower, ForceMode.Force);
        }
        else if (spherecheck)
        {
            rb.AddForce(transform.up * ChangeHeigthPower, ForceMode.Force);
        }
    }

    private void Update()
    {
        hoveringCheckGround();
    }
}