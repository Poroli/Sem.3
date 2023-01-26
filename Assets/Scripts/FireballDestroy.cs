using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDestroy : MonoBehaviour
{
    [SerializeField] private LayerMask despawnIfOnLayer;
    [SerializeField] private float TimeToDestroyFireball;
    private Animator animator;
    private float despawnCounter;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == despawnIfOnLayer)
        {
            despawnCounter += Time.deltaTime;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == despawnIfOnLayer)
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
