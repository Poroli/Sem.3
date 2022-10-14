using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public float Inputvalue;
    public bool[] Elements_Activated;

    public bool Fire_activated;
    public bool Water_activated;
    public bool Earth_activated;
    public bool Air_activated;
    public bool Standart_activated;

    void Update()
    {
        Elements_Activated = new bool[] { Fire_activated, Water_activated, Earth_activated, Air_activated, Standart_activated };
        Inputvalue = Input.GetAxisRaw("DPad_Horizontal_C2");
        
        
        Debug.Log(Inputvalue);
    }


    private void Start()
    {
    }
}
