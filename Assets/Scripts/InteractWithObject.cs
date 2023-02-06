using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    public ControlKeys CKeys;
    public List<InteractTranslate> InteractTranslates = new();

    [SerializeField] private GameObject UIPopUpInteract;
    private KeyCode playerKey;
    private string Interactable;
    private string InteractWithPlayer;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(Interactable) || collision.gameObject.CompareTag(InteractWithPlayer) || collision.gameObject.CompareTag("Shard") || collision.gameObject.CompareTag("NPC") || collision.gameObject.CompareTag("SnowmanPiece"))
        {
            if (collision.GetComponent<InteractTranslate>())
            { 
                InteractTranslate ITranslate = collision.GetComponent<InteractTranslate>();
                ITranslate.InRange = true;
                InteractTranslates.Add(collision.GetComponent<InteractTranslate>());
            
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag(Interactable) || collision.gameObject.CompareTag(InteractWithPlayer) || collision.gameObject.CompareTag("Shard") || collision.gameObject.CompareTag("NPC") || collision.gameObject.CompareTag("SnowmanPiece"))
        {
            InteractTranslate ITranslate = collision.GetComponent<InteractTranslate>();
            if (InteractTranslates.Contains(ITranslate))
            {
                ITranslate.InRange = false;
                InteractTranslates.Remove(ITranslate);
            }
        }
    }


    public void RefreshPlayerSpecifics()
    {
        if (this.transform.parent.CompareTag("Player1"))
        {
            Debug.Log("Test StringSet");
            playerKey = CKeys.P1InteractKey;
            Interactable = "InteractableP1";
            InteractWithPlayer = "Player2";
        }
        else if (this.transform.parent.CompareTag("Player2"))
        {
            playerKey = CKeys.InteractKeyP2;
            Interactable = "InteractableP2";
            InteractWithPlayer = "Player1";
        }
    }

    public void RefreshInteractTranslates()
    {
        if (InteractTranslates.Count == 0)
        {
            return;
        }
        for (int i = InteractTranslates.Count -1; i >= 0; i--)
        {
            if (InteractTranslates[i].gameObject == ShardManager.GOToCheck)
            {
                InteractTranslates.RemoveAt(i);
            }
        }
    }

    private void Start()
    {
        RefreshPlayerSpecifics();
    }
    private void Update()
    {
        if (InteractTranslates.Count > 0)
        {
            UIPopUpInteract.SetActive(true);

            if (Input.GetKeyDown(playerKey))
            {
                foreach (InteractTranslate ITranslate in InteractTranslates)
                {
                    if (ITranslate.Interact)
                    {
                        ITranslate.Interact = false;
                    }
                    else if (!ITranslate.Interact)
                    {
                        ITranslate.Interact = true;
                    }
                }
            }
        }
        else UIPopUpInteract.SetActive(false);
    }
}
