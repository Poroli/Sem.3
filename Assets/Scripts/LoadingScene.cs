using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadingScene : MonoBehaviour
{
    public VideoPlayer LoadingScreen;
    public bool startDemo;

    [SerializeField] private Camera cam;
    [SerializeField] private MasterControlScript mCS;
    [SerializeField] private string[] Levels;
    private string SceneToBeLoaded;
    private void WhichSceneShouldBeLoaded() 
    {
        for (int i = 0; i < mCS.LevelsCompleted.Length; i++) 
        {
            if (!mCS.LevelsCompleted[i]) 
            {
                SceneToBeLoaded = Levels[i];
                break;             
            }
        }   
    }

    public void LoadScene()
    {
        if (startDemo)
        {
            SceneToBeLoaded = "Demo";
            startDemo = false;
        }
        else 
        {
            WhichSceneShouldBeLoaded();
        }
        LoadingScreen.Play();
        cam.gameObject.SetActive(true);
        StartCoroutine(LoadSceneAsync());           

    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneToBeLoaded);

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

