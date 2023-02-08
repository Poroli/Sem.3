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
    private List <GameObject> listOfGameobject =new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        { 
        listOfGameobject.Add(other.gameObject.GetComponent<GameObject>());
        Debug.Log($"{other.gameObject.name} wurde der Liste hinzugefügt");
        CheckIfPlayersInTrigger();           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (listOfGameobject.Contains(other.gameObject)) 
        {
            listOfGameobject.Remove(other.gameObject);
        }
    }
    private void CheckIfPlayersInTrigger()
    {
        if (ShardManager.AllShardsCollected) 
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            return;
        }
        foreach (GameObject GO in listOfGameobject)
        {
            if (GO.CompareTag("Player1"))
            {
                foreach (GameObject GO2 in listOfGameobject)
                {
                    if (GO2.CompareTag("Player2"))
                    {
                        EndLevel();
                        break;
                    }
                }
                break;
            }
        }
    }

    private void EndLevel()
    {
        Debug.Log("0");
        for (int i = 0; i < mCS.LevelsCompleted.Length; i++)
        {
            if (!mCS.LevelsCompleted[i])
            {
                mCS.LevelsCompleted[i] = true;
                Debug.Log("1");
            }
        }
        if (ActiveNextElement)
        {
            for (int i = 0; i < elementsManager.ElementsActivated.Length; i++)
            {
                if (!elementsManager.ElementsActivated[i])
                {
                    elementsManager.ElementsActivated[i] = true;
                    Debug.Log("2");
                }
            }
        }
        Debug.Log("3");
        saveFunctions.Save();
        loadingScene.LoadScene();
    }
    private void Start()
    {
        loadingScene = FindObjectOfType<LoadingScene>();
        mCS = FindObjectOfType<MasterControlScript>();
        elementsManager = FindObjectOfType<ElementsManager>();
        saveFunctions = FindObjectOfType<SaveFunctions>();
    }
}
