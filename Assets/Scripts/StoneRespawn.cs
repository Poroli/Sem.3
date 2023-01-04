using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneRespawn : MonoBehaviour
{
    [SerializeField] private GameObject StoneRespawnPosition;
    private Rigidbody rb;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NoStoneArea"))
        {
            gameObject.transform.position = StoneRespawnPosition.transform.position;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
