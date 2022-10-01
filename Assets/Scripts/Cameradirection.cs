using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameradirection : MonoBehaviour
{
    public GameObject obj2;
    public Vector3 direction;
    public float Xangle;
 
 private void Update()
    {
        direction = obj2.transform.position - transform.position;
        direction = direction.normalized;
        Xangle = Mathf.Atan2(direction.x, transform.right.x);
    }
}
