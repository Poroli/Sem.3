using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectShard : MonoBehaviour
{
    public int ShardsCollected;
    public int ShardsToCollect;

    private Interact_with_Object IWOs;
    private GameObject[] Shards;

    private void Start()
    {
        Shards = FindObjectsOfType<GameObject>(gameObject.CompareTag("Shard"));
        ShardsToCollect = Shards.Length;
        IWOs = GetComponent<Interact_with_Object>();
    }

    public void CollectingShard()
    {
        ShardsCollected += 1;
        foreach (Interact_Translate IT in IWOs.I_Translates)
        {
            foreach (GameObject GO in Shards)
            {
                if (IT.gameObject == GO)
                {
                    Destroy(IT.gameObject);
                }
            }
        }
    }
}
