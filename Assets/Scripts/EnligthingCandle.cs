using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnligthingCandle : MonoBehaviour
{
    [SerializeField] private GameObject shardSpawnPosition;
    [SerializeField] private GameObject shardToSpawn;
    private EnligthingCandle[] enligthingCandles;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("fireballLayer"))
        {
            StartCandleFire();
            Animator animator = collision.gameObject.GetComponent<Animator>();
            animator.SetTrigger("DestroyFireball");
        }
    }


    private void StartCandleFire()
    {
        Debug.Log("FireStartsToShine");
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
        FindObjectsOfType<EnligthingCandle>();
    }
}
