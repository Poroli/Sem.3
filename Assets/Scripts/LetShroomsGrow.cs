using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetShroomsGrow : MonoBehaviour
{
    [SerializeField] private GameObject shroomsToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            shroomsToActivate.SetActive(true);
        }
    }
}
