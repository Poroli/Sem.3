using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class DataToSave : MonoBehaviour
{
    [Header("Control Keys")]
    public ControlKeys CKeys;

    private KeyCode p1Jump;
    private KeyCode p1Interact;
    private KeyCode p2Interact;

    [Header("Levels Completed")]
    public MasterControlScript MasterControlScript;
    private bool[] levelsCompleted;

    [Header("Elements Activated")]
    public ElementsManager EManager;
    private bool[] elementsActivated;

    public DataToSave(ControlKeys cKeys, MasterControlScript mCS, ElementsManager eManager)
    {
        p1Jump = cKeys.P1Jump;
        p1Interact = cKeys.P1InteractKey;
        p2Interact = cKeys.InteractKeyP2;

        levelsCompleted = mCS.LevelsCompleted;

        elementsActivated = eManager.ElementsActivated;
    }
}
