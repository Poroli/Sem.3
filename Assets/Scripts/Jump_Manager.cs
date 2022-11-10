using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Jump_Manager : MonoBehaviour
{
    public CapsuleCollider c_Collider;
    public int actual_jumps;
    public float xtra_range;
    public float J_Cooldown;
    public float Sphere_Radius;

    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private int jumpAmount;
    private bool IsOnCooldown = false;
    

    private void Start()
    {
        c_Collider = GetComponent<CapsuleCollider>();
    }
    public bool Grounded()
    {
        bool Jump_ready;
        Vector3 SphereCheck_position = new Vector3(transform.position.x, transform.position.y - xtra_range, transform.position.z);
        bool Spherecheck = Physics.CheckSphere(SphereCheck_position, Sphere_Radius, groundlayer);
        
        if (!Spherecheck && actual_jumps < jumpAmount && !CheckCooldown())
        {
            Jump_ready = true;
        }
        else if (Spherecheck && !CheckCooldown())
        {
            Jump_ready = true;
            actual_jumps = 0;
        }
        else 
        { 
         Jump_ready = false;
        }
        return Jump_ready;
    }
    public void StartCooldown()
    {
        IsOnCooldown = true;
        Invoke("EndCooldown", J_Cooldown);
    }
    private bool CheckCooldown()
    {
        return IsOnCooldown;
    }
    private void EndCooldown()
    {
        IsOnCooldown = false;
    }

    private void Update()
    {
        CheckCooldown();
        Grounded();
    }
}
