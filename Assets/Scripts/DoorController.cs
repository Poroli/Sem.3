using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnimation;

    public void OpenCloseDoor()
    {
        if (doorAnimation.GetBool("DoorOpen"))
        {
            doorAnimation.SetBool("DoorOpen", false);
        }
        else if (!doorAnimation.GetBool("DoorOpen"))
        {
            doorAnimation.SetBool("DoorOpen", true);
        }
    }

    void Start()
    {
        doorAnimation = GetComponent<Animator>();
    }
}
