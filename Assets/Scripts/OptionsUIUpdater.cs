using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionsUIUpdater : MonoBehaviour
{
    public TMP_Text P1JumpKeyText;
    public TMP_Text P1InteractKeyText;
    
    public TMP_Text P2InteractKeyText;
    public ControlKeys ControlKeys;

    private void Update()
    {
        P1JumpKeyText.text = ControlKeys.P1Jump.ToString();
        P1InteractKeyText.text = ControlKeys.P1InteractKey.ToString();

        P2InteractKeyText.text = ControlKeys.InteractKeyP2.ToString();
    }
}
