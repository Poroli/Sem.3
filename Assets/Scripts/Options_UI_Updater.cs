using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Options_UI_Updater : MonoBehaviour
{
    public TMP_Text P1Jump_KeyText;
    public TMP_Text P2Jump_KeyText;

    public Control_Keys ControlKeys;

    private void Update()
    {
        P1Jump_KeyText.text = ControlKeys.P1Jump.ToString();
        
        P2Jump_KeyText.text = ControlKeys.P2Jump.ToString();
    }
}
