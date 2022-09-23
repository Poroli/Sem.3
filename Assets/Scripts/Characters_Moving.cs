using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters_Moving : MonoBehaviour
{

    public GameObject P1;
    public GameObject P2;
    void Start()
    {
        P1 = GameObject.FindWithTag("Player1");
        P2 = GameObject.FindWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
