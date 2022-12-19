using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTranslate : MonoBehaviour
{

    public bool Interact;
    public bool InRange;

    private int i;
    private bool switchCount1 = false;
    private bool switchCount2 = true;
    private StoneMoving sMoving;
    private GoAwayWall gAW;
    private ThrowObject tObject;
    private CollectShard collectShard;
    private bool[] uSO = new bool[3];
    /// <summary>
    /// 0 = Stone_Moving
    /// 1 = activate Runes
    /// 2 = Throw
    /// 3 = Shard
    /// 
    /// </summary>
    
    private void Start()
    {
        if (GetComponent<StoneMoving>())
        {
            sMoving = GetComponent<StoneMoving>();
            i = 0;
            uSO[i] = true;
        }
        if (GetComponent<GoAwayWall>())
        {
            gAW = GetComponent<GoAwayWall>();
            i = 1;
            uSO[i] = true;
        }
        if (GetComponent<ThrowObject>())
        {
            tObject = GetComponent<ThrowObject>();
            i = 2;
            uSO[i] = true;
        }
        if (GetComponent<CollectShard>())
        {
            collectShard = GetComponent<CollectShard>();
            i = 3;
            uSO[i] = true;
        }
    }

    private void TranslateInteract()
    {
        if (uSO[i] && Interact)
        {
            switch (i)
            {
                case 0:
                    if (InRange)
                    {
                        sMoving.StoneMovable = true;
                    }
                    else
                    {
                        sMoving.StoneMovable = false;
                    }
                    break;
                case 1:
                    if (!switchCount1)
                    {
                        switchCount1 = true;
                        gAW.ActivateRune = true;
                        switchCount2 = false;
                    }
                    break;
                case 2:
                    if (!switchCount1)
                    {
                        switchCount1 = true;
                        tObject.UpThrow = true;
                        switchCount2 = false;
                    }
                    break;
                case 3:
                    if (!switchCount1)
                    {
                        switchCount1 = true;
                        collectShard.CollectingShard();
                        switchCount2 = false;
                    }
                    break;
            }
        }
        else if (uSO[i] && !Interact)
        {           
            switch (i)
            {
                case 0:
                    sMoving.StoneMovable = false;
                    break;
                case 1:
                    if (!switchCount2)
                    {
                        switchCount2 = true;
                        gAW.ActivateRune = true;
                        switchCount1 = false;
                    }
                    break;
                case 2:
                    if (!switchCount2)
                    {
                        switchCount2 = true;
                        tObject.UpThrow = true;
                        switchCount1 = false;
                    }
                    break;
                case 3:
                    if (!switchCount2)
                    {
                        switchCount2 = true;
                        collectShard.CollectingShard();
                        switchCount1 = false;
                    }
                    break;
            }
        }
    }

    private void Update()
    {
        TranslateInteract();
    }
}