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
    private PushObjects sMoving;
    private GoAwayWall gAW;
    private ThrowObject tObject;
    private CollectShard collectShard;
    private ShroomShake shake;
    private DialogueTrigger dialogueTrigger;
    private MoveBridge mBridge;
    private MainMenu mainMenu;
    private SnowmanCollectThings snowmanCollectThings;
    private bool[] uSO = new bool[9];
    /// <summary>
    /// 0 = Stone_Moving
    /// 1 = activate Runes
    /// 2 = Throw
    /// 3 = Shard
    /// 4 = Shroom
    /// 5 = Dialogue
    /// 6 = Bridge
    /// 7 = MainMenuFunctions
    /// 8 = SnowmanCollectThings
    /// 
    /// </summary>
    
    private void Start()
    {
        if (GetComponent<PushObjects>())
        {
            sMoving = GetComponent<PushObjects>();
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
        if (GetComponent<ShroomShake>())
        {
            shake = GetComponent<ShroomShake>();
            i = 4;
            uSO[i] = true;
        }
        if (GetComponent<DialogueTrigger>())
        {
            dialogueTrigger = GetComponent<DialogueTrigger>();
            i = 5;
            uSO[i] = true;
        }
        if (GetComponent<MoveBridge>())
        {
            mBridge = GetComponent<MoveBridge>();
            i = 6;
            uSO[i] = true;
        }
        if (GetComponent<MainMenu>())
        {
            mainMenu = GetComponent<MainMenu>();
            i = 7;
            uSO[i] = true;
        }
        if (GetComponent<SnowmanCollectThings>())
        {
            snowmanCollectThings = GetComponent<SnowmanCollectThings>();
            i = 8;
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
                        sMoving.ObjectMovable = true;
                    }
                    else
                    {
                        Interact = false;
                        sMoving.ObjectMovable = false;
                    }
                    break;
                case 1:
                    if (!switchCount1)
                    {
                        switchCount1 = true;
                        gAW.WichRuneChange();
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
                case 4:
                    if (!switchCount1)
                    {
                        switchCount1 = true;
                        shake.LetShardDown();
                        switchCount2 = false;
                    }
                    break;
                case 5:
                    if (!switchCount1)
                    {
                        switchCount1 = true;
                        dialogueTrigger.TriggerDialogue();
                        switchCount2 = false;
                    }
                    break;
                case 6:
                    if (!switchCount1)
                    {
                        switchCount1 = true;
                        mBridge.BridgeAppear();
                        switchCount2 = false;
                    }
                    break;
                case 7:
                    if (!switchCount1)
                    {
                        switchCount1 = true;
                        mainMenu.WhichFunctionCalled();
                        switchCount2 = false;
                    }
                    break;
                case 8:
                    if (!switchCount1)
                    {
                        switchCount1 = true;
                        snowmanCollectThings.CollectObject();
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
                    sMoving.ObjectMovable = false;
                    break;
                case 1:
                    if (!switchCount2)
                    {
                        switchCount2 = true;
                        gAW.WichRuneChange();
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
                case 4:
                    if (!switchCount2)
                    {
                        switchCount2 = true;
                        shake.LetShardDown();
                        switchCount1 = false;
                    }
                    break;
                case 5:
                    if (!switchCount2)
                    {
                        switchCount2 = true;
                        dialogueTrigger.TriggerDialogue();
                        switchCount1 = false;
                    }
                    break;
                case 6:
                    if (!switchCount2)
                    {
                        switchCount2 = true;
                        mBridge.BridgeAppear();
                        switchCount1 = false;
                    }
                    break;
                case 7:
                    if (!switchCount2)
                    {
                        switchCount2 = true;
                        mainMenu.WhichFunctionCalled();
                        switchCount1 = false;
                    }
                    break;
                case 8:
                    if (!switchCount2)
                    {
                        switchCount2 = true;
                        snowmanCollectThings.CollectObject();
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