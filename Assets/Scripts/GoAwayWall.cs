using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAwayWall : MonoBehaviour
{
    public GameObject[] Walls = new GameObject[4];
    public int RunesNr;
    public bool ActivateRune;
    
    [SerializeField]private Animator animator;
    private bool[] runes = new bool[3];
    private bool reset;
    private string animationBoolString;

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
                switch (i)
                {
                    case 0:
                        animationBoolString = "Bar1Open";
                        break;
                    case 1:
                        animationBoolString = "Bar2Open";
                        break;
                    case 2:
                        animationBoolString = "Bar3Open";
                        break;
                    case 3:
                        animationBoolString = "Bar4Open";
                        break;
                }
                if (animator.GetBool(animationBoolString))
                    {
                        animator.SetBool(animationBoolString, false);
                    }
                else if (!animator.GetBool(animationBoolString))
                {
                    animator.SetBool(animationBoolString, true);
                }
            }
        }
        else if (runes[1])
        {
            for (int i = 1; i <= 2; i += 1)
            {
                switch (i)
                {
                    case 0:
                        animationBoolString = "Bar1Open";
                        break;
                    case 1:
                        animationBoolString = "Bar2Open";
                        break;
                    case 2:
                        animationBoolString = "Bar3Open";
                        break;
                    case 3:
                        animationBoolString = "Bar4Open";
                        break;
                }
                if (animator.GetBool(animationBoolString))
                {
                    animator.SetBool(animationBoolString, false);
                }
                else if (!animator.GetBool(animationBoolString))
                {
                    animator.SetBool(animationBoolString, true);
                }
            }
        }
        else if (runes[2])
        {
            for (int i = 0; i <= Walls.Length; i += 3)
            {
                switch (i)
                {
                    case 0:
                        animationBoolString = "Bar1Open";
                        break;
                    case 1:
                        animationBoolString = "Bar2Open";
                        break;
                    case 2:
                        animationBoolString = "Bar3Open";
                        break;
                    case 3:
                        animationBoolString = "Bar4Open";
                        break;
                }
                if (animator.GetBool(animationBoolString))
                {
                    animator.SetBool(animationBoolString, false);
                }
                else if (!animator.GetBool(animationBoolString))
                {
                    animator.SetBool(animationBoolString, true);
                }
            }
        }
    }

    private void Update()
    {
        ifRunesChange();
    }
}
    


