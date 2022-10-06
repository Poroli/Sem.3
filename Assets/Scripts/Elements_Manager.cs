using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Elements_Manager : MonoBehaviour
{
    public int P2_Element;
    public int P1_Element;
    public bool[] Elements_Activated;
    public int[] tmp_Element;
    public Button[] Element_Buttons = new Button[4];

    private bool Fire_activated;
    private bool Water_activated;
    private bool Earth_activated;
    private bool Air_activated;
    private bool Standart_activated;

    private void Start()
    {
        Refresh();
        create_Array_of_switchable_Elements();
    }
    
    private void Refresh()
    {
        Elements_Activated = new bool[] {Fire_activated, Water_activated, Earth_activated, Air_activated, Standart_activated};
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
        tmp_Element = new int[tmp_Element_length];
        for (int AEnr = 0; AEnr < Elements_Activated.Length -1; AEnr++)
        {
            if (Elements_Activated[AEnr] == true)
            {
                tmp_Element[tmp_Element_Nr] = AEnr;
                tmp_Element_Nr = tmp_Element_Nr + 1;
            }
        }
        Give_Elementbutton_ElementID();
    }

    public void Give_Elementbutton_ElementID()
    {
            Element_to_switch element_To_Switch;
        for (int i = 0; i < tmp_Element.Length; i++)
        {
            Element_Buttons[i].gameObject.SetActive(true);
            element_To_Switch = Element_Buttons[i].GetComponent<Element_to_switch>();
            element_To_Switch.Saved_Element_ID = tmp_Element[i];
        }
    }
}
