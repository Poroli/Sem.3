using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Cinemachine;

public class JumpManager : MonoBehaviour
{
    public int ActualJumps;
    public float XtraRange;
    public float JCooldown;
    public float SphereRadius;
    public bool Jumped;

    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private int jumpAmount;
    [SerializeField] private Options options;
    private Vector3 sphereCheckPosition;
    private CinemachineFreeLook tPCamera1;
    private GameObject camerafollow;
    private bool isOnCooldown = false;
    private bool jumpReady;
    private bool resetCam;
    private bool SphereCheck;

    private void DynamicJumpCam()
    {
        if (!SphereCheck && !resetCam && options.DynamicJumpCamOn)
        {
            camerafollow = tPCamera1.Follow.gameObject;
            tPCamera1.Follow = null;
            resetCam = true;
        }
        else if (SphereCheck && resetCam && options.DynamicJumpCamOn)
        {
            tPCamera1.Follow = camerafollow.transform;
           resetCam = false;
        }
    }
    public bool Grounded()
    {
        sphereCheckPosition.x = transform.position.x;
        sphereCheckPosition.y = transform.position.y - XtraRange;
        sphereCheckPosition.z = transform.position.z;
        
        SphereCheck = Physics.CheckSphere(sphereCheckPosition, SphereRadius, groundlayer);

        DynamicJumpCam();

        if (!SphereCheck && ActualJumps < jumpAmount && !CheckCooldown())
        {
            jumpReady = true;
        }
        else if (SphereCheck && !CheckCooldown() && Jumped)
        {
            animator.SetTrigger("JumpLanding");
            Jumped = false;
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
    }
}
