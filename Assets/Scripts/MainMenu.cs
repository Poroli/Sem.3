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
        SceneManager.LoadScene("Level_1");
    }
    private void LoadGame()
    {
    
    }
    private void StartDemo()
    {

    }
    private void ExitGame()
    {

    }
    private void OpenOptions()
    {

    }
    private void Start()
    { 
        saveFunctions = FindObjectOfType<SaveFunctions>();   
    }
}
