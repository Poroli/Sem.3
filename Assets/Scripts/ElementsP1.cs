using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsP1 : MonoBehaviour
{
    public int SelectedElement;
    public int ElementButtonID;
    
    private ElementsManager eManager;

    private void Start()
    {
        eManager = FindObjectOfType<ElementsManager>();
    }
    public void SwitchtwoElements()
    {
        SelectedElement = eManager.tempElement[ElementButtonID];
        eManager.tempElement[ElementButtonID] = eManager.P1Element;
        eManager.P1Element = SelectedElement;
        eManager.UpdateElementsActivated();
    }
}
