using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDestroy : MonoBehaviour
{
    [SerializeField] private float TimeToDestroyFireball;
    private Animator animator;
    private bool destroyTimerOn;
    private float despawnCounter;

    private void OnCollisionEnter(Collision collision)
    {
            destroyTimerOn = true;
    }

    private void OnCollisionExit(Collision collision)
    {
            destroyTimerOn = false;
            despawnCounter = 0;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (destroyTimerOn)
        {
            despawnCounter += Time.deltaTime;
        }
        if (despawnCounter >= TimeToDestroyFireball && !gameObject.GetComponent<FixedJoint>())
        {
            animator.SetTrigger("DestroyFireball");
        }
    }
}
