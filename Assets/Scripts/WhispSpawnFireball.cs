using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhispSpawnFireball : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject targetPosition;
    [SerializeField] private ControlKeys cKeys;

    private void SpawnFireball()
    {
        Instantiate(prefab, targetPosition.transform.position, Quaternion.identity);
    }


    private void Update()
    {
        if (Input.GetKeyDown(cKeys.ElementKey))
        {
            SpawnFireball();
        }
    }
}
