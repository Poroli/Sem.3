using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBridge : MonoBehaviour
{
    public GameObject Bridge;
    public void BridgeAppear()
    {
        Bridge.SetActive(true);
    }
}
