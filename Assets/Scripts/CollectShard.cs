using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectShard : MonoBehaviour
{
    private ShardManager shardManager;
    public void CollectingShard()
    {
        shardManager.GOToCheck = gameObject;
        shardManager.CheckShardCollectable();
    }

    private void Start()
    {
        shardManager = FindObjectOfType<ShardManager>();
    }
}
