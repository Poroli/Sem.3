using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel_1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Level_1loading();
    }
    public void Level_1loading()
    {
        SceneManager.LoadScene("Level_1");
    }
}
