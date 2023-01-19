using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MasterControlScript : MonoBehaviour
{
    public bool[] LevelsCompleted = new bool[2];
    
    void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }
}
