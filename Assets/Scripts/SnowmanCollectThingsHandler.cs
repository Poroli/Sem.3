using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanCollectThingsHandler : MonoBehaviour
{
    public bool[] accessoiresCollected;

    [SerializeField] private GameObject[] accesoires;
    private int AccessoireCount;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            ActivateCollectedAccessoires();
            CheckSnowmanCompleted();
        }
    }

    private void ActivateCollectedAccessoires()
    {
        for (int i = 0; i < accessoiresCollected.Length; i++)
        {
            if (accessoiresCollected[i])
            {
                accesoires[i].SetActive(true);
            }
        }
    }

    private void CheckSnowmanCompleted()
    {
        AccessoireCount = 0;
        for (int i = 0; i < accesoires.Length; i++)
        {
            if (accesoires[i].activeInHierarchy)
            {
                 AccessoireCount += 1;
            }
        }
        if (AccessoireCount == accesoires.Length)
        {
            DialogueTrigger dialogueTrigger = transform.parent.gameObject.GetComponent<DialogueTrigger>();
            dialogueTrigger.TriggerDialogue();
        }
    }

    private void Awake()
    {
        accessoiresCollected = new bool[accesoires.Length];
    }
}
