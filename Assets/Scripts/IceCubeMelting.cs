using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;

public class IceCubeMelting : MonoBehaviour
{

    private GameObject IceCube;
   
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Meltable"))
        {
            IceCube = other.gameObject.transform.parent.gameObject;
            GameObject.Destroy(IceCube);

        }
    }


}