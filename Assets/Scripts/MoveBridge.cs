using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBridge : MonoBehaviour
{
    public bool BridgeActivate;
    public GameObject Bridge;

    [SerializeField] private Animator animatorP2;
    private CharacterMovementP2 CMP2;
    private bool bridgeAlreadyActivated;

    public void BridgeAppear()
    {
        if (bridgeAlreadyActivated)
        {
            return;
        }
        animatorP2.SetTrigger("ActivateRune");
        CMP2.tempNotMovable = true;
        BridgeActivate = true;
        bridgeAlreadyActivated = true;
    }

    private void Start()
    {
        CMP2 = FindObjectOfType<CharacterMovementP2>();
        Bridge.SetActive(false);
    }
}
