using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateUpdater : MonoBehaviour
{
    public bool[] bars = new bool[4];

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    void Update()
    {
        for (int i = 0; i < bars.Length; i++)
        {
            animator.SetBool("BarOpen" i.ToString(), bars[i]);
        }
    }
}
