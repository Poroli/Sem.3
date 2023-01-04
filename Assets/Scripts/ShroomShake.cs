using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomShake : MonoBehaviour
{
    [SerializeField] private GameObject shard;

    private Rigidbody rb;

    private void Start()
    {
        rb = shard.GetComponent<Rigidbody>();        
    }
    public void LetShardDown()
    {
        rb.isKinematic = false;
    }
}
