using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go_away_Wall : MonoBehaviour

{
    public GameObject[] Walls;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject Wall4;
    public bool[]Runes = new bool[3];

    private int i;
    public void Wallcheck()
    {
        {
            if (Runes[i])
            {
                if (Walls[i].activeInHierarchy)
                {
                    Walls[i].SetActive(false);
                    Wall3.SetActive(false);
                }
                else if (!Walls[i].activeInHierarchy)
                {
                    Walls[i].SetActive(true);
                    Wall3.SetActive(true);
                }
           }
             
        }


        
        if (Rune1)
        {
        }
        if (Rune2)
        {
            Wall2.SetActive(false);
            Wall3 .SetActive(false);
        }
        if (Rune3)
        {
            Wall1.SetActive(false);
            Wall4 .SetActive(false);
        }

    }
    
}
    


