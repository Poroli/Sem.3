using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator doorAnimation;

    private void OnTriggerEnter(Collider other)
    {
        doorAnimation.SetBool("isOpening", true);
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnimation.SetBool("isOpening", false);
    }

    void Start()
    {
        doorAnimation = this.transform.parent.GetComponent<Animator>();
    }
}
