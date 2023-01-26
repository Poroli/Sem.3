using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsTransmitter : MonoBehaviour
{
    public Toggle DynamicCamToggle;
    [SerializeField] private Options options;

    public void RefreshDynamicCamOption()
    {
        if (DynamicCamToggle)
        {
            options.DynamicJumpCamOn = true;
        }
        else if (DynamicCamToggle)
        {
            options.DynamicJumpCamOn = false;
        }
    }
}
