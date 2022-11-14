using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_Moving : MonoBehaviour
{
    public bool Stone_movable;
    public GameObject Motte;
    public float Stonedistance_modifier;

    private Vector3 distance_Stone;
    private Rigidbody rb;


    private void MoveStone()
    {
        if (Motte.transform.forward == gameObject.transform.position && Stone_movable)
        {
            return;
        }
        else if (Stone_movable)
        {
            rb.velocity = Motte.transform.position + Motte.transform.transform.forward + distance_Stone;
        }
    }


    private void Update()
    {
        if (Stone_movable)
        {
            MoveStone();
        }
    }
}
