using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectShard : MonoBehaviour
{
    public void CollectingShard()
    {
        ShardManager.GOToCheck = gameObject;
        ShardManager.CheckShardCollectable();
    }
}
