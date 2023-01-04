using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectShard : MonoBehaviour
{
    private ShardManager shardManager;

    private void Start()
    {
        shardManager = FindObjectOfType<ShardManager>();
    }
    public void CollectingShard()
    {
        shardManager.ShardsCollected += 1;
        shardManager.GOToCheck = gameObject;
        shardManager.CheckShardCollectable();
    }
}
