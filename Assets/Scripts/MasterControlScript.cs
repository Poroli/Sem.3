using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MasterControlScript : MonoBehaviour
{
    public bool[] LevelsCompleted = new bool[2];

    private AnimationManager animationManager;

    private void Level1Start()
    {
        animationManager.VideoID = 0;
        animationManager.CutSceneFinished = false;
        animationManager.StartCutScene();
    }

    void Awake()
    {
        animationManager = FindObjectOfType<AnimationManager>();
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level_1")
        {
            Level1Start();
        }
    }
}
