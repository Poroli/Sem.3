using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadingScene : MonoBehaviour
{
    public VideoPlayer LoadingScreen;

    public Scene[] Scenes;

    [SerializeField] private MasterControlScript mCS;
    private int SceneId;
    private void ScenesToBeLoaded() 
    {
        for (int i = 0; mCS.LevelsCompleted.Length; i++) 
        {
            if (mCS.LevelsCompleted[i]) 
            {
                return;               
            }
            SceneId = Scenes[i].Get;
            break;
        }   
    }



    public void LoadScene(int sceneId)
    { 
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        LoadingScreen.Play();

  
    }

}

