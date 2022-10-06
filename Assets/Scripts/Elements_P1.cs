using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements_P1 : MonoBehaviour
{
    public int Selected_Element;
    public int Element_Button_ID;
    
    private Elements_Manager e_Manager;

    private void Start()
    {
        e_Manager = FindObjectOfType<Elements_Manager>();
    }
    public void Switch_two_Elements()
    {
        Selected_Element = e_Manager.tmp_Element[Element_Button_ID];
        e_Manager.tmp_Element[Element_Button_ID] = e_Manager.P1_Element;
        e_Manager.P1_Element = Selected_Element;
    }
}
