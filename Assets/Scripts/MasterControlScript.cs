using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterControlScript : MonoBehaviour
{
    public bool[] LevelsCompleted = new bool[2];
    
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
}
