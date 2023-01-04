using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    public ControlKeys CKeys;
    public List<InteractTranslate> InteractTranslates = new();

    private string Interactable;
    private string InteractWithPlayer;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(Interactable) || collision.gameObject.CompareTag(InteractWithPlayer) || collision.gameObject.CompareTag("Shard"))
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
        if (collision.gameObject.CompareTag(Interactable) || collision.gameObject.CompareTag(InteractWithPlayer) || collision.gameObject.CompareTag("Shard"))
        {
            InteractTranslate ITranslate = collision.GetComponent<InteractTranslate>();
            if (InteractTranslates.Contains(ITranslate))
            {
                ITranslate.InRange = false;
                InteractTranslates.Remove(ITranslate);
            }
        }
    }


    private void Start()
    {
        if (this.transform.parent.CompareTag("Player1"))
        {
            Interactable = "InteractableP1";
            InteractWithPlayer = "Player2";
        }
        else if (this.transform.parent.CompareTag("Player2"))
        {
            Interactable = "InteractableP2";
            InteractWithPlayer = "Player1";
        }
    }
    private void Update()
    {
        if (InteractTranslates.Count > 0 && Input.GetKeyDown(CKeys.InteractKeyP1))
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
