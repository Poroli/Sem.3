using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_Moving : MonoBehaviour
{
    public bool Stone_movable;
    public GameObject Targetposition;
    public float Smooth_Speed;
    public Character_Movement_P1 C1_Movement;

    private Rigidbody rb;
    private Vector3 movingVector;
    private float temp_C1_speed;
    private float temp_C1_turnSmoothTime;
    private bool change_to_default;

    private void Move_Stone()
    {
        CalculateMovingVector();
        rb.AddForce(movingVector * Smooth_Speed, ForceMode.Force);
        rb.velocity = movingVector;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        C1_Movement = FindObjectOfType<Character_Movement_P1>();
        temp_C1_speed = C1_Movement.speed;
        temp_C1_turnSmoothTime = C1_Movement.turnSmoothTime;
    }
    private void Update()
    {
        if (Stone_movable)
        {
            rb.constraints = RigidbodyConstraints.None;
            change_to_default = true;
            Move_Stone();
            C1_Movement.speed = 1;
            C1_Movement.turnSmoothTime = 0.75f;
        }
        else
        {
            if (change_to_default)
            {
                C1_Movement.speed = temp_C1_speed;
                C1_Movement.turnSmoothTime = temp_C1_turnSmoothTime;
                change_to_default = false;
            }
        }
    }

    private void CalculateMovingVector()
    {
        movingVector.x = Targetposition.transform.position.x - gameObject.transform.position.x;
        movingVector.z = Targetposition.transform.position.z - gameObject.transform.position.z;
        movingVector = movingVector.normalized * Smooth_Speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Targetposition.transform.position, Vector3.one * 0.25f);
        CalculateMovingVector();
        if (Stone_movable)
            Gizmos.DrawLine(transform.position, transform.position + movingVector);
    }
}
