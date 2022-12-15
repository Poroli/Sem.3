using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectShard : MonoBehaviour
{
    private ShardManager shardManager;

    public void CollectingShard()
    {
        shardManager.ShardsCollected += 1;
        shardManager.CheckShardCollectable();
    }
}
