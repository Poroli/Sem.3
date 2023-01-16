using Cinemachine;
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
    private CinemachineFreeLook tPCamera1;
    private GameObject camerafollow;
    private bool resetCam;
    public bool Grounded()
    {
        sphereCheckPosition.x = transform.position.x;
        sphereCheckPosition.y = transform.position.y - XtraRange;
        sphereCheckPosition.z = transform.position.z;
        
        bool Spherecheck = Physics.CheckSphere(sphereCheckPosition, SphereRadius, groundlayer);

        if (!Spherecheck && !resetCam)
        {
            camerafollow = tPCamera1.Follow.gameObject;
            tPCamera1.Follow = null;
            resetCam = true;
        }
        else if (Spherecheck && resetCam)
        {
            tPCamera1.Follow = camerafollow.transform;
           resetCam = false;
        }
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
    private void Start()
    {
        GameObject tPCamera1GO = GameObject.Find("ThirdPersonCamera1");
        tPCamera1 = tPCamera1GO.GetComponent<CinemachineFreeLook>();
    }

    private void Update()
    {
        CheckCooldown();
        Grounded();
    }
}
