using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Options_UI_Updater : MonoBehaviour
{
    public TMP_Text P1Forward_KeyText;
    public TMP_Text P1Backwards_KeyText;
    public TMP_Text P1Left_KeyText;
    public TMP_Text P1Right_KeyText;

    public TMP_Text P2Forward_KeyText;
    public TMP_Text P2Backwards_KeyText;
    public TMP_Text P2Left_KeyText;
    public TMP_Text P2Right_KeyText;

    public Control_Keys ControlKeys;

    private void Update()
    {
        P1Forward_KeyText.text = ControlKeys.P1Forward.ToString();
        P1Backwards_KeyText.text = ControlKeys.P1Backwards.ToString();
        P1Left_KeyText.text = ControlKeys.P1Left.ToString();
        P1Right_KeyText.text = ControlKeys.P1Right.ToString();

        P2Forward_KeyText.text = ControlKeys.P2Forward.ToString();
        P2Backwards_KeyText.text = ControlKeys.P2Backwards.ToString();
        P2Left_KeyText.text = ControlKeys.P2Left.ToString();
        P2Right_KeyText.text = ControlKeys.P2Right.ToString();
    }
}
