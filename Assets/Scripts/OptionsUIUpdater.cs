using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionsUIUpdater : MonoBehaviour
{
    public TMP_Text P1JumpKeyText;
    public TMP_Text P2JumpKeyText;
    public ControlKeys ControlKeys;

    private void Update()
    {
        P1JumpKeyText.text = ControlKeys.P1Jump.ToString();
        
        P2JumpKeyText.text = ControlKeys.P2Jump.ToString();
    }
}
