using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public float Inputvalue;
    void Update()
    {
        Inputvalue = Input.GetAxisRaw("DPad_Horizontal_C2");
        
        
        Debug.Log(Inputvalue);
    }
}
