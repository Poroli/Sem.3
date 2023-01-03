using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    public ControlKeys CKeys;
    public List<InteractTranslate> ITranslates = new List<InteractTranslate>();

    private string Interactable;
    private string InteractWithPlayer;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(Interactable) || collision.gameObject.CompareTag(InteractWithPlayer) || collision.gameObject.CompareTag("Shard"))
        {
            InteractTranslate ITranslate = collision.GetComponent<InteractTranslate>();
            ITranslate.InRange = true;
            if (ITranslates.Contains(ITranslate))
            {
                ITranslates.Remove(ITranslate);
                ITranslates.Add(collision.GetComponent<InteractTranslate>());                
            }
            else
            {
                ITranslates.Add(collision.GetComponent<InteractTranslate>());
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag(Interactable) || collision.gameObject.CompareTag(InteractWithPlayer) || collision.gameObject.CompareTag("Shard"))
        {
            InteractTranslate ITranslate = collision.GetComponent<InteractTranslate>();
            if (ITranslates.Contains(ITranslate))
            {
                ITranslate.InRange = false;
                ITranslates.Remove(ITranslate);
            }
        }
    }


    private void Start()
    {
        if (gameObject.CompareTag("Player1"))
        {
            Interactable = "InteractableP1";
            InteractWithPlayer = "Player2";
        }
        else if (gameObject.CompareTag("Player2"))
        {
            Interactable = "InteractableP2";
            InteractWithPlayer = "Player1";
        }
    }
    private void Update()
    {
        if (ITranslates.Count > 0 && Input.GetKeyDown(CKeys.InteractKeyP1))
        {
            foreach (InteractTranslate ITranslate in ITranslates)
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
