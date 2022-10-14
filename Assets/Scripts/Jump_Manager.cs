using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Jump_Manager : MonoBehaviour
{
    public int actual_jumps;
    public float xtra_range;
    
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private int jumpAmount;
    private CapsuleCollider c_Collider;
    

    private void Start()
    {
        c_Collider = GetComponent<CapsuleCollider>();
    }
    public bool Grounded()
    {
        bool Jump_ready;
        Vector3 SphereCheck_position =new Vector3(transform.position.x, transform.position.y- xtra_range, transform.position.z);
        bool Spherecheck = Physics.CheckSphere(SphereCheck_position, c_Collider.radius, groundlayer);
        
        if (Spherecheck)
        {
            Jump_ready = true;
            actual_jumps = 0;
        }
        else if (!Spherecheck && actual_jumps < jumpAmount)
        {
            Jump_ready = true;
        }
        else 
        { 
         Jump_ready = false;
        }
        
        return Jump_ready;
    }


    private void Update()
    {
        Grounded();
    }
}
