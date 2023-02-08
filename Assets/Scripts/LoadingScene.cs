using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadingScene : MonoBehaviour
{
    public VideoPlayer LoadingScreenVideoPlayer;
    public VideoClip LoadingScreen;
    public bool startDemo;
    public bool startMainMenu;

    [SerializeField] private Camera cam;
    [SerializeField] private MasterControlScript mCS;
    [SerializeField] private string[] Levels;
    private string SceneToBeLoaded;
    private int numberOfLevelsCompleted;
    private void WhichSceneShouldBeLoaded() 
    {
        for (int i = 0; i < mCS.LevelsCompleted.Length; i++) 
        {
            if (!mCS.LevelsCompleted[i]) 
            {
                SceneToBeLoaded = Levels[i];
                break;             
            }
            else
            {
                numberOfLevelsCompleted++;
            }
        }   
        if (numberOfLevelsCompleted >= mCS.LevelsCompleted.Length)
        {
            SceneToBeLoaded = "MainMenu";
        }
    }

    public void LoadScene()
    {
        if (startDemo)
        {
            SceneToBeLoaded = "Demo";
            startDemo = false;
        }
        if (startMainMenu)
        {
            SceneToBeLoaded = "MainMenu";
            startMainMenu = false;
        }
        else
        {

            WhichSceneShouldBeLoaded();
        }
        cam.gameObject.SetActive(true);
        LoadingScreenVideoPlayer.clip = LoadingScreen;
        LoadingScreenVideoPlayer.Play();
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
        LoadingScreenVideoPlayer = GetComponent<VideoPlayer>();
    }
}

