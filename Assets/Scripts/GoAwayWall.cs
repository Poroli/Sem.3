using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAwayWall : MonoBehaviour
{
    public GameObject[] Walls = new GameObject[4];
    [Range(1,3)]public int RunesNr;
    public bool ActivateRune;
    public bool GateBarsOpen;
    
    [SerializeField]private Animator gateAnimator;
    [SerializeField] private Animator animatorP2;
    private CharacterMovementP2 CMP2;
    private readonly bool[] runes = new bool[3];
    private string animationBoolString;
    private int i;

    public void ResetRunes()
    {
        for (int i = 0; i < runes.Length; i++)
        {
            runes[i] = false;
        }
    }
    public void WichRuneChange()
    {
        if (RunesNr == 1)
        {
            runes[0] = true;
        }
        else if (RunesNr == 2)
        {
            runes[1] = true;
        }
        else if (RunesNr == 3)
        {
            runes[2] = true;
        }
        animatorP2.SetTrigger("ActivateRune");
        CMP2.tempNotMovable = true;
        GateBarsOpen = true;
    }

    private void SetAnimation()
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
        if (gateAnimator.GetBool(animationBoolString))
        {
            gateAnimator.SetBool(animationBoolString, false);
        }
        else if (!gateAnimator.GetBool(animationBoolString))
        {
            gateAnimator.SetBool(animationBoolString, true);
        }
    }

    public void Wallcheck()
    {
        if (runes[0])
        {
            for (i = 0; i <= 2; i += 2)
            {
                SetAnimation();
            }
        }
        else if (runes[1])
        {
            for (i = 1; i <= 2; i += 1)
            {
                SetAnimation();
            }
        }
        else if (runes[2])
        {
            for (i = 0; i <= Walls.Length; i += 3)
            {
                SetAnimation();
            }
        }
    }

    private void Start()
    {
        CMP2 = FindObjectOfType<CharacterMovementP2>();
    }
}
    


