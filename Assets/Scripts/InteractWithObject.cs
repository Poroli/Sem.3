using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    public ControlKeys CKeys;
    public List<InteractTranslate> InteractTranslates = new();

    private KeyCode playerKey;
    private string Interactable;
    private string InteractWithPlayer;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(Interactable) || collision.gameObject.CompareTag(InteractWithPlayer) || collision.gameObject.CompareTag("Shard") || collision.gameObject.CompareTag("NPC"))
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
        if (collision.gameObject.CompareTag(Interactable) || collision.gameObject.CompareTag(InteractWithPlayer) || collision.gameObject.CompareTag("Shard") || collision.gameObject.CompareTag("NPC"))
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
    private void Start()
    {
        RefreshPlayerSpecifics();
    }
    private void Update()
    {
        if (InteractTranslates.Count > 0 && (Input.GetKeyDown(playerKey)))
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
}
