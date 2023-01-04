using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Level1loading();
    }
    public void Level1loading()
    {
        SceneManager.LoadScene("Level_1");
    }
}
