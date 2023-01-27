using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoverring : MonoBehaviour
{
    public float XtraRange;
    public float ChangeHeigthPower;
    public float HoveringHeigth;
    public bool thrown;

    [SerializeField] private LayerMask lM;
    private Vector3 hoveringCheckPos1;
    private Vector3 changeHeigthVec;
    private RaycastHit hit;
    private CapsuleCollider cCollider;
    private Rigidbody rb;
    private bool spherecast;
    private float distance;

    private void HeightChange()
    {
        distance = HoveringHeigth - hit.distance;
        changeHeigthVec = Vector3.zero;
        changeHeigthVec.y = distance;
    }

    private void Start()
    {
        cCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }
    private void HoveringCheckGround()
    {
        if (thrown)
        {
            return;
        }
        hoveringCheckPos1.x = transform.position.x;
        hoveringCheckPos1.y = transform.position.y;
        hoveringCheckPos1.z = transform.position.z;

        spherecast = Physics.SphereCast(hoveringCheckPos1, cCollider.radius, Vector3.down, out hit, XtraRange, lM);

        if (!spherecast)
        {
            rb.AddForce(transform.up * -ChangeHeigthPower, ForceMode.Force);
        }
        else if (spherecast)
        {
            HeightChange();
            rb.AddForce(changeHeigthVec * ChangeHeigthPower, ForceMode.Force);
        }
    }
    private void SetFlyMode()
    {

    }

    private void FixedUpdate()
    {
        HoveringCheckGround();
    }
}