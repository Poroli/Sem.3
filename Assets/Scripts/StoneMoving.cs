using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMoving : MonoBehaviour
{
    public CharacterMovementP1 C1Movement;
    public bool StoneMovable;
    public float SmoothSpeed;
    public float SpeedWhileMoving;
    public float TurnSmoothTimeWhileMoving;

    [SerializeField] private Animator animator;
    private GameObject targetposition;
    private Rigidbody rb;
    private Vector3 movingVector;
    private float tempC1Speed;
    private float tempC1TurnSmoothTime;
    private bool changeToStoneMoving = true;
    private bool changeToDefault = false;

    private void MoveStone()
    {
        CalculateMovingVector();
        rb.velocity = movingVector;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetposition = GameObject.Find("PushTargetPosition");
        C1Movement = FindObjectOfType<CharacterMovementP1>();
        tempC1Speed = C1Movement.Speed;
        tempC1TurnSmoothTime = C1Movement.TurnSmoothTime;
    }
    private void Update()
    {
        if (StoneMovable)
        {
            rb.constraints = RigidbodyConstraints.None;
            MoveStone();
            if (changeToStoneMoving)
            {
                changeToDefault = true;
                changeToStoneMoving = false;
                animator.SetBool("PushStone", true);
                C1Movement.Speed = SpeedWhileMoving;
                C1Movement.TurnSmoothTime = TurnSmoothTimeWhileMoving;
            }
        }
        else
        {
            if (changeToDefault)
            {
                changeToDefault = false;
                changeToStoneMoving = true;
                animator.SetBool("PushStone", false);
                C1Movement.Speed = tempC1Speed;
                C1Movement.TurnSmoothTime = tempC1TurnSmoothTime;
            }
        }
    }

    private void CalculateMovingVector()
    {
        movingVector.x = targetposition.transform.position.x - gameObject.transform.position.x;
        movingVector.z = targetposition.transform.position.z - gameObject.transform.position.z;
        movingVector *= SmoothSpeed;
        movingVector.y = rb.velocity.y;
    }
}
