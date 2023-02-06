using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObjects : MonoBehaviour
{
    public CharacterMovementP1 C1Movement;
    public bool ObjectMovable;
    public float SmoothSpeed;
    public float SpeedWhileMoving;
    public float TurnSmoothTimeWhileMoving;

    [SerializeField] private Animator animator;
    [SerializeField] [Range(0,1)] private int objectToMoveID;
    private GameObject targetposition;
    private Rigidbody rb;
    private Vector3 movingVector;
    private float tempC1Speed;
    private float tempC1TurnSmoothTime;
    private bool switchToPush = true;
    private bool changeToDefault = false;
    private Vector2 positionRelToPlayerVector;
    private Vector2 pushDirection;

    private void CheckStoneMovable()
    {
        if (!ObjectMovable)
        {
            return;
        }
        if (ObjectMovable)
        {
            rb.constraints = RigidbodyConstraints.None;
            MoveStone();
            if (switchToPush)
            {
                changeToDefault = true;
                switchToPush = false;
                animator.SetBool("PushStone", true);
                C1Movement.Speed = SpeedWhileMoving;
                C1Movement.TurnSmoothTime = TurnSmoothTimeWhileMoving;
            }
        }
        else if (changeToDefault)
        {
            changeToDefault = false;
            switchToPush = true;
            animator.SetBool("PushStone", false);
            C1Movement.Speed = tempC1Speed;
            C1Movement.TurnSmoothTime = tempC1TurnSmoothTime;
        }
    }
    private void MoveStone()
    {
        CalculateStoneMovingVector();
        rb.velocity = movingVector;
    }
    private void CalculateStoneMovingVector()
    {
        movingVector.x = targetposition.transform.position.x - gameObject.transform.position.x;
        movingVector.z = targetposition.transform.position.z - gameObject.transform.position.z;
        movingVector *= SmoothSpeed;
        movingVector.y = rb.velocity.y;
    }

    private void CheckIceCubeMovable()
    {
        if (!ObjectMovable)
        {
            return;
        }
        else if (ObjectMovable)
        {
            CheckIceCubeMovable();
            if (switchToPush)
            {
                SetPushDirection();
                changeToDefault = true;
            //    switchToPush = true;
                animator.SetBool("PushStone", true);
            //    C1Movement.Speed = SpeedWhileMoving;
            //    C1Movement.TurnSmoothTime = TurnSmoothTimeWhileMoving;
            }
        }
        else if (changeToDefault)
        {
            changeToDefault = false;
            switchToPush = true;
            animator.SetBool("PushStone", false);
            C1Movement.Speed = tempC1Speed;
            C1Movement.TurnSmoothTime = tempC1TurnSmoothTime;
        }
    }
    private void MoveIce()
    {
        CalculateIceMovingVector();
        rb.velocity = movingVector;
    }
    private void CalculateIceMovingVector()
    {
        movingVector.x = targetposition.transform.position.x - gameObject.transform.position.x;
        movingVector.z = targetposition.transform.position.z - gameObject.transform.position.z;
        movingVector *= SmoothSpeed;
        movingVector.y = rb.velocity.y;
    }
    private void SetPushDirection()
    {
        positionRelToPlayerVector.x = gameObject.transform.position.x - C1Movement.transform.position.x;
        positionRelToPlayerVector.y = gameObject.transform.position.z - C1Movement.transform.position.z;

        //Backwards
        if (positionRelToPlayerVector.y > 0 && (positionRelToPlayerVector.x > -positionRelToPlayerVector.y && positionRelToPlayerVector.x < positionRelToPlayerVector.y))
        {
            Debug.Log("FRONT");
        }
        //Forward
        if (positionRelToPlayerVector.y < 0 && (positionRelToPlayerVector.x < -positionRelToPlayerVector.y && positionRelToPlayerVector.x > positionRelToPlayerVector.y))
        {
            Debug.Log("Back");
        }
        //Left
        if (positionRelToPlayerVector.x > 0 && (positionRelToPlayerVector.y > -positionRelToPlayerVector.x && positionRelToPlayerVector.y < positionRelToPlayerVector.x))
        {
            Debug.Log("Right");
        }
        //Right
        if (positionRelToPlayerVector.x < 0 && (positionRelToPlayerVector.y < -positionRelToPlayerVector.x && positionRelToPlayerVector.y > positionRelToPlayerVector.x))
        {
            Debug.Log("Left");
        }
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
        switch (objectToMoveID)
        {
            case 0:
                CheckStoneMovable();
                break;
            case 1:
                CheckIceCubeMovable();
                break;
        }
    }

}
