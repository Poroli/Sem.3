using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnding : MonoBehaviour
{
    public bool ActiveNextElement;

    private LoadingScene loadingScene;
    private MasterControlScript mCS;
    private ElementsManager elementsManager;
    private SaveFunctions saveFunctions;

    private void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.CompareTag("Player1") && other.gameObject.CompareTag("Player2")) && ShardManager.AllShardsCollected)
        {
            for (int i = 0; i < mCS.LevelsCompleted.Length; i++)
            {
                if (!mCS.LevelsCompleted[i])
                {
                    mCS.LevelsCompleted[i] = true;
                }
            }
            if (ActiveNextElement)
            {
                for (int i = 0; i < elementsManager.ElementsActivated.Length; i++)
                {
                    if (!elementsManager.ElementsActivated[i])
                    {
                        elementsManager.ElementsActivated[i] = true;
                    }
                }
            }
            saveFunctions.Save();
            loadingScene.LoadScene();
        }
    }


    private void Start()
    {
        loadingScene = FindObjectOfType<LoadingScene>();
        mCS = FindObjectOfType<MasterControlScript>();
        elementsManager = FindObjectOfType<ElementsManager>();
        saveFunctions = FindObjectOfType<SaveFunctions>();
    }
}
