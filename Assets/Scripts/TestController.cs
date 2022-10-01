using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public float Inputvalue;
    void Update()
    {
        Inputvalue = Input.GetAxis("Submit_C1");
        
        
        Debug.Log(Inputvalue.ToString());
    }
}
