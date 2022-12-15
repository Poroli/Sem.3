using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Translate : MonoBehaviour
{

    public bool Interact;
    public bool In_range;

    private int i;
    private bool switch_count_1 = false;
    private bool switch_count_2 = true;
    private Stone_Moving s_moving;
    private Go_away_Wall g_a_W;
    private ThrowObject t_Object;
    private CollectShard collectShard;
    private bool[] USO = new bool[3];
    /// <summary>
    /// 0 = Stone_Moving
    /// 1 = activate Runes
    /// 2 = Throw
    /// 3 = Shard
    /// 
    /// </summary>
    
    private void Start()
    {
        if (GetComponent<Stone_Moving>())
        {
            s_moving = GetComponent<Stone_Moving>();
            i = 0;
            USO[i] = true;
        }
        if (GetComponent<Go_away_Wall>())
        {
            g_a_W = GetComponent<Go_away_Wall>();
            i = 1;
            USO[i] = true;
        }
        if (GetComponent<ThrowObject>())
        {
            t_Object = GetComponent<ThrowObject>();
            i = 2;
            USO[i] = true;
        }
        if (GetComponent<CollectShard>())
        {
            collectShard = GetComponent<CollectShard>();
            i = 3;
            USO[i] = true;
        }
    }

    private void Translate_Interact()
    {
        if (USO[i] && Interact)
        {
            switch (i)
            {
                case 0:
                    if (In_range)
                    {
                        s_moving.Stone_movable = true;
                    }
                    else
                    {
                        s_moving.Stone_movable = false;
                    }
                    break;
                case 1:
                    if (!switch_count_1)
                    {
                        switch_count_1 = true;
                        g_a_W.activate_rune = true;
                        switch_count_2 = false;
                    }
                    break;
                case 2:
                    if (!switch_count_1)
                    {
                        switch_count_1 = true;
                        t_Object.up_throw = true;
                        switch_count_2 = false;
                    }
                    break;
                case 3:
                    if (!switch_count_1)
                    {
                        switch_count_1 = true;
                        collectShard.CollectingShard();
                        switch_count_2 = false;
                    }
                    break;
            }
        }
        else if (USO[i] && !Interact)
        {           
            switch (i)
            {
                case 0:
                    s_moving.Stone_movable = false;
                    break;
                case 1:
                    if (!switch_count_2)
                    {
                        switch_count_2 = true;
                        g_a_W.activate_rune = true;
                        switch_count_1 = false;
                    }
                    break;
                case 2:
                    if (!switch_count_2)
                    {
                        switch_count_2 = true;
                        t_Object.up_throw = true;
                        switch_count_1 = false;
                    }
                    break;
                case 3:
                    if (!switch_count_2)
                    {
                        switch_count_2 = true;
                        collectShard.CollectingShard();
                        switch_count_1 = false;
                    }
                    break;
            }
        }
    }

    private void Update()
    {
        Translate_Interact();
    }
}