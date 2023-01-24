using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ControlKeys")]
public class ControlKeys : ScriptableObject
{

    public KeyCode P1Jump;
    public KeyCode P1InteractKey;
    public KeyCode P1ChangeElementRTKey;
    public KeyCode P1ChangeElementLTKey;

    public KeyCode InteractKeyP2;
    public KeyCode ElementKey;
    public KeyCode P2ChangeElementRTKey;
    public KeyCode P2ChangeElementLTKey;
}
