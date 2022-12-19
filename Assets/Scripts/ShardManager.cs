using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardManager : MonoBehaviour
{
    public GameObject GOToCheck;
    public int ShardsCollected;
    public int ShardsToCollect;
    

    private InteractWithObject[] iWOs;
    private GameObject[] shards;


    private void Start()
    {
        shards = FindObjectsOfType<GameObject>(gameObject.CompareTag("Shard"));
        ShardsToCollect = shards.Length;
        iWOs = FindObjectsOfType<InteractWithObject>();
    }

    public void CheckShardCollectable()
    {
        foreach (InteractWithObject IWO in iWOs)
        {
            foreach (InteractTranslate IT in IWO.ITranslates)
            {
                foreach (GameObject GO in shards)
                {
                    if (IT.gameObject == GO == GOToCheck)
                    {
                        Destroy(IT.gameObject);
                    }
                }
            }
        }
    }
}
