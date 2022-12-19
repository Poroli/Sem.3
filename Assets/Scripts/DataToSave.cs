using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class DataToSave : MonoBehaviour
{
    public ElementsManager EManager;

    public int P2ElementSave;
    public int P1ElementSave;
    public bool[] ElementsActivatedSave;

    public DataToSave(ElementsManager e_Manager)
    {
        ElementsActivatedSave = e_Manager.Elements_Activated;
        P1ElementSave = e_Manager.P1Element;
        P2ElementSave = e_Manager.P2_Element;
    }
}
