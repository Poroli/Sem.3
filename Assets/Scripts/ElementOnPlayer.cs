using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementOnPlayer : MonoBehaviour
{
    public ControlKeys CKeys;

    private ElementsManager eManager;
    private KeyCode RTKey;
    private KeyCode LTKey;
    
    
    private void ChangeActiveElementRightTurn()
    {
        if (gameObject.CompareTag("Player1"))
        {
            eManager.tmpActiveElement = eManager.p1ActiveElement;
            eManager.ElementChangeRightTurn();
            eManager.p1ActiveElement = eManager.tmpActiveElement;
        }
        else if (gameObject.CompareTag("Player2"))
        {
            eManager.tmpActiveElement = eManager.p2ActiveElement;
            eManager.ElementChangeRightTurn();
            eManager.p2ActiveElement = eManager.tmpActiveElement;
        }
    }
    private void ChangeActiveElementLeftTurn()
    {
        if (gameObject.CompareTag("Player1"))
        {
            eManager.tmpActiveElement = eManager.p1ActiveElement;
            eManager.ElementChangeLeftTurn();
            eManager.p1ActiveElement = eManager.tmpActiveElement;
        }
        else if (gameObject.CompareTag("Player2"))
        {
            eManager.tmpActiveElement = eManager.p2ActiveElement;
            eManager.ElementChangeLeftTurn();
            eManager.p2ActiveElement = eManager.tmpActiveElement;
        }
    }

    private void Start()
    {
        eManager = FindObjectOfType<ElementsManager>();
        if (gameObject.CompareTag("Player1"))
        {
            RTKey = CKeys.P1ChangeElementRTKey;
            LTKey = CKeys.P2ChangeElementRTKey;
        }
        else if (gameObject.CompareTag("Player2"))
        {

        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(RTKey))
        {
            ChangeActiveElementRightTurn();
        }
        else if(Input.GetKeyDown(LTKey))
        {
            ChangeActiveElementLeftTurn();
        }
    }
}
