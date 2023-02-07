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
    private Vector3 iceMovingVector;
    private Vector3 stoneMovingVector;
    private float tempC1Speed;
    private float tempC1TurnSmoothTime;
    private bool switchToPush = true;
    private bool changeToDefault = false;
    private Vector2 positionRelToPlayerVector;
    private Vector3 pushDirection;

    private void CheckStoneMovable()
    {
        if (!ObjectMovable && !changeToDefault)
        {
            return;
        }
        if (ObjectMovable)
        {
            rb.constraints = RigidbodyConstraints.None;
            if (switchToPush)
            {
                changeToDefault = true;
                switchToPush = false;
                animator.SetBool("PushStone", true);
                C1Movement.Speed = SpeedWhileMoving;
                C1Movement.TurnSmoothTime = TurnSmoothTimeWhileMoving;
            }
            MoveStone();
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
        rb.velocity = stoneMovingVector;
    }
    private void CalculateStoneMovingVector()
    {
        stoneMovingVector.x = targetposition.transform.position.x - gameObject.transform.position.x;
        stoneMovingVector.z = targetposition.transform.position.z - gameObject.transform.position.z;
        stoneMovingVector *= SmoothSpeed;
        stoneMovingVector.y = rb.velocity.y;
    }

    private void CheckIceCubeMovable()
    {
        if (!ObjectMovable && !changeToDefault)
        {
            return;
        }
        else if (ObjectMovable)
        {
            if (switchToPush)
            {
                switchToPush = false;
                changeToDefault = true;
                SetPushDirection();
                C1Movement.PushingIceCube = true;
                animator.SetBool("PushStone", true);
                C1Movement.Speed = SpeedWhileMoving;
                C1Movement.TurnSmoothTime = TurnSmoothTimeWhileMoving;
            }
            MoveIce();
        }
        else if (changeToDefault)
        {
            changeToDefault = false;
            switchToPush = true;
            C1Movement.PushingIceCube = false;
            pushDirection = Vector3.zero;
            iceMovingVector = Vector3.zero;
            animator.SetBool("PushStone", false);
            C1Movement.Speed = tempC1Speed;
            C1Movement.TurnSmoothTime = tempC1TurnSmoothTime;
        }
    }
    private void MoveIce()
    {
        C1Movement.ViewDirVec.x = gameObject.transform.position.x - C1Movement.transform.position.x;
        C1Movement.ViewDirVec.y = gameObject.transform.position.z - C1Movement.transform.position.z;
        CalculateIceMovingVector();
        if (iceMovingVector.x < 0 && pushDirection.x < 0)
        {
            pushDirection.x *= -1;
        }
        if (iceMovingVector.z > 0 && pushDirection.z < 0)
        {
            pushDirection.z *= -1;
        }
        iceMovingVector.x *= pushDirection.x;
        iceMovingVector.y *= pushDirection.y;
        iceMovingVector.z *= pushDirection.z;
        iceMovingVector *= SmoothSpeed;
        rb.velocity= iceMovingVector;
    }
    private void CalculateIceMovingVector()
    {
            iceMovingVector.x = targetposition.transform.position.x - transform.position.x;
            iceMovingVector.z = targetposition.transform.position.z - transform.position.z;
    }
    private void SetPushDirection()
    {
        positionRelToPlayerVector.x = gameObject.transform.position.x - C1Movement.transform.position.x;
        positionRelToPlayerVector.y = gameObject.transform.position.z - C1Movement.transform.position.z;

        //Backwards
        if (positionRelToPlayerVector.y > 0 && (positionRelToPlayerVector.x > -positionRelToPlayerVector.y && positionRelToPlayerVector.x < positionRelToPlayerVector.y))
        {
            Debug.Log("Front");
            pushDirection.z = -1;
        }
        //Forward
        if (positionRelToPlayerVector.y < 0 && (positionRelToPlayerVector.x < -positionRelToPlayerVector.y && positionRelToPlayerVector.x > positionRelToPlayerVector.y))
        {
            Debug.Log("Back");
            pushDirection.z = 1;
        }
        //Left
        if (positionRelToPlayerVector.x > 0 && (positionRelToPlayerVector.y > -positionRelToPlayerVector.x && positionRelToPlayerVector.y < positionRelToPlayerVector.x))
        {
            Debug.Log("Right");
            pushDirection.x = 1;
        }
        //Right
        if (positionRelToPlayerVector.x < 0 && (positionRelToPlayerVector.y < -positionRelToPlayerVector.x && positionRelToPlayerVector.y > positionRelToPlayerVector.x))
        {
            Debug.Log("Left");
            pushDirection.x = -1;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (gameObject.name == "PushableStone")
        {
            targetposition = GameObject.Find("StonePushTargetPosition");
        }
        else if (gameObject.name == "IceCubeBigPushable")
        {
            targetposition = GameObject.Find("IcePushTargetPosition");
        }
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
