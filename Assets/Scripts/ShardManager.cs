using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardManager : MonoBehaviour
{
    public int ShardsCollected;
    public int ShardsToCollect;
    

    private Interact_with_Object[] IWOs;
    private GameObject[] Shards;


    private void Start()
    {
        Shards = FindObjectsOfType<GameObject>(gameObject.CompareTag("Shard"));
        ShardsToCollect = Shards.Length;
        IWOs = FindObjectsOfType<Interact_with_Object>();
    }

    public void CheckShardCollectable()
    {
        foreach (Interact_with_Object IWO in IWOs)
        {
            foreach (Interact_Translate IT in IWO.I_Translates)
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
}
