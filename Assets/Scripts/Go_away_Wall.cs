using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go_away_Wall : MonoBehaviour
{
    public GameObject[] Walls = new GameObject[4];
    public int Runes_Nr;
    public bool activate_rune;
    private bool[] Runes = new bool[3];
    private bool reset;

    private void If_runes_change()
    {
        if (reset)
        {
            activate_rune = false;
            for (int i = 0; i < Runes.Length; i++)
            {
                Runes[i] = false;
            }
            reset = false;
        }
        else if (activate_rune && Runes_Nr == 1)
        {
            Runes[0] = true;
            Wallcheck();
            reset = true;
        }
        else if (activate_rune && Runes_Nr == 2)
        {
            Runes[1] = true;
            Wallcheck();
            reset = true;
        }
        else if (activate_rune && Runes_Nr == 3)
        {
            Runes[2] = true;
            Wallcheck();
            reset = true;
        }
    }
    
    private void Wallcheck()
    {
        if (Runes[0])
        {
            for (int i = 0; i <= 2; i = i + 2)
            {
                if (Walls[i].activeInHierarchy)
                    {
                        Walls[i].SetActive(false);
                    }
                else if (!Walls[i].activeInHierarchy)
                {
                    Walls[i].SetActive(true);
                }
            }
        }
        else if (Runes[1])
        {
            for (int i = 1; i <= 2; i = i + 1)
            {
                if (Walls[i].activeInHierarchy)
                {
                    Walls[i].SetActive(false);
                }
                else if (!Walls[i].activeInHierarchy)
                {
                    Walls[i].SetActive(true);
                }
            }
        }
        else if (Runes[2])
        {
            for (int i = 0; i <= Walls.Length; i = i + 3)
            {
                if (Walls[i].activeInHierarchy)
                {
                    Walls[i].SetActive(false);
                }
                else if (!Walls[i].activeInHierarchy)
                {
                    Walls[i].SetActive(true);
                }
            }
        }
    }

    private void Update()
    {
        If_runes_change();
    }
}
    


