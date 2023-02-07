using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnligthingCandle : MonoBehaviour
{
    [SerializeField] private GameObject shardSpawnPosition;
    [SerializeField] private GameObject shardToSpawn;
    [SerializeField] private LayerMask fireballLayer;
    private EnligthingCandle[] enligthingCandles;
    private GameObject vFXGraph;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == fireballLayer)
        {
            StartCandleFire();
            RandomShardExpose();
            Animator animator = collision.gameObject.GetComponent<Animator>();
            animator.SetTrigger("DestroyFireball");
        }
    }


    private void StartCandleFire()
    {
        vFXGraph.SetActive(true);
    }

    private void RandomShardExpose()
    {
        if (RandomShardExposeHelper.ShardAlreadyExposed)
        {
            return;
        }
        else
        {
            bool ShardGoingExposed = Random.value <= (1/enligthingCandles.Length);
            if (ShardGoingExposed)
            {
                RandomShardExposeHelper.ShardAlreadyExposed = true;
                Instantiate(shardToSpawn, shardSpawnPosition.transform.position, Quaternion.identity);
            }
        }
    }
    private void Start()
    {
        enligthingCandles = FindObjectsOfType<EnligthingCandle>();
        vFXGraph = transform.parent.GetChild(1).gameObject;
    }
}
