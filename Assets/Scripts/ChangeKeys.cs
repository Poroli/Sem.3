using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeKeys : MonoBehaviour
{
    public ControlKeys ControlKeys;
    public bool GetKeyInput;

    private KeyCode tempKeyCode;
    private bool jumpKeychangeP1 = false;
    private bool jumpKeychangeP2 = false;


    public void ChangeForwardP1()
    {
        jumpKeychangeP1 = true;
        GetKeyInput = true;
    }
    public void ChangeBackwardsP1()
    {
        jumpKeychangeP2 = true;
        GetKeyInput = true;
    }



    private void Update()
    {
        if (GetKeyInput)
        {
            foreach (KeyCode TempKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(TempKey))
                {
                    tempKeyCode = TempKey;
                    GetKeyInput = false;
                }
                if (jumpKeychangeP1 && !GetKeyInput)
                {
                    ControlKeys.P1Jump = tempKeyCode;
                    jumpKeychangeP1 = false;
                }
                
                if (jumpKeychangeP2 && !GetKeyInput)
                {
                    ControlKeys.P2Jump = tempKeyCode;
                    jumpKeychangeP2 = false;
                }

            }
        }
    }
}

