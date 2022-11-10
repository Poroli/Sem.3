using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieltitel : MonoBehaviour
{
    public GameObject spieltitel;
 

  
    IEnumerator Start()
    {
        spieltitel.SetActive(true);

        yield return new WaitForSeconds(8.0f); 

        spieltitel.SetActive(false);



    }

}
