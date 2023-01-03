using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    public int ActualJumps;
    public float XtraRange;
    public float JCooldown;
    public float SphereRadius;


    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private int jumpAmount;
    private CapsuleCollider cCollider;
    private Vector3 sphereCheckPosition;
    private bool isOnCooldown = false;
    private bool jumpReady;
    
    public bool Grounded()
    {
        sphereCheckPosition.x = transform.position.x;
        sphereCheckPosition.y = transform.position.y - XtraRange;
        sphereCheckPosition.z = transform.position.z;
        
        bool Spherecheck = Physics.CheckSphere(sphereCheckPosition, SphereRadius, groundlayer);
        
        if (!Spherecheck && ActualJumps < jumpAmount && !CheckCooldown())
        {
            jumpReady = true;
        }
        else if (Spherecheck && !CheckCooldown())
        {
            jumpReady = true;
            ActualJumps = 0;
        }
        else 
        { 
         jumpReady = false;
        }
        return jumpReady;
    }
    public void StartCooldown()
    {
        isOnCooldown = true;
        Invoke("EndCooldown", JCooldown);
    }
    private bool CheckCooldown()
    {
        return isOnCooldown;
    }
    private void EndCooldown()
    {
        isOnCooldown = false;
    }

    private void Update()
    {
        CheckCooldown();
        Grounded();
    }
}
