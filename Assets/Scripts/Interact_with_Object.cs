using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_with_Object_P1 : MonoBehaviour
{
    public float Interact_Sphere_distance;
    public float Interact_Sphere_radius;
    public Control_Keys C_Keys;
    public GameObject Interact_Object;

    
    [SerializeField] private LayerMask Interactable_layer;

    private void Update()
    {
        Vector3 Interactable_SphereCheck_position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Interact_Sphere_distance);
        bool Interactable_Spherecheck = Physics.CheckSphere(Interactable_SphereCheck_position, Interact_Sphere_radius, Interactable_layer);
        
        if( Interactable_Spherecheck && Input.GetKeyDown(C_Keys.Interact_Key_P1))
        {
            
        }

        
    }
}
