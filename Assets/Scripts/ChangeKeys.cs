using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeKeys : MonoBehaviour
{
    public ControlKeys ControlKeys;

    private KeyCode tempKeyCode;
    private bool keyToChangeSelected;
    private bool readyForNewKey;
    private int i;

    public void JumpP1()
    {
        i = 0;
        keyToChangeSelected = true;
    }
    public void InteractP1()
    {
        i = 1;
        keyToChangeSelected = true;
    }
    public void InteractP2()
    {
        i = 2;
        keyToChangeSelected = true;
    }

    private void Keychange()
    {
        switch(i)
        {
            case 0:
                ControlKeys.P1Jump = tempKeyCode;
                break;
            case 1:
                ControlKeys.P1InteractKey = tempKeyCode;
                break;
            case 2:
                ControlKeys.InteractKeyP2 = tempKeyCode;
                break;
        }

    }

    private void Update()
    {
        if (readyForNewKey)
        {
            foreach (KeyCode TempKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(TempKey))
                {
                    readyForNewKey = false;
                    tempKeyCode = TempKey;
                    Keychange();
                }
            }

        }
        else if (keyToChangeSelected)
        {
            readyForNewKey = true;
            keyToChangeSelected = false;
        }
    }
}

