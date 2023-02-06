using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField][Range(0, 4)] private int functionID;
    /// <summary>
    /// 0 = NewGame
    /// 1 = LoadGame
    /// 2 = StartDemo
    /// 3 = ExitGame
    /// 4 = OpenOptions
    /// </summary>
    private SaveFunctions saveFunctions;
    private PauseFunctions pauseFunctions;
    private LoadingScene loadingScene;

    public void WhichFunctionCalled() 
    {
        switch (functionID) 
        {
            case 0:
                NewGame();
                break;
            case 1:
                LoadGame();
                break;
            case 2:
                StartDemo();
                break;
            case 3:
                ExitGame();
                break;
            case 4:
                OpenOptions();
                break;
        }
    }

    private void NewGame()
    {
        saveFunctions.NewGame();
        loadingScene.LoadScene();
    }
    private void LoadGame()
    {
        saveFunctions.Load();
        Debug.Break();
        loadingScene.LoadScene();
    }
    private void StartDemo()
    {
       loadingScene.startDemo = true;
       loadingScene.LoadScene();
    }
    private void ExitGame()
    {
        Application.Quit();
    }
    private void OpenOptions()
    {
        pauseFunctions.StartPauseMenu();
    }
    private void Start()
    { 
        saveFunctions = FindObjectOfType<SaveFunctions>();   
        pauseFunctions= FindObjectOfType<PauseFunctions>();
        loadingScene= FindObjectOfType<LoadingScene>();
    }
    
}
