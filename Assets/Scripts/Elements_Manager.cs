using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Elements_Manager : MonoBehaviour
{
    public int P2_Element;
    public int P1_Element;
    //0=Standart_activated;
    //1=Fire_activated;
    //2=Water_activated;
    //3=Earth_activated;
    //4=Air_activated;
    public bool[] Elements_Activated = new bool[5];
    public int[] temp_Element;
    public Button[] Element_Buttons = new Button[4];


    private void Start()
    {
        create_Array_of_switchable_Elements();
    }
    
    private void Refresh()
    {
        for (int i = 0; i < Elements_Activated.Length; i++)
        {
            Elements_Activated[i] = false;
        }
    }

    public void Update_Elements_Activated()
    {
        for (int i = 0; i < temp_Element.Length; i++)
        {
            Elements_Activated[temp_Element[i]] = true;
        }
    }

    public void Switch_with_Partner_Element()
    {
        int tmp_P1_Element;

        tmp_P1_Element = P1_Element;
        P1_Element = P2_Element;
        P2_Element = tmp_P1_Element;
    }

    public void create_Array_of_switchable_Elements()
    {
        int tmp_Element_Nr = 0;
        int tmp_Element_length = 0;
        
        for (int i = 0; i < Elements_Activated.Length; i++)
        {
            if (Elements_Activated[i] == true)
            {
                tmp_Element_length = tmp_Element_length + 1;
            }
        }
        temp_Element = new int[tmp_Element_length];
        for (int AEnr = 0; AEnr < Elements_Activated.Length -1; AEnr++)
        {
            if (Elements_Activated[AEnr] == true)
            {
                temp_Element[tmp_Element_Nr] = AEnr;
                tmp_Element_Nr = tmp_Element_Nr + 1;
            }
        }
        Give_Elementbutton_ElementID();
    }

    public void Give_Elementbutton_ElementID()
    {
            Element_to_switch element_To_Switch;
        for (int i = 0; i < temp_Element.Length; i++)
        {
            Element_Buttons[i].gameObject.SetActive(true);
            element_To_Switch = Element_Buttons[i].GetComponent<Element_to_switch>();
            element_To_Switch.Saved_Element_ID = temp_Element[i];
        }
    }
}
