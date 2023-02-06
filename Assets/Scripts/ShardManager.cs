using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardManager : MonoBehaviour
{
    public static GameObject GOToCheck;
    
    [SerializeField] [Range(0,6)] private int ShardsToCollect;
    private static int ShardsCollected;
    
    private static InteractWithObject[] iWOs;

    private void Start()
    {
        iWOs = FindObjectsOfType<InteractWithObject>();
    }

    public static void CheckShardCollectable()
    {
        foreach (InteractWithObject IWO in iWOs)
        {
            foreach (InteractTranslate IT in IWO.InteractTranslates)
            {
                if(IT.gameObject.CompareTag("Shard") && GOToCheck)
                {
                    IT.gameObject.SetActive(false);
                    ShardsCollected += 1;
                }
            }
            IWO.RefreshInteractTranslates();
        }
    }
}
