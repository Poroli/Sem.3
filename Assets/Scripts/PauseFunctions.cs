using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseFunctions : MonoBehaviour
{
    public GameObject OptionsButtons;
    public GameObject ButtonsPause;
    public GameObject PauseMenu;
    
    [SerializeField] private GameObject pauseFirstButton, optionsFirstButton, optionsClosedButton;
    private InteractWithObject[] iWOs;
    private LoadingScene loadingScene;
    private bool gamePaused;
    public void BackToHome()
    { 
        loadingScene.startMainMenu = true;
        loadingScene.LoadScene();
        Time.timeScale = 1;
    }
    public void OpenOptions()
    {
        OptionsButtons.SetActive(true);
        ButtonsPause.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }

    public void CloseOptions()
    {
        ButtonsPause.SetActive(true);
        OptionsButtons.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsClosedButton);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        gamePaused = false;
        foreach (InteractWithObject iWO in iWOs)
        {
            iWO.RefreshPlayerSpecifics();
        }
        PauseMenu.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        gamePaused = true;
        PauseMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }
    private void Start()
    {
        ButtonsPause = GameObject.Find("Buttons_Pause");
        OptionsButtons = GameObject.Find("Options_Buttons");
        PauseMenu = GameObject.Find("Pause_Menu");
        OptionsButtons.SetActive(false);
        PauseMenu.SetActive(false);
        iWOs = FindObjectsOfType<InteractWithObject>();
        loadingScene = FindObjectOfType<LoadingScene>();
    }

    private void Update()
    {
        if ((Input.GetButtonDown("Pause_C1")|| Input.GetButtonDown("Pause_C2")) && !gamePaused)
        {
          Pause();
        }
    }
}
