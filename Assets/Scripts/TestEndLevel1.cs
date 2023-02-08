using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEndLevel1 : MonoBehaviour
{
    public bool ActiveNextElement;

    private LoadingScene loadingScene;
    private MasterControlScript mCS;
    private SaveFunctions saveFunctions;
    private ElementsManager elementsManager;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2")) && ShardManager.AllShardsCollected)
        {
            EndLevel();
        }
    }
    private void EndLevel()
    {
        for (int i = 0; i < mCS.LevelsCompleted.Length; i++)
        {
            if (!mCS.LevelsCompleted[i])
            {
                mCS.LevelsCompleted[i] = true;
                break;
            }
        }
        if (ActiveNextElement)
        {
            for (int i = 0; i < elementsManager.ElementsActivated.Length; i++)
            {
                if (!elementsManager.ElementsActivated[i])
                {
                    elementsManager.ElementsActivated[i] = true;
                    break;
                }
            }
        }
        saveFunctions.Save();
        loadingScene.LoadScene();
    }
    private void Start()
    {
        loadingScene = FindObjectOfType<LoadingScene>();
        mCS = FindObjectOfType<MasterControlScript>();
        saveFunctions = FindObjectOfType<SaveFunctions>();
        elementsManager = FindObjectOfType<ElementsManager>();
    }
}
