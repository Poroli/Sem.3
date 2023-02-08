using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDestroy : MonoBehaviour
{
    [SerializeField] private LayerMask despawnIfOnThisLayer;
    [SerializeField] private float TimeToDestroyFireball;
    private Animator animator;
    private float despawnCounter;

    private void OnCollisionStay(Collision collision)
    {
            Debug.Log("Test");
        if (collision.gameObject.layer == despawnIfOnThisLayer)
        {
            despawnCounter += Time.deltaTime;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == despawnIfOnThisLayer)
        {
            Debug.Log("Unground");
            despawnCounter = 0;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (despawnCounter >= TimeToDestroyFireball)
        {
            animator.SetTrigger("DestroyFireball");
        }
    }
}
