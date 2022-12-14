using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_with_Object : MonoBehaviour
{
    public Control_Keys C_Keys;
    public List<Interact_Translate> I_Translates = new List<Interact_Translate>();

    private string Interactable;
    private string InteractWithPlayer;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(Interactable) || collision.gameObject.CompareTag(InteractWithPlayer))
        {
            Interact_Translate I_Translate = collision.GetComponent<Interact_Translate>();
            I_Translate.In_range = true;
            I_Translates.Add(collision.GetComponent<Interact_Translate>());
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag(Interactable) || collision.gameObject.CompareTag(InteractWithPlayer))
        {
            Interact_Translate I_Translate = collision.GetComponent<Interact_Translate>();
            if (I_Translates.Contains(I_Translate) == true)
            {
                I_Translate.In_range = false;
                I_Translates.Remove(I_Translate);
            }
        }
    }


    private void Start()
    {
        if (gameObject.tag == "Player1")
        {
            Interactable = "Interactable_P1";
            InteractWithPlayer = "Player1";
        }
        else if (gameObject.tag == "Player2")
        {
            Interactable = "Interactable_P2";
            InteractWithPlayer = "Player2";
        }
    }
    private void Update()
    {
        if (I_Translates.Count > 0 && Input.GetKeyDown(C_Keys.Interact_Key_P1))
        {
            foreach (Interact_Translate I_Translate in I_Translates)
            {
                if (I_Translate.Interact)
                {
                    I_Translate.Interact = false;
                }
                else if (!I_Translate.Interact)
                {
                    I_Translate.Interact = true;
                }
            }
        }
    }
}
