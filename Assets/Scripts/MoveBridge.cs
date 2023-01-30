using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBridge : MonoBehaviour
{
    public bool BridgeActivate;
    public GameObject Bridge;

    [SerializeField] private Animator animatorP2;
    private CharacterMovementP2 CMP2;

    public void BridgeAppear()
    {
        animatorP2.SetTrigger("ActivateRune");
        CMP2.tempNotMovable = true;
        BridgeActivate = true;
    }

    private void Start()
    {
        CMP2 = FindObjectOfType<CharacterMovementP2>();
        Bridge.SetActive(false);
    }
}
