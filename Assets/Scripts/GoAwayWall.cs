using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAwayWall : MonoBehaviour
{
    public GameObject[] Walls = new GameObject[4];
    public int RunesNr;
    public bool ActivateRune;
    
    private bool[] runes = new bool[3];
    private bool reset;

    private void ifRunesChange()
    {
        if (reset)
        {
            ActivateRune = false;
            for (int i = 0; i < runes.Length; i++)
            {
                runes[i] = false;
            }
            reset = false;
        }
        else if (ActivateRune && RunesNr == 1)
        {
            runes[0] = true;
            Wallcheck();
            reset = true;
        }
        else if (ActivateRune && RunesNr == 2)
        {
            runes[1] = true;
            Wallcheck();
            reset = true;
        }
        else if (ActivateRune && RunesNr == 3)
        {
            runes[2] = true;
            Wallcheck();
            reset = true;
        }
    }
    
    private void Wallcheck()
    {
        if (runes[0])
        {
            for (int i = 0; i <= 2; i += 2)
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
        else if (runes[1])
        {
            for (int i = 1; i <= 2; i += 1)
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
        else if (runes[2])
        {
            for (int i = 0; i <= Walls.Length; i += 3)
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
        ifRunesChange();
    }
}
    


