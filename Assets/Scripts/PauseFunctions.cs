using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFunctions : MonoBehaviour
{
    public GameObject OptionsButtons;
    public GameObject ButtonsPause;
    public GameObject PauseMenu;

    public void OpenOptions()
    {
        ButtonsPause.SetActive(false);
        OptionsButtons.SetActive(true);
    }

    public void CloseOptions()
    {
        OptionsButtons.SetActive(false);
        ButtonsPause.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }


    private void Start()
    {
        ButtonsPause = GameObject.Find("Buttons_Pause");
        OptionsButtons = GameObject.Find("Options_Buttons");
        PauseMenu = GameObject.Find("Pause_Menu");
        OptionsButtons.SetActive(false);
        PauseMenu.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetButtonDown("Pause_C1")| Input.GetButtonDown("Pause_C2"))
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
    }
}
