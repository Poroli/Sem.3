using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class DataToSave : MonoBehaviour
{
    [Header("Control Keys")]
    public ControlKeys CKeys;

    [Header("Levels Completed")]
    public MasterControlScript MasterControlScript;

    [Header("Elements Activated")]
    public ElementsManager EManager;


    public void GetData()
    {
        SaveDataContainer.p1Jump = CKeys.P1Jump;
        SaveDataContainer.p1Interact = CKeys.P1InteractKey;
        SaveDataContainer.p2Interact = CKeys.InteractKeyP2;

        SaveDataContainer.levelsCompleted = MasterControlScript.LevelsCompleted;

        SaveDataContainer.elementsActivated = EManager.ElementsActivated;
    }

    public void SyncData()
    {
        if (SaveFunctions.canLoadData)
        {
            CKeys.P1Jump = SaveDataContainer.p1Jump;
            CKeys.P1InteractKey = SaveDataContainer.p1Interact;
            CKeys.InteractKeyP2 = SaveDataContainer.p2Interact;
        
            MasterControlScript.LevelsCompleted = SaveDataContainer.levelsCompleted;

            EManager.ElementsActivated = SaveDataContainer.elementsActivated;

        }
    }
}

[Serializable]
public class SaveDataContainer
{
    public static KeyCode p1Jump;
    public static KeyCode p1Interact;
    public static KeyCode p2Interact;

    public static bool[] levelsCompleted;

    public static bool[] elementsActivated;
}