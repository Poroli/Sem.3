using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadingScene : MonoBehaviour
{
    public VideoPlayer LoadingScreen;

    [SerializeField] string[] Levels;
    [SerializeField] private MasterControlScript mCS;
    private string SceneToBeLoaded;
    
    private void WichSceneShouldBeLoaded() 
    {
        for (int i = 0; i < mCS.LevelsCompleted.Length; i++) 
        {
            if (mCS.LevelsCompleted[i]) 
            {
                return;               
            }
            SceneToBeLoaded = Levels[i];
            break;
        }   
    }

    public void LoadScene()
    {
        WichSceneShouldBeLoaded();
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneToBeLoaded);

        LoadingScreen.Play();

        while(!operation.isDone)
        {
            yield return null;
        }
    }
    private void Start()
    {
        LoadingScreen = GetComponent<VideoPlayer>();
    }
}

