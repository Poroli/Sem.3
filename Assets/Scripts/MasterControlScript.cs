using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MasterControlScript : MonoBehaviour
{
    public bool[] LevelsCompleted = new bool[2];

    void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }
}
