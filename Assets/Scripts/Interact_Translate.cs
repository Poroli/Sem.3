using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Translate : MonoBehaviour
{

    public bool Interact;

    private int i;
    private Stone_Moving s_moving;
    private bool[] USO = new bool[1];
    /// <summary>
    /// 0 = Stone_Moving
    /// 
    /// 
    /// </summary>
    private void Start()
    {
        if (GetComponent<Stone_Moving>())
        {
            s_moving = GetComponent<Stone_Moving>();
            i = 0;
            USO[i] = true;
        }

    }

    private void Translate_Interact()
    {
        if (USO[i] == true && Interact)
        {
            switch (i)
            {
                case 0:
                    s_moving.Stone_movable = true;
                    break;
                case 1:
                    //Action
                    break;
            }
        }
        else if (USO[i] == true && !Interact)
        {           
            switch (i)
            {
                case 0:
                    s_moving.Stone_movable = false;
                    break;
                case 1:
                    //Action
                    break;
            }
        }
        Interact = false;
    }

    private void Update() => Translate_Interact();
}