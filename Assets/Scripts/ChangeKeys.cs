using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeKeys : MonoBehaviour
{
    public ControlKeys ControlKeys;
    public bool GetKeyInput;

    private KeyCode tempKeyCode;
    private int i;

    public void JumpP1()
    {
        i = 0;
        GetKeyInput = true;
    }
    public void InteractP1()
    {
        i = 1;
        GetKeyInput = true;
    }
    public void InteractP2()
    {
        i = 2;
        GetKeyInput = true;
    }

    private void Keychange()
    {
        switch(i)
        {
            case 0:
                ControlKeys.P1Jump = tempKeyCode;
                break;
            case 1:
                ControlKeys.InteractKeyP1 = tempKeyCode;
                break;
            case 2:
                ControlKeys.InteractKeyP2 = tempKeyCode;
                break;
        }

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
                    Keychange();
                    GetKeyInput = false;
                }
            }
        }
    }
}

