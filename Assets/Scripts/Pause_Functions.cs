using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Functions : MonoBehaviour
{
    public GameObject Options_Buttons;
    public GameObject Buttons_Pause;
    public GameObject Pause_Menu;

    public void OpenOptions()
    {
        Buttons_Pause.SetActive(false);
        Options_Buttons.SetActive(true);
    }

    public void CloseOptions()
    {
        Options_Buttons.SetActive(false);
        Buttons_Pause.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        Pause_Menu.SetActive(false);
    }


    private void Start()
    {
        Buttons_Pause = GameObject.Find("Buttons_Pause");
        Options_Buttons = GameObject.Find("Options_Buttons");
        Pause_Menu = GameObject.Find("Pause_Menu");
        Options_Buttons.SetActive(false);
        Pause_Menu.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetButtonDown("Pause_C1")| Input.GetButtonDown("Pause_C2"))
        {
            Time.timeScale = 0;
            Pause_Menu.SetActive(true);
        }
    }
}
