using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMoving : MonoBehaviour
{
    public bool StoneMovable;
    public GameObject Targetposition;
    public float SmoothSpeed;
    public CharacterMovementP1 C1Movement;

    private Rigidbody rb;
    private Vector3 movingVector;
    private float tempC1Speed;
    private float tempC1TurnSmoothTime;
    private bool changeToDefault;

    private void MoveStone()
    {
        CalculateMovingVector();
        rb.AddForce(movingVector * SmoothSpeed, ForceMode.Force);
        rb.velocity = movingVector;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        C1Movement = FindObjectOfType<CharacterMovementP1>();
        tempC1Speed = C1Movement.Speed;
        tempC1TurnSmoothTime = C1Movement.TurnSmoothTime;
    }
    private void Update()
    {
        if (StoneMovable)
        {
            rb.constraints = RigidbodyConstraints.None;
            changeToDefault = true;
            MoveStone();
            C1Movement.Speed = 1;
            C1Movement.TurnSmoothTime = 0.75f;
        }
        else
        {
            if (changeToDefault)
            {
                C1Movement.Speed = tempC1Speed;
                C1Movement.TurnSmoothTime = tempC1TurnSmoothTime;
                changeToDefault = false;
            }
        }
    }

    private void CalculateMovingVector()
    {
        movingVector.x = Targetposition.transform.position.x - gameObject.transform.position.x;
        movingVector.z = Targetposition.transform.position.z - gameObject.transform.position.z;
        movingVector = movingVector.normalized * SmoothSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Targetposition.transform.position, Vector3.one * 0.25f);
        CalculateMovingVector();
        if (StoneMovable)
            Gizmos.DrawLine(transform.position, transform.position + movingVector);
    }
}