using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interact : MonoBehaviour
{
    public bool GetKeyInput;
    public Dialogue dialogue;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player_1")
        {
            if (GetKeyInput)
            {
                
            }
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        }
    }    
  
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player_1")
        { 
        
        }
        
    }

    
}
