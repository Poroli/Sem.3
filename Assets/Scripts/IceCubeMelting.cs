using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;

public class IceCubeMelting : MonoBehaviour
{

    private GameObject IceCube;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Meltable"))
        {

            IceCube = other.gameObject;
            GameObject.Destroy(IceCube);

        }
    }

  

}