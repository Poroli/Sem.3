using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public float Inputvalue;
    public bool[] ElementsActivated;

    public bool FireActivated;
    public bool WaterActivated;
    public bool EarthActivated;
    public bool AirActivated;
    public bool StandartActivated;

    void Update()
    {
        ElementsActivated = new bool[] { FireActivated, WaterActivated, EarthActivated, AirActivated, StandartActivated };
        Inputvalue = Input.GetAxisRaw("Horizontal_LStick_C2");
        
        
        Debug.Log(Inputvalue);
    }
}
