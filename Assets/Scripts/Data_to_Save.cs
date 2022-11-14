using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class Data_to_Save : MonoBehaviour
{
    public Elements_Manager e_Manager;

    public int P2_Element_Save;
    public int P1_Element_Save;
    public bool[] Elements_Activated_Save;

    public Data_to_Save(Elements_Manager e_Manager)
    {
        Elements_Activated_Save = e_Manager.Elements_Activated;
        P1_Element_Save = e_Manager.P1_Element;
        P2_Element_Save = e_Manager.P2_Element;
    }
}
