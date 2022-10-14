using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Jump_Manager : MonoBehaviour
{
    public int actual_jumps;
    public float xtra_range;
    public float J_Cooldown;
    private bool IsOnCooldown = false;

    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private int jumpAmount;
    public CapsuleCollider c_Collider;
    

    private void Start()
    {
        //c_Collider = GetComponent<CapsuleCollider>();
    }
    public bool Grounded()
    {
        bool Jump_ready;
        Vector3 SphereCheck_position =new Vector3(transform.position.x, transform.position.y- xtra_range, transform.position.z);
        bool Spherecheck = Physics.CheckSphere(SphereCheck_position, c_Collider.radius, groundlayer);
        
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 SphereCheck_position = new Vector3(transform.position.x, transform.position.y - xtra_range, transform.position.z);
        Gizmos.DrawSphere(SphereCheck_position, c_Collider.radius);
    }

}
