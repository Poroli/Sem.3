using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeKeys : MonoBehaviour
{
    public Control_Keys ControlKeys;
    public bool GetKeyInput;

    private KeyCode TempKeyCode;
    private bool P1Forward_Keychange = false;
    private bool P1Backwards_Keychange = false;
    private bool P1Left_Keychange = false;
    private bool P1Right_Keychange = false;

    private bool P2Forward_Keychange = false;
    private bool P2Backwards_Keychange = false;
    private bool P2Left_Keychange = false;
    private bool P2Right_Keychange = false;

    
    public void ChangeForwardP1()
    {
        P1Forward_Keychange = true;
        GetKeyInput = true;
    }
    public void ChangeBackwardsP1()
    {
        P1Backwards_Keychange = true;
        GetKeyInput = true;
    }
    public void ChangeLeftP1()
    {
        P1Left_Keychange = true;
        GetKeyInput = true;
    }
    public void ChangeRightP1()
    {
        P1Right_Keychange = true;
        GetKeyInput = true;
    }

    public void ChangeForwardP2()
    {
        P2Forward_Keychange = true;
        GetKeyInput = true;
    }
    public void ChangeBackwardsP2()
    {
        P2Backwards_Keychange = true;
        GetKeyInput = true;
    }
    public void ChangeLeftP2()
    {
        P2Left_Keychange = true;
        GetKeyInput = true;
    }
    public void ChangeRightP2()
    {
        P2Right_Keychange = true;
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
            if (P1Forward_Keychange == true && GetKeyInput == false)
            {
                ControlKeys.P1Forward = TempKeyCode;
                P1Forward_Keychange = false;
            }
            if (P1Backwards_Keychange == true && GetKeyInput == false)
            {
                ControlKeys.P1Backwards = TempKeyCode;
                P1Backwards_Keychange = false;
            }
            if (P1Left_Keychange == true && GetKeyInput == false)
            {
                ControlKeys.P1Left = TempKeyCode;
                P1Left_Keychange = false;
            }
            if (P1Right_Keychange == true && GetKeyInput == false)
            {
                ControlKeys.P1Right = TempKeyCode;
                P1Right_Keychange = false;
            }
            
            
            if (P2Forward_Keychange == true && GetKeyInput == false)
            {
                ControlKeys.P2Forward = TempKeyCode;
                P2Forward_Keychange = false;
            }
            if (P2Backwards_Keychange == true && GetKeyInput == false)
            {
                ControlKeys.P2Backwards = TempKeyCode;
                P2Backwards_Keychange = false;
            }
            if (P2Left_Keychange == true && GetKeyInput == false)
            {
                ControlKeys.P2Left = TempKeyCode;
                P2Left_Keychange = false;
            }
            if (P2Right_Keychange == true && GetKeyInput == false)
            {
                ControlKeys.P2Right = TempKeyCode;
                P2Right_Keychange = false;             }
            }
        }

    }
}

