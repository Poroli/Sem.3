using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanCollectThings : MonoBehaviour
{
    [SerializeField] [Range(0,3)] private int collectedThingID;
    /// <summary>
    /// 0 = Sticks
    /// 1 = Coal
    /// 2 = Fabric
    /// 3 = Nose
    /// </summary>
    private SnowmanCollectThingsHandler sCTH;
    public void CollectObject()
    {
        sCTH.accessoiresCollected[collectedThingID] = true;
        gameObject.SetActive(false);
    }

    private void Start()
    {
        sCTH = FindObjectOfType<SnowmanCollectThingsHandler>();
    }
}
