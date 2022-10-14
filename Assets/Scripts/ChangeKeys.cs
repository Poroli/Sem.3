using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeKeys : MonoBehaviour
{
    public Control_Keys ControlKeys;
    public bool GetKeyInput;

    private KeyCode TempKeyCode;
    private bool P1Jump_Keychange = false;
    private bool P2Jump_Keychange = false;


    public void ChangeForwardP1()
    {
        P1Jump_Keychange = true;
        GetKeyInput = true;
    }
    public void ChangeBackwardsP1()
    {
        P2Jump_Keychange = true;
        GetKeyInput = true;
    }



    private void Update()
    {
        if (GetKeyInput == true)
        {
            foreach (KeyCode TempKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(TempKey))
                {
                    TempKeyCode = TempKey;
                    GetKeyInput = false;
                }
                if (P1Jump_Keychange == true && GetKeyInput == false)
                {
                    ControlKeys.P1Jump = TempKeyCode;
                    P1Jump_Keychange = false;
                }
                
                if (P2Jump_Keychange == true && GetKeyInput == false)
                {
                    ControlKeys.P2Jump = TempKeyCode;
                    P2Jump_Keychange = false;
                }

            }
        }
    }
}

